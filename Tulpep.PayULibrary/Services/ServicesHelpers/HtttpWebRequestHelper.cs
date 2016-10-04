using System.ComponentModel;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tulpep.PayULibrary.Services.ServicesHelpers
{
    public enum HttpMethod
    {
        [Description("NONE")]
        NONE = 0,
        [Description("POST")]
        POST = 1,
        [Description("GET")]
        GET = 2,
        [Description("PUT")]
        PUT = 3,
        [Description("DELETE")]
        DELETE = 4
    }

    public static class HtttpWebRequestHelper
    {
        private const int RetryAttempts = 3;
        private const double RetryDelaySeconds = 2;
#if DEBUG
        static readonly byte[] apiCertHash = { 0x8A, 0xF9, 0x38, 0x1E, 0xB5, 0x7E, 0x14, 0x2C, 0x4D, 0x8B, 0x26, 0x37, 0x30, 0x27, 0xF5, 0x94, 0x9D, 0xE5, 0x5D, 0x86 };
#else
        static readonly byte[] apiCertHash = { 0x71, 0x0c, 0x0a, 0x75, 0xc4, 0x88, 0xb4, 0x09, 0x35, 0x20, 0x12, 0x42, 0x05, 0xd0, 0x35, 0xe4, 0x90, 0x35, 0x97, 0x6f };
#endif
        
        private static bool ValidateServerCertficate(
                object sender,
                X509Certificate cert,
                X509Chain chain,
                SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            bool certMatch = false;
            byte[] certHash = cert.GetCertHash();
            if (certHash.Length == apiCertHash.Length)
            {
                certMatch = true; 
                for (int idx = 0; idx < certHash.Length; idx++)
                {
                    if (certHash[idx] != apiCertHash[idx])
                    {
                        certMatch = false; 
                        break;
                    }
                }
            }
            
            return certMatch;
        }


        public static async Task<HttpWebResponse> SendJSONToPayUGeneralApi(string url, string requestJson, HttpMethod httpMethod)
        {
            int RetryCount = 0;
            while (true)
            {
                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    /// <completionlist cref="SSL">
                    /// Add here the SSL certificate 
                    /// </completionlist>
                    ServicePointManager.ServerCertificateValidationCallback += ValidateServerCertficate;

                    req.ContentType = "application/json; charset=utf-8";
                    req.Accept = "application/json";
                    req.Method = httpMethod.ToString();

                    if ((httpMethod == HttpMethod.POST || httpMethod == HttpMethod.PUT) && requestJson != null)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                        req.ContentLength = bytes.Length;

                        using (System.IO.Stream os = await req.GetRequestStreamAsync())
                        {
                            os.Write(bytes, 0, bytes.Length);
                            os.Close();
                        }
                    }

                    return (HttpWebResponse)await req.GetResponseAsync();
                }
                catch
                {
                    RetryCount++;
                    if (RetryCount >= RetryAttempts)
                        throw;
                }
            }
        }

        public async static Task<HttpWebResponse> SendJSONToPayURecurringPaymentsApi(string url, string requestJson, string pLanguage,
            string base64, HttpMethod httpMethod)
        {
            int RetryCount = 0;
            while (true)
            {
                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    /// <completionlist cref="SSL">
                    /// Add here the SSL certificate 
                    /// </completionlist>
                    ServicePointManager.ServerCertificateValidationCallback += ValidateServerCertficate;
                    req.ContentType = "application/json; charset=utf-8";
                    req.Accept = "application/json";
                    req.Headers[HttpRequestHeader.AcceptLanguage] = pLanguage;
                    string _cred = string.Format("{0} {1}", "Basic", base64);
                    req.Headers[HttpRequestHeader.Authorization] = _cred;
                    req.Method = httpMethod.ToString();

                    if ((httpMethod == HttpMethod.POST || httpMethod == HttpMethod.PUT) && requestJson != null)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                        req.ContentLength = bytes.Length;
                        using (System.IO.Stream os = await req.GetRequestStreamAsync())
                        {
                            os.Write(bytes, 0, bytes.Length);
                            os.Close();
                        }
                    }
                    return (HttpWebResponse)await req.GetResponseAsync();
                }
                catch
                {
                    RetryCount++;
                    if (RetryCount >= RetryAttempts)
                        throw;
                }
            }
        }
    }
}
