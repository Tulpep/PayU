using System;
using System.ComponentModel;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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

            if ((httpMethod == HttpMethod.POST || httpMethod == HttpMethod.PUT) && requestJson != null)
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
            X509Store certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            certStore.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certCollection = certStore.Certificates.Find(
                                       X509FindType.FindByThumbprint,
                                       // Replace below with your cert's thumbprint
                                       "6443733097b0de9dfb7a79519dd70773406ef16b",
                                       false);
            // Get the first cert with the thumbprint
            if (certCollection.Count > 0)
            {
                X509Certificate2 cert = certCollection[0];

                req.ClientCertificates.Add(cert);

                certStore.Close();

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
                    using (System.IO.Stream os = req.GetRequestStream())
                    {
                        os.Write(bytes, 0, bytes.Length);
                        os.Close();
                    }
                }
                return (HttpWebResponse)req.GetResponse();
            }
            else
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(
                    delegate { return true; }
                    );
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
}
