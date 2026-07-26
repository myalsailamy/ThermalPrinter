namespace ThermalReceiptPrinter
{
    /// <summary>
    /// أوامر ESC/POS القياسية المدعومة من الغالبية العظمى من طابعات الفواتير الحرارية
    /// (Epson TM-T20/T88، Xprinter، Gprinter، RONGTA... إلخ) سواء المحلية أو الشبكية.
    /// </summary>
    internal static class EscPos
    {
        /// <summary>تهيئة الطابعة لإعداداتها الافتراضية.</summary>
        public static readonly byte[] Init = { 0x1B, 0x40 };

        /// <summary>قص كامل للورق (Full Cut). يعمل فقط إذا كانت الطابعة تدعم قصّاصة آلية.</summary>
        public static readonly byte[] FullCut = { 0x1D, 0x56, 0x00 };

        /// <summary>قص جزئي (Partial Cut) - يترك جزءًا صغيرًا غير مقصوص.</summary>
        public static readonly byte[] PartialCut = { 0x1D, 0x56, 0x01 };

        /// <summary>فتح درج الكاش المتصل بالطابعة (Cash Drawer Kick - Pin 2).</summary>
        public static readonly byte[] OpenCashDrawer = { 0x1B, 0x70, 0x00, 0x19, 0xFA };

        /// <summary>أمر تغذية عدد أسطر معيّن قبل القص (لتفادي قص النص مباشرة).</summary>
        public static byte[] FeedLines(byte lines) => new byte[] { 0x1B, 0x64, lines };
    }
}
