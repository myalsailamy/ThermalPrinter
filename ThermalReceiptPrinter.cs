using System;
using System.Drawing;
using System.IO;

namespace ThermalReceiptPrinter
{
    /// <summary>
    /// نقطة الدخول الرئيسية للمكتبة: يطبع فاتورة كاشير على طابعة حرارية محلية أو شبكية
    /// بدون أي واجهة تظهر للمستخدم، ويدعم اللغة العربية والقص التلقائي.
    /// </summary>
    public class ReceiptPrinter
    {
        private readonly PrinterProfile _profile;

        public ReceiptPrinter(PrinterProfile profile)
        {
            _profile = profile ?? throw new ArgumentNullException(nameof(profile));
        }

        /// <summary>
        /// يطبع الفاتورة كاملة (بدون أي نافذة/حوار طباعة) ويقصّ الورق تلقائيًا إذا كان مفعلًا.
        /// يختار تلقائيًا طريقة الإرسال (محلي عبر winspool أو شبكي عبر TCP) حسب profile.ConnectionType.
        /// </summary>
        public bool Print(ReceiptModel receipt)
        {
            if (receipt == null) throw new ArgumentNullException(nameof(receipt));

            using (Bitmap receiptImage = ReceiptRenderer.Render(receipt, _profile))
            {
                byte[] payload = BuildPayload(receiptImage);
                return Send(payload);
            }
        }

        /// <summary>يرسل أمر قص فقط (مفيد لاختبار أن الطابعة تدعم القص الآلي).</summary>
        public bool TestCut()
        {
            using (var ms = new MemoryStream())
            {
                ms.Write(EscPos.Init, 0, EscPos.Init.Length);
                byte[] feed = EscPos.FeedLines(3);
                ms.Write(feed, 0, feed.Length);
                ms.Write(EscPos.FullCut, 0, EscPos.FullCut.Length);
                return Send(ms.ToArray());
            }
        }

        /// <summary>يفتح درج الكاش المتصل بالطابعة (إن وُجد).</summary>
        public bool OpenCashDrawer()
        {
            return Send(EscPos.OpenCashDrawer);
        }

        /// <summary>
        /// يختبر الاتصال بالطابعة الشبكية فقط (بدون إرسال أي بيانات طباعة فعلية) - مفيد للتأكد من العنوان والمنفذ.
        /// </summary>
        public bool TestNetworkConnection()
        {
            if (_profile.ConnectionType != PrinterConnectionType.NetworkTcpIp)
                throw new InvalidOperationException("هذه الدالة تعمل فقط عندما يكون ConnectionType = NetworkTcpIp");

            return NetworkPrinterHelper.SendBytesToPrinter(_profile.NetworkIp, _profile.NetworkPort, EscPos.Init, _profile.NetworkTimeoutMs);
        }

        /// <summary>
        /// يعيد الفاتورة كصورة Bitmap بدون طباعة - مفيد للمعاينة على الشاشة قبل الطباعة
        /// أو لحفظها كملف PNG لأغراض الأرشفة.
        /// </summary>
        public Bitmap RenderPreview(ReceiptModel receipt)
        {
            return ReceiptRenderer.Render(receipt, _profile);
        }

        // ---------------------------------------------------------------

        private byte[] BuildPayload(Bitmap receiptImage)
        {
            byte[] imageCommand = EscPosImageConverter.ToRasterCommand(receiptImage, _profile.BlackThreshold);

            using (var ms = new MemoryStream())
            {
                ms.Write(EscPos.Init, 0, EscPos.Init.Length);
                ms.Write(imageCommand, 0, imageCommand.Length);

                if (_profile.AutoCut)
                {
                    byte[] feed = EscPos.FeedLines(_profile.FeedLinesBeforeCut);
                    ms.Write(feed, 0, feed.Length);
                    ms.Write(EscPos.FullCut, 0, EscPos.FullCut.Length);
                }

                if (_profile.OpenCashDrawerAfterPrint)
                    ms.Write(EscPos.OpenCashDrawer, 0, EscPos.OpenCashDrawer.Length);

                return ms.ToArray();
            }
        }

        private bool Send(byte[] payload)
        {
            switch (_profile.ConnectionType)
            {
                case PrinterConnectionType.NetworkTcpIp:
                    return NetworkPrinterHelper.SendBytesToPrinter(_profile.NetworkIp, _profile.NetworkPort, payload, _profile.NetworkTimeoutMs);

                case PrinterConnectionType.LocalWindowsPrinter:
                default:
                    return RawPrinterHelper.SendBytesToPrinter(_profile.PrinterName, payload);
            }
        }
    }
}
