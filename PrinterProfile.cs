using System;

namespace ThermalReceiptPrinter
{
    public enum PaperWidthType
    {
        Mm58,
        Mm80,
        Custom
    }

    /// <summary>نوع الاتصال بالطابعة.</summary>
    public enum PrinterConnectionType
    {
        /// <summary>طابعة مثبتة في ويندوز (USB مباشر أو مشتركة على الشبكة عبر ويندوز).</summary>
        LocalWindowsPrinter,

        /// <summary>طابعة متصلة مباشرة بالشبكة عبر عنوان IP (بدون تثبيتها في ويندوز).</summary>
        NetworkTcpIp
    }

    /// <summary>
    /// كل الإعدادات القابلة للتحكم لطابعة الفواتير الحرارية، محليًا كانت أو عبر الشبكة.
    /// </summary>
    public class PrinterProfile
    {
        // ---------- إعدادات الاتصال ----------

        /// <summary>نوع الاتصال: طابعة محلية مثبتة في ويندوز، أو طابعة شبكية عبر IP.</summary>
        public PrinterConnectionType ConnectionType { get; set; } = PrinterConnectionType.LocalWindowsPrinter;

        /// <summary>[محلي] اسم الطابعة كما يظهر بالضبط في "الأجهزة والطابعات" بويندوز.</summary>
        public string PrinterName { get; set; }

        /// <summary>[شبكي] عنوان IP الخاص بالطابعة، مثال: 192.168.1.50</summary>
        public string NetworkIp { get; set; }

        /// <summary>[شبكي] منفذ الطباعة الخام - القياسي هو 9100 لدى أغلب طابعات ESC/POS.</summary>
        public int NetworkPort { get; set; } = 9100;

        /// <summary>[شبكي] مهلة الاتصال بالمللي ثانية.</summary>
        public int NetworkTimeoutMs { get; set; } = 5000;

        // ---------- إعدادات الورق والطباعة ----------

        public PaperWidthType WidthType { get; set; } = PaperWidthType.Mm80;

        /// <summary>يُستخدم فقط عند اختيار PaperWidthType.Custom.</summary>
        public int CustomWidthMm { get; set; } = 80;

        /// <summary>دقة الطابعة بالنقطة/إنش. الأغلبية 203dpi، بعض القديم 180dpi.</summary>
        public int Dpi { get; set; } = 203;

        public int MarginPx { get; set; } = 6;

        public bool AutoCut { get; set; } = true;

        public byte FeedLinesBeforeCut { get; set; } = 3;

        public bool OpenCashDrawerAfterPrint { get; set; } = false;

        /// <summary>عتبة تحويل اللون إلى أسود عند تحويل الصورة (0-255).</summary>
        public int BlackThreshold { get; set; } = 160;

        // ---------- إعدادات الخطوط ----------

        public string FontFamily { get; set; } = "Tahoma";
        public float TitleFontSize { get; set; } = 13f;
        public float SubTitleFontSize { get; set; } = 10.5f;
        public float NormalFontSize { get; set; } = 9.5f;
        public float SmallFontSize { get; set; } = 8f;

        public int GetWidthMm()
        {
            switch (WidthType)
            {
                case PaperWidthType.Mm58: return 58;
                case PaperWidthType.Mm80: return 80;
                default: return CustomWidthMm;
            }
        }

        public int GetWidthPixels()
        {
            double inches = GetWidthMm() / 25.4;
            return (int)Math.Round(inches * Dpi);
        }
    }
}
