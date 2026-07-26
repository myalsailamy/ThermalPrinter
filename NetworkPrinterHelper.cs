using System;
using System.Net.Sockets;

namespace ThermalReceiptPrinter
{
    /// <summary>
    /// يرسل بايتات خام إلى طابعة متصلة مباشرة بالشبكة (IP) عبر TCP Socket.
    /// المنفذ 9100 هو المنفذ القياسي لطابعات ESC/POS الشبكية (يُعرف أيضًا بـ RAW Printing Port / JetDirect).
    /// لا تحتاج الطابعة أن تكون مضافة كطابعة ويندوز في هذا الأسلوب.
    /// </summary>
    internal static class NetworkPrinterHelper
    {
        public static bool SendBytesToPrinter(string ipAddress, int port, byte[] bytes, int timeoutMs = 5000)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
                throw new ArgumentException("عنوان IP الخاص بالطابعة فارغ.", nameof(ipAddress));

            using (var client = new TcpClient())
            {
                IAsyncResult result = client.BeginConnect(ipAddress, port, null, null);
                bool connected = result.AsyncWaitHandle.WaitOne(timeoutMs);

                if (!connected)
                    throw new TimeoutException($"تعذر الاتصال بالطابعة الشبكية على {ipAddress}:{port} خلال {timeoutMs}ms. تأكد من العنوان ومن أن الطابعة على نفس الشبكة.");

                client.EndConnect(result);

                using (NetworkStream stream = client.GetStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
            }

            return true;
        }
    }
}
