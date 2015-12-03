using System.ComponentModel;
using System.Net;
using System.Text;

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
        public static HttpWebResponse SendJSONToPayUGeneralApi(string url, string requestJson, HttpMethod httpMethod)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            /// <completionlist cref="SSL">
            /// Add here the SSL certificate 
            /// </completionlist>
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            req.ContentType = "application/json; charset=utf-8";
            req.Accept = "application/json";
            req.Method = httpMethod.ToString();

            if (httpMethod == HttpMethod.POST && requestJson != null)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                req.ContentLength = bytes.Length;

                using (System.IO.Stream os = req.GetRequestStream())
                {
                    os.Write(bytes, 0, bytes.Length);
                    os.Close();
                }
            }

            return (HttpWebResponse)req.GetResponse();
        }

        public static HttpWebResponse SendJSONToPayURecurringPaymentsApi(string url, string requestJson, string pLanguage,
            string base64, HttpMethod httpMethod)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            /// <completionlist cref="SSL">
            /// Add here the SSL certificate 
            /// </completionlist>
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            req.ContentType = "application/json; charset=utf-8";
            req.Accept = "application/json";
            req.Headers[HttpRequestHeader.AcceptLanguage] = pLanguage;
            string _cred = string.Format("{0} {1}", "Basic", base64);
            req.Headers[HttpRequestHeader.Authorization] = _cred;
            req.Method = httpMethod.ToString();

            if (httpMethod == HttpMethod.POST && requestJson != null)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                req.ContentLength = bytes.Length;
                using (System.IO.Stream os = req.GetRequestStream())
                {
                    os.Write(bytes, 0, bytes.Length);
                    os.Close();
                }
            }

            return (HttpWebResponse)req.GetResponse();
        }
    }
}
