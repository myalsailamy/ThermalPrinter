using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ThermalReceiptPrinter
{
    /// <summary>
    /// يحوّل صورة Bitmap إلى أمر صورة ESC/POS خام (GS v 0) يمكن إرساله مباشرة للطابعة
    /// (محليًا أو عبر الشبكة - الصيغة نفسها تعمل في الحالتين).
    /// هذا هو الأسلوب الأضمن لطباعة نص عربي مُشكَّل بشكل صحيح.
    /// </summary>
    internal static class EscPosImageConverter
    {
        public static byte[] ToRasterCommand(Bitmap bmp, int blackThreshold)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            int widthBytes = (width + 7) / 8;
            byte[] imageData = new byte[widthBytes * height];

            Bitmap working = bmp;
            bool disposeWorking = false;
            if (bmp.PixelFormat != PixelFormat.Format32bppArgb)
            {
                working = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                using (var g = Graphics.FromImage(working))
                    g.DrawImage(bmp, 0, 0, width, height);
                disposeWorking = true;
            }

            BitmapData data = working.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            try
            {
                int stride = data.Stride;
                byte[] pixels = new byte[stride * height];
                Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);

                for (int y = 0; y < height; y++)
                {
                    int rowOffset = y * stride;
                    for (int x = 0; x < width; x++)
                    {
                        int offset = rowOffset + x * 4; // BGRA
                        byte b = pixels[offset];
                        byte g = pixels[offset + 1];
                        byte r = pixels[offset + 2];
                        int gray = (r + g + b) / 3;

                        if (gray < blackThreshold)
                        {
                            int byteIndex = y * widthBytes + (x / 8);
                            int bitIndex = 7 - (x % 8);
                            imageData[byteIndex] |= (byte)(1 << bitIndex);
                        }
                    }
                }
            }
            finally
            {
                working.UnlockBits(data);
                if (disposeWorking) working.Dispose();
            }

            int xL = widthBytes % 256, xH = widthBytes / 256;
            int yL = height % 256, yH = height / 256;

            using (var ms = new MemoryStream())
            {
                ms.WriteByte(0x1D);
                ms.WriteByte(0x76);
                ms.WriteByte(0x30);
                ms.WriteByte(0x00);
                ms.WriteByte((byte)xL);
                ms.WriteByte((byte)xH);
                ms.WriteByte((byte)yL);
                ms.WriteByte((byte)yH);
                ms.Write(imageData, 0, imageData.Length);
                return ms.ToArray();
            }
        }
    }
}
