using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ThermalReceiptPrinter
{
    /// <summary>
    /// يرسم الفاتورة بالكامل كصورة واحدة (Bitmap) بطول ديناميكي حسب عدد الأصناف،
    /// بتصميم ثنائي اللغة (عربي/إنجليزي) مطابق لنموذج فاتورة ضريبية احترافي.
    /// </summary>
    internal static class ReceiptRenderer
    {
        private const int WorkingHeightPx = 20000;

        public static Bitmap Render(ReceiptModel receipt, PrinterProfile profile)
        {
            int widthPx = profile.GetWidthPixels();
            int margin = profile.MarginPx;

            using (Font titleFont = new Font(profile.TitleFamily, profile.TitleFontSize, FontStyle.Bold))
            using (Font subTitleFont = new Font(profile.FontArFamily, profile.SubTitleFontSize, FontStyle.Bold))
            using (Font boldFont = new Font(profile.FontArFamily, profile.NormalFontSize, FontStyle.Bold))
            using (Font normalArFont = new Font(profile.FontArFamily, profile.NormalArFontSize, FontStyle.Bold))
            using (Font normalEnFont = new Font(profile.FontEnFamily, profile.NormalEnFontSize, FontStyle.Regular))
            using (Font numberFont = new Font(profile.NumberFontFamily, profile.NumberFontSize, FontStyle.Bold))
            using (Font grandTotalFont = new Font(profile.TitleFamily, profile.TitleFontSize, FontStyle.Bold))
            using (Bitmap working = new Bitmap(widthPx, WorkingHeightPx, PixelFormat.Format32bppArgb))
            {
                working.SetResolution(profile.Dpi, profile.Dpi);
                int y = margin;

                using (Graphics g = Graphics.FromImage(working))
                {

                    g.Clear(Color.White);
                    g.SmoothingMode = SmoothingMode.None;              // لا تنعيم للخطوط/الحدود
                    g.TextRenderingHint = TextRenderingHint.AntiAlias; // نص حاد بلا Anti-Alias | SingleBitPerPixelGridFit
                    g.InterpolationMode = InterpolationMode.NearestNeighbor; // مهم فقط عند رسم صور/شعار/باركود
                    g.PixelOffsetMode = PixelOffsetMode.None;
                    g.CompositingQuality = CompositingQuality.HighQuality;

                    //g.Clear(Color.White);
                    //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    // ===== شعار =====
                    if (receipt.Logo != null)
                    {
                        int logoW = Math.Min(receipt.Logo.Width, widthPx - margin * 2);
                        int logoH = (int)((double)receipt.Logo.Height * logoW / receipt.Logo.Width);
                        g.DrawImage(receipt.Logo, (widthPx - logoW) / 2, y, logoW, logoH);
                        y += logoH + 6;
                    }

                    y = DrawSolidLine(g, y, widthPx, margin);

                    // ===== بيانات الشركة =====
                    y = DrawCenter(g, receipt.CompanyNameAr, titleFont, widthPx, y);
                    y = DrawCenter(g, receipt.CompanyNameEn, subTitleFont, widthPx, y);
                    if (!string.IsNullOrEmpty(receipt.TaxNumber))
                        y = DrawCenter(g, "الرقم الضريبي: " + receipt.TaxNumber, numberFont, widthPx, y);
                    if (!string.IsNullOrEmpty(receipt.CommercialRegister))
                        y = DrawCenter(g, "السجل التجاري: " + receipt.CommercialRegister, numberFont, widthPx, y);

                    y += 3;
                    y = DrawCenter(g, $"***** {receipt.InvoiceTitleAr} *****", boldFont, widthPx, y);
                    y = DrawCenter(g, receipt.InvoiceTitleEn, normalArFont, widthPx, y);

                    y = DrawSolidLine(g, y, widthPx, margin);

                    // ===== بيانات الفاتورة =====
                    y = DrawRow(g, "رقم الفاتورة", receipt.InvoiceNumber, normalArFont, margin, widthPx, y);
                    y = DrawRow(g, "التاريخ", receipt.DateTime.ToString("dd/MM/yyyy hh:mm tt"), normalArFont, margin, widthPx, y);
                    if (!string.IsNullOrEmpty(receipt.CashierName))
                        y = DrawRow(g, "الكاشير", receipt.CashierName, normalArFont, margin, widthPx, y);
                    if (!string.IsNullOrEmpty(receipt.CustomerName))
                        y = DrawRow(g, "العميل", receipt.CustomerName, normalArFont, margin, widthPx, y);

                    y = DrawSolidLine(g, y, widthPx, margin);

                    // ===== جدول الأصناف =====
                    var cols = new ItemColumns(widthPx, margin);
                    y = cols.DrawHeader(g, boldFont, y);
                    y = DrawDashedLine(g, y, widthPx, margin);

                    foreach (var item in receipt.Items)
                        y = cols.DrawRow(g, item, normalArFont, normalEnFont, numberFont, y);

                    y = DrawDashedLine(g, y, widthPx, margin);
                    y += 2;

                    // ===== ملخص الأصناف =====
                    y = DrawRow(g, "عدد الأصناف", receipt.ItemCount.ToString(), normalArFont, margin, widthPx, y);
                    y = DrawRow(g, "إجمالي الكمية", receipt.TotalQuantity.ToString("0.##"), normalArFont, margin, widthPx, y);

                    y += 2;
                    y = DrawRow(g, "الإجمالي قبل الضريبة", receipt.SubtotalBeforeVat.ToString("N2"), normalArFont, margin, widthPx, y);
                    y = DrawRow(g, "ضريبة القيمة المضافة", receipt.VatAmount.ToString("N2"), normalArFont, margin, widthPx, y);

                    y = DrawDashedLine(g, y, widthPx, margin);

                    // ===== الإجمالي النهائي =====
                    y = DrawRow(g, "الإجمالي النهائي", $"{receipt.GrandTotal:N2} {receipt.CurrencySymbol}", grandTotalFont, margin, widthPx, y);

                    y = DrawSolidLine(g, y, widthPx, margin);

                    // ===== تذييل =====
                    y += 2;
                    y = DrawCenter(g, receipt.FooterThanksAr, boldFont, widthPx, y);
                    y = DrawCenter(g, receipt.FooterThanksEn, normalArFont, widthPx, y);

                    if (!string.IsNullOrEmpty(receipt.ReturnPolicyAr))
                    {
                        y += 4;
                        y = DrawCenter(g, "سياسة الاسترجاع:", numberFont, widthPx, y);
                        y = DrawCenter(g, receipt.ReturnPolicyAr, numberFont, widthPx, y);
                        if (!string.IsNullOrEmpty(receipt.ReturnPolicyEn))
                            y = DrawCenter(g, receipt.ReturnPolicyEn, numberFont, widthPx, y);
                    }

                    bool hasContact = !string.IsNullOrEmpty(receipt.Address) || !string.IsNullOrEmpty(receipt.Phone)
                        || !string.IsNullOrEmpty(receipt.WhatsApp) || !string.IsNullOrEmpty(receipt.Email) || !string.IsNullOrEmpty(receipt.Website);

                    if (hasContact)
                    {
                        y += 2;
                        if (!string.IsNullOrEmpty(receipt.Address)) y = DrawCenter(g, "العنوان: " + receipt.Address, numberFont, widthPx, y);
                        if (!string.IsNullOrEmpty(receipt.Phone)) y = DrawCenter(g, "الهاتف: " + receipt.Phone, numberFont, widthPx, y);
                        if (!string.IsNullOrEmpty(receipt.WhatsApp)) y = DrawCenter(g, "واتساب: " + receipt.WhatsApp, numberFont, widthPx, y);
                        if (!string.IsNullOrEmpty(receipt.Email)) y = DrawCenter(g, "البريد الإلكتروني: " + receipt.Email, numberFont, widthPx, y);
                        if (!string.IsNullOrEmpty(receipt.Website)) y = DrawCenter(g, "الموقع الإلكتروني: " + receipt.Website, numberFont, widthPx, y);
                    }

                    if (!string.IsNullOrEmpty(receipt.SocialMediaLine))
                    {
                        y = DrawSolidLine(g, y, widthPx, margin);
                        y = DrawCenter(g, "تابعنا: " + receipt.SocialMediaLine, numberFont, widthPx, y);
                    }

                    y = DrawSolidLine(g, y, widthPx, margin);
                    y += 2;
                    y = DrawCenter(g, receipt.FarewellAr, normalArFont, widthPx, y);
                    y = DrawCenter(g, receipt.FarewellEn, normalEnFont, widthPx, y);

                    y = DrawSolidLine(g, y, widthPx, margin);
                    y += margin;
                }

                int finalHeight = Math.Min(y, WorkingHeightPx);
                return working.Clone(new Rectangle(0, 0, widthPx, finalHeight), PixelFormat.Format32bppArgb);
            }
        }

        private static TextFormatFlags BaseFlags => TextFormatFlags.WordBreak | TextFormatFlags.RightToLeft;

        private static int DrawCenter(Graphics g, string text, Font font, int widthPx, int y)
        {
            if (string.IsNullOrEmpty(text)) return y;
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | BaseFlags;
            Size size = TextRenderer.MeasureText(g, text, font, new Size(widthPx, int.MaxValue), flags);
            Rectangle rect = new Rectangle(0, y, widthPx, size.Height);
            TextRenderer.DrawText(g, text, font, rect, Color.Black, flags);
            return y + size.Height + 2;
        }

        private static int DrawRow(Graphics g, string label, string value, Font font, int margin, int widthPx, int y)
        {
            int contentWidth = widthPx - margin * 2;
            int colWidth = contentWidth / 2;

            TextFormatFlags labelFlags = TextFormatFlags.Right | TextFormatFlags.RightToLeft | TextFormatFlags.WordBreak;
            TextFormatFlags valueFlags = TextFormatFlags.Left | TextFormatFlags.WordBreak;

            Size labelSize = TextRenderer.MeasureText(g, label ?? "", font, new Size(colWidth, int.MaxValue), labelFlags);
            Size valueSize = TextRenderer.MeasureText(g, value ?? "", font, new Size(colWidth, int.MaxValue), valueFlags);
            int rowHeight = Math.Max(labelSize.Height, valueSize.Height);

            Rectangle labelRect = new Rectangle(widthPx - margin - colWidth, y, colWidth, rowHeight);
            Rectangle valueRect = new Rectangle(margin, y, colWidth, rowHeight);

            TextRenderer.DrawText(g, label ?? "", font, labelRect, Color.Black, labelFlags);
            TextRenderer.DrawText(g, value ?? "", font, valueRect, Color.Black, valueFlags);

            return y + rowHeight + 3;
        }

        private static int DrawDashedLine(Graphics g, int y, int widthPx, int margin)
        {
            using (var pen = new Pen(Color.Black, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                g.DrawLine(pen, margin, y, widthPx - margin, y);
            return y + 4;
        }

        private static int DrawSolidLine(Graphics g, int y, int widthPx, int margin)
        {
            using (var pen = new Pen(Color.Black, 2))
                g.DrawLine(pen, margin, y, widthPx - margin, y);
            return y + 5;
        }

        /// <summary>أعمدة جدول الأصناف: الصنف/Item (مع سطر إنجليزي اختياري) / كمية / سعر / إجمالي.</summary>
        private class ItemColumns
        {
            private readonly Rectangle _nameArea, _qtyArea, _priceArea, _totalArea;

            public ItemColumns(int widthPx, int margin)
            {
                int contentWidth = widthPx - margin * 2;

                int qtyW = (int)(contentWidth * 0.15);
                int priceW = (int)(contentWidth * 0.22);
                int totalW = (int)(contentWidth * 0.25);
                int nameW = contentWidth - qtyW - priceW - totalW;

                int xName = widthPx - margin - nameW;
                int xQty = xName - qtyW;
                int xPrice = xQty - priceW;
                int xTotal = margin;

                _nameArea = new Rectangle(xName, 0, nameW, 0);
                _qtyArea = new Rectangle(xQty, 0, qtyW, 0);
                _priceArea = new Rectangle(xPrice, 0, priceW, 0);
                _totalArea = new Rectangle(xTotal, 0, totalW, 0);
            }

            public int DrawHeader(Graphics g, Font font, int y)
            {
                int h = TextRenderer.MeasureText(g, "الصنف", font).Height;
                DrawCell(g, "الصنف / Item", font, _nameArea, y, h, TextFormatFlags.Right | TextFormatFlags.RightToLeft);
                DrawCell(g, "الكمية", font, _qtyArea, y, h, TextFormatFlags.HorizontalCenter);
                DrawCell(g, "السعر", font, _priceArea, y, h, TextFormatFlags.HorizontalCenter);
                DrawCell(g, "الإجمالي", font, _totalArea, y, h, TextFormatFlags.HorizontalCenter);
                return y + h + 3;
            }

            public int DrawRow(Graphics g, ReceiptItem item, Font fontAr, Font fontEn, Font numberFont, int y)
            {
                TextFormatFlags nameFlags = TextFormatFlags.Right | TextFormatFlags.RightToLeft | TextFormatFlags.WordBreak;
                TextFormatFlags nameEnFlags = TextFormatFlags.Left | TextFormatFlags.WordBreak;

                Size nameArSize = TextRenderer.MeasureText(g, item.NameAr ?? "", fontAr, new Size(_nameArea.Width, int.MaxValue), nameFlags);
                Size nameEnSize = string.IsNullOrEmpty(item.NameEn)
                    ? Size.Empty
                    : TextRenderer.MeasureText(g, item.NameEn, fontEn, new Size(_nameArea.Width, int.MaxValue), nameEnFlags);

                int nameBlockHeight = nameArSize.Height + (nameEnSize.Height > 0 ? nameEnSize.Height + 1 : 0);
                int minRowHeight = TextRenderer.MeasureText(g, "0", fontAr).Height;
                int rowHeight = Math.Max(nameBlockHeight, minRowHeight);

                // اسم الصنف بالعربي ثم الإنجليزي أسفله
                Rectangle nameArRect = new Rectangle(_nameArea.X, y, _nameArea.Width, nameArSize.Height);
                TextRenderer.DrawText(g, item.NameAr ?? "", fontAr, nameArRect, Color.Black, nameFlags | TextFormatFlags.WordBreak);

                if (nameEnSize.Height > 0)
                {
                    Rectangle nameEnRect = new Rectangle(_nameArea.X, y + nameArSize.Height + 1, _nameArea.Width, nameEnSize.Height);
                    TextRenderer.DrawText(g, item.NameEn, fontEn, nameEnRect, Color.DimGray, nameEnFlags | TextFormatFlags.WordBreak);
                }

                DrawCell(g, item.Quantity.ToString("0.##"), numberFont, _qtyArea, y, rowHeight, TextFormatFlags.HorizontalCenter);
                DrawCell(g, item.UnitPrice.ToString("N2"), numberFont, _priceArea, y, rowHeight, TextFormatFlags.HorizontalCenter);
                DrawCell(g, item.LineTotal.ToString("N2"), numberFont, _totalArea, y, rowHeight, TextFormatFlags.HorizontalCenter);

                return y + rowHeight + 4;
            }

            private void DrawCell(Graphics g, string text, Font font, Rectangle area, int y, int height, TextFormatFlags flags)
            {
                Rectangle rect = new Rectangle(area.X, y, area.Width, height);
                TextRenderer.DrawText(g, text, font, rect, Color.Black, flags | TextFormatFlags.WordBreak);
            }
        }
    }
}
