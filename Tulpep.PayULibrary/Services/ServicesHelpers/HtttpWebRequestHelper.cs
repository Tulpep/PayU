using System.ComponentModel;
using System.Net;
using System.Net.Security;
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
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

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
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
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
