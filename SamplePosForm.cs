using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ThermalReceiptPrinter;

namespace ThermalReceiptPrinter.Demo
{
    public partial class SamplePosForm : Form
    {
        public SamplePosForm()
        {
            InitializeComponent();
        }

        private void SamplePosForm_Load(object sender, EventArgs e)
        {
            // قيم افتراضية عند فتح الشاشة
            rdoLocal.Checked = true;
            rdo58mm.Checked = true;
            chkAutoCut.Checked = true;

            loadPrinters();
            txtIp.Text = "192.168.1.50";        // عدّلها لعنوان IP طابعتك الشبكية
            txtPort.Text = "9100";

            UpdateConnectionFieldsState();
        }

        private void loadPrinters()
        {
            cmbPrinterName.Items.Clear();
            cmbPrinterName.Items.Add("XP-80C");
            foreach (string printerName in PrinterSettings.InstalledPrinters)
                cmbPrinterName.Items.Add(printerName);

            if (cmbPrinterName.Items.Count > 0)
                cmbPrinterName.SelectedIndex = 0;

        }
        private void ConnectionType_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConnectionFieldsState();
        }

        private void UpdateConnectionFieldsState()
        {
            bool isLocal = rdoLocal.Checked;
            cmbPrinterName.Enabled = isLocal;
            txtIp.Enabled = !isLocal;
            txtPort.Enabled = !isLocal;
            btnTestNetwork.Enabled = !isLocal;
        }

        // =====================================================================
        // معاينة الفاتورة على الشاشة قبل الطباعة الفعلية
        // =====================================================================
        private void BtnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                var printer = new ReceiptPrinter(BuildProfileFromUI());
                Image preview = printer.RenderPreview(BuildSampleReceipt());

                pbPreview.Image?.Dispose();
                pbPreview.Image = preview;
                pbPreview.Size = preview.Size;

