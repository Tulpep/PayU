using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Request.Request_PayUQueries.Ping;
using Tulpep.PayULibrary.Models.Request.Request_PayUQueries.QueryOrderByIdentifier;
using Tulpep.PayULibrary.Models.Request.Request_PayUQueries.QueryOrderByReference;
using Tulpep.PayULibrary.Models.Request.Request_PayUQueries.TransactionResponseQuery;
using Tulpep.PayULibrary.Models.Response.Response_PayUQueries.Ping;
using Tulpep.PayULibrary.Models.Response.Response_PayUQueries.QueryOrderByIdentifier;
using Tulpep.PayULibrary.Models.Response.Response_PayUQueries.QueryOrderByReference;
using Tulpep.PayULibrary.Models.Response.Response_PayUQueries.TransactionResponseQuery;
using Tulpep.PayULibrary.Services.ServicesHelpers;

namespace Tulpep.PayULibrary.Services.QueriesService
{
    public static class QueriesService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTest"></param>
        /// <param name="pCommand"></param>
        /// <param name="pLanguage"></param>
        /// <param name="productionOrTestApiKey"></param>
        /// <param name="productionOrTestApiLogIn"></param>
        /// <param name="productionOrTestUrl"></param>
        /// <returns></returns>
        public static RootPayUQueriesPingResponse PingTheApi(bool isTest, string pCommand, string pLanguage,
            string productionOrTestApiKey, string productionOrTestApiLogIn, string productionOrTestUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productionOrTestApiKey))
                {
                    productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];
                }

                if (string.IsNullOrWhiteSpace(productionOrTestApiLogIn))
                {
                    productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];
                }
            }
            catch (Exception)
            {
                throw;
            }

            var url = productionOrTestUrl;
            if (url != null)
            {
                var jsonObject = new RootPayUQueriesPingRequest()
                {
                    command = pCommand,
                    language = pLanguage,
                    merchant = new Merchant()
                    {
                        apiKey = productionOrTestApiKey,
                        apiLogin = productionOrTestApiLogIn
                    },
                    test = isTest
                };

                string requestJson = JsonConvert.SerializeObject(jsonObject);

                try
                {
                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayUGeneralApi(url, requestJson, HttpMethod.POST);
                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                        string res = sr.ReadToEnd();
                        var des = JsonConvert.DeserializeObject<RootPayUQueriesPingResponse>(res);
                        if (des != null)
                        {
                            return des;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTest"></param>
        /// <param name="pCommand"></param>
        /// <param name="pLanguage"></param>
        /// <param name="productionOrTestApiKey"></param>
        /// <param name="productionOrTestApiLogIn"></param>
        /// <param name="pOrderId"></param>
        /// <param name="productionOrTestUrl"></param>
        /// <returns></returns>
        public static RootPayUQueryOrderByIdResponse GetOrderById(bool isTest, string pCommand, string pLanguage,
            string productionOrTestApiKey, string productionOrTestApiLogIn, int pOrderId, string productionOrTestUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productionOrTestApiKey))
                {
                    productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];
                }

                if (string.IsNullOrWhiteSpace(productionOrTestApiLogIn))
                {
                    productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];
                }
            }
            catch (Exception)
            {
                throw;
            }

            var url = productionOrTestUrl;
            if (url != null)
            {
                var jsonObject = new RootPayUQueryOrderByIdRequest()
                {
                    command = pCommand,
                    language = pLanguage,
                    merchant = new Merchant()
                    {
                        apiKey = productionOrTestApiKey,
                        apiLogin = productionOrTestApiLogIn
                    },
                    test = isTest,
                    details = new Request_QueryOrderByIdentifier_Details()
                    {
                        orderId = pOrderId
                    }
                };

                string requestJson = JsonConvert.SerializeObject(jsonObject);

                try
                {
                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayUGeneralApi(url, requestJson, HttpMethod.POST);
                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                        string res = sr.ReadToEnd();
                        var des = JsonConvert.DeserializeObject<RootPayUQueryOrderByIdResponse>(res);
                        if (des != null)
                        {
                            return des;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTest"></param>
        /// <param name="pCommand"></param>
        /// <param name="pLanguage"></param>
        /// <param name="productionOrTestApiKey"></param>
        /// <param name="productionOrTestApiLogIn"></param>
        /// <param name="pOrderReferenceCode"></param>
        /// <param name="productionOrTestUrl"></param>
        /// <returns></returns>
        public static RootPayUQueryOrderByRefResponse GetOrderByReferenceCode(bool isTest, string pCommand, string pLanguage,
            string productionOrTestApiKey, string productionOrTestApiLogIn, string pOrderReferenceCode, string productionOrTestUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productionOrTestApiKey))
                {
                    productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];
                }

                if (string.IsNullOrWhiteSpace(productionOrTestApiLogIn))
                {
                    productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];
                }
            }
            catch (Exception)
            {
                throw;
            }

            var url = productionOrTestUrl;
            if (url != null)
            {
                var jsonObject = new RootPayUQueryOrderByRefRequest()
                {
                    command = pCommand,
                    language = pLanguage,
                    merchant = new Merchant()
                    {
                        apiKey = productionOrTestApiKey,
                        apiLogin = productionOrTestApiLogIn
                    },
                    test = isTest,
                    details = new Request_QueryOrderByReference_Details()
                    {
                        referenceCode = pOrderReferenceCode
                    }
                };

                string requestJson = JsonConvert.SerializeObject(jsonObject);

                try
                {
                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayUGeneralApi(url, requestJson, HttpMethod.POST);
                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                        string res = sr.ReadToEnd();
                        var des = JsonConvert.DeserializeObject<RootPayUQueryOrderByRefResponse>(res);
                        if (des != null)
                        {
                            return des;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTest"></param>
        /// <param name="pCommand"></param>
        /// <param name="pLanguage"></param>
        /// <param name="productionOrTestApiKey"></param>
        /// <param name="productionOrTestApiLogIn"></param>
        /// <param name="pTransactionId"></param>
        /// <param name="productionOrTestUrl"></param>
        /// <returns></returns>
        public static RootPayUTransactionResponseQueryResponse GetTransactionResponse(bool isTest, string pCommand, string pLanguage,
            string productionOrTestApiKey, string productionOrTestApiLogIn, string pTransactionId, string productionOrTestUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productionOrTestApiKey))
                {
                    productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];
                }

                if (string.IsNullOrWhiteSpace(productionOrTestApiLogIn))
                {
                    productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];
                }
            }
            catch (Exception)
            {
                throw;
            }

            var url = productionOrTestUrl;
            if (url != null)
            {
                var jsonObject = new RootPayUTransactionResponseQueryRequest()
                {
                    command = pCommand,
                    language = pLanguage,
                    merchant = new Merchant()
                    {
                        apiKey = productionOrTestApiKey,
                        apiLogin = productionOrTestApiLogIn
                    },
                    test = isTest,
                    details = new Request_TransactionResponseQuery_Details()
                    {
                        transactionId = pTransactionId
                    }
                };

                string requestJson = JsonConvert.SerializeObject(jsonObject);

                try
                {
                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayUGeneralApi(url, requestJson, HttpMethod.POST);
                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                        string res = sr.ReadToEnd();
                        var des = JsonConvert.DeserializeObject<RootPayUTransactionResponseQueryResponse>(res);
                        if (des != null)
                        {
                            return des;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }
    }
}
