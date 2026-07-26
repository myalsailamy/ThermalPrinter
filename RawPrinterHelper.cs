using System;
using System.Runtime.InteropServices;

namespace ThermalReceiptPrinter
{
    /// <summary>
    /// يرسل بايتات خام (RAW) مباشرة إلى طابعة ويندوز محلية عبر winspool.drv
    /// (مناسب لطابعة متصلة بالجهاز عبر USB أو مضافة كطابعة مشتركة على الشبكة عبر ويندوز).
    /// </summary>
    internal static class RawPrinterHelper
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] ref DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        public static bool SendBytesToPrinter(string printerName, byte[] bytes)
        {
            if (string.IsNullOrWhiteSpace(printerName))
                throw new ArgumentException("اسم الطابعة فارغ - يجب تحديد اسم الطابعة كما يظهر في ويندوز.", nameof(printerName));

            IntPtr hPrinter = IntPtr.Zero;
            IntPtr pBytes = IntPtr.Zero;
            bool success = false;

            var di = new DOCINFOA
            {
                pDocName = "Thermal Receipt",
                pOutputFile = null,
                pDataType = "RAW"
            };

            try
            {
                if (!OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
                    throw new InvalidOperationException($"تعذر فتح الطابعة '{printerName}'. تأكد من الاسم ومن أنها مثبتة في ويندوز. (Win32 error: {Marshal.GetLastWin32Error()})");

                if (!StartDocPrinter(hPrinter, 1, ref di))
                    throw new InvalidOperationException($"تعذر بدء مهمة طباعة على '{printerName}'. (Win32 error: {Marshal.GetLastWin32Error()})");

                if (!StartPagePrinter(hPrinter))
                    throw new InvalidOperationException("تعذر بدء صفحة الطباعة.");

                pBytes = Marshal.AllocCoTaskMem(bytes.Length);
                Marshal.Copy(bytes, 0, pBytes, bytes.Length);

                success = WritePrinter(hPrinter, pBytes, bytes.Length, out int written);
                if (success && written != bytes.Length)
                    success = false;

                EndPagePrinter(hPrinter);
                EndDocPrinter(hPrinter);
            }
            finally
            {
                if (pBytes != IntPtr.Zero) Marshal.FreeCoTaskMem(pBytes);
                if (hPrinter != IntPtr.Zero) ClosePrinter(hPrinter);
            }

            return success;
        }
    }
}