                SetStatus("تم إنشاء المعاينة بنجاح.", Color.DarkGreen);
            }
            catch (Exception ex)
            {
                SetStatus("خطأ في المعاينة: " + ex.Message, Color.Firebrick);
            }
        }

        // =====================================================================
        // طباعة فعلية (محلية أو شبكية حسب الاختيار) - بدون أي واجهة طباعة تظهر
        // =====================================================================
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var printer = new ReceiptPrinter(BuildProfileFromUI());
                bool success = printer.Print(BuildSampleReceipt());

                SetStatus(success ? "تمت الطباعة بنجاح." : "فشلت الطباعة.",
                    success ? Color.DarkGreen : Color.Firebrick);
            }
            catch (Exception ex)
            {
                SetStatus("خطأ أثناء الطباعة: " + ex.Message, Color.Firebrick);
            }
        }

        // =====================================================================
        // اختبار أن الطابعة تدعم القص الآلي
        // =====================================================================
        private void BtnTestCut_Click(object sender, EventArgs e)
        {
            try
            {
                var printer = new ReceiptPrinter(BuildProfileFromUI());
                bool success = printer.TestCut();
                SetStatus(success ? "تم إرسال أمر القص - راقب الطابعة." : "فشل إرسال أمر القص.",
                    success ? Color.DarkGreen : Color.Firebrick);
            }
            catch (Exception ex)
            {
                SetStatus("خطأ: " + ex.Message, Color.Firebrick);
            }
        }

        // =====================================================================
        // اختبار الاتصال بالطابعة الشبكية فقط (بدون طباعة فعلية)
        // =====================================================================
        private void BtnTestNetwork_Click(object sender, EventArgs e)
        {
            try
            {
                var printer = new ReceiptPrinter(BuildProfileFromUI());
                bool success = printer.TestNetworkConnection();
                SetStatus(success ? "الاتصال بالطابعة الشبكية ناجح." : "تعذر الاتصال.",
                    success ? Color.DarkGreen : Color.Firebrick);
            }
            catch (Exception ex)
            {
                SetStatus("خطأ في الاتصال: " + ex.Message, Color.Firebrick);
            }
        }

        // =====================================================================
        // بناء إعدادات الطابعة من قيم الشاشة الحالية
        // =====================================================================
        private PrinterProfile BuildProfileFromUI()
        {
            var profile = new PrinterProfile
            {
                ConnectionType = rdoLocal.Checked
                    ? PrinterConnectionType.LocalWindowsPrinter
                    : PrinterConnectionType.NetworkTcpIp,
                PrinterName = cmbPrinterName.SelectedItem?.ToString() ?? string.Empty,
                NetworkIp = txtIp.Text.Trim(),
                NetworkPort = int.TryParse(txtPort.Text.Trim(), out int port) ? port : 9100,
                WidthType = rdo58mm.Checked ? PaperWidthType.Mm58 : PaperWidthType.Mm80,
                AutoCut = chkAutoCut.Checked,

                // -------------------------------------------

                TitleFamily = string.IsNullOrWhiteSpace(cmboBxTitle.Text) ? "Tahoma" : cmboBxTitle.Text.Trim(),
                TitleFontSize = (float)numBxTite.Value >= 8 ? (float)numBxTite.Value : 9f,
                FontArFamily = string.IsNullOrWhiteSpace(cmboBxArName.Text) ? "Tahoma" : cmboBxArName.Text.Trim(),
                NormalArFontSize = (float)numBxArName.Value >= 8 ? (float)numBxArName.Value : 9f,
                FontEnFamily = string.IsNullOrWhiteSpace(cmboBxEnName.Text) ? "Tahoma" : cmboBxEnName.Text.Trim(),
                NormalEnFontSize = (float)numBxEnName.Value >= 8 ? (float)numBxEnName.Value : 9f,
                NumberFontFamily = string.IsNullOrWhiteSpace(cmboBxNumber.Text) ? "Tahoma" : cmboBxNumber.Text.Trim(),
                NumberFontSize = (float)numBxNumber.Value >= 8 ? (float)numBxNumber.Value : 9f,
                FontFamily = string.IsNullOrWhiteSpace(cmboBxGeneral.Text) ? "Tahoma" : cmboBxGeneral.Text.Trim(),
                NormalFontSize = (float)numBxGeneral.Value >= 8 ? (float)numBxGeneral.Value : 9f,

            };
            return profile;
        }

        // =====================================================================
        // فاتورة تجريبية بنفس التصميم ثنائي اللغة
        // =====================================================================
        private ReceiptModel BuildSampleReceipt()
        {
            var receipt = new ReceiptModel
            {
                CompanyNameAr = "المؤسسة التجارية الحديثة",
                CompanyNameEn = "Modern Trading Establishment",
                TaxNumber = "300123456700003",
                CommercialRegister = "1010123456",

                InvoiceNumber = "INV-000125",
                CashierName = "أحمد",
                CustomerName = "نقداً",

                ReturnPolicyAr = "يسمح بالاسترجاع خلال 7 أيام وفقاً لشروط وأحكام المتجر.",
                Address = "الرياض - حي العليا",
                Phone = "0112345678",
                WhatsApp = "0551234567",
                Email = "info@company.com",
                Website = "www.company.com",
                SocialMediaLine = "Facebook | Instagram | X"
            };

            receipt.Items.Add(new ReceiptItem { NameAr = "أرز بسمتي 5 كجم", NameEn = "Basmati Rice 5KG", Quantity = 2, UnitPrice = 45.00m });
            receipt.Items.Add(new ReceiptItem { NameAr = "زيت دوار الشمس 1.8 لتر", NameEn = "Sunflower Oil 1.8L", Quantity = 1, UnitPrice = 28.50m });
            receipt.Items.Add(new ReceiptItem { NameAr = "شاي أحمر فاخر", NameEn = "Premium Black Tea", Quantity = 3, UnitPrice = 12.00m });
            receipt.Items.Add(new ReceiptItem { NameAr = "تجربة طباعة نص طويل من أجل فحص قدرة الفاتورة على النزول سطر في حال كان السطر طويل", NameEn = "Premium Black Tea", Quantity = 3, UnitPrice = 12.00m });

            receipt.VatAmount = Math.Round(receipt.SubtotalBeforeVat * 0.15m, 2);
            return receipt;
        }

        private void SetStatus(string message, Color color)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = color;
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                sfd.FileName = "Image";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    SavePictureBoxImage(pbPreview, sfd.FileName, 100);

                    MessageBox.Show("تم حفظ الصورة بنجاح.");
                }
            }
        }


        /// <summary>
        /// حفظ صورة PictureBox إلى ملف.
        /// يدعم PNG و JPG مع تحديد جودة JPG.
        /// </summary>
        /// <param name="pictureBox">عنصر PictureBox</param>
        /// <param name="filePath">المسار الكامل للحفظ</param>
        /// <param name="jpegQuality">جودة JPEG من 0 إلى 100</param>
        public void SavePictureBoxImage(PictureBox pictureBox, string filePath, long jpegQuality = 100L)
        {
            if (pictureBox == null)
                throw new ArgumentNullException(nameof(pictureBox));

            if (pictureBox.Image == null)
                throw new InvalidOperationException("لا توجد صورة داخل PictureBox.");

            string ext = Path.GetExtension(filePath).ToLowerInvariant();

            switch (ext)
            {
                case ".png":
                    pictureBox.Image.Save(filePath, ImageFormat.Png);
                    break;

                case ".bmp":
                    pictureBox.Image.Save(filePath, ImageFormat.Bmp);
                    break;

                case ".gif":
                    pictureBox.Image.Save(filePath, ImageFormat.Gif);
                    break;

                case ".jpg":
                case ".jpeg":
                    ImageCodecInfo jpgEncoder = ImageCodecInfo.GetImageEncoders()
                        .First(c => c.FormatID == ImageFormat.Jpeg.Guid);

                    using (EncoderParameters encoderParams = new EncoderParameters(1))
                    {
                        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                        pictureBox.Image.Save(filePath, jpgEncoder, encoderParams);
                    }
                    break;

                default:
                    throw new NotSupportedException("صيغة الملف غير مدعومة.");
            }
        }
    }
}
