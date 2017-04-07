using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
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
        /// <returns></returns>
        public static async Task<RootPayUQueriesPingResponse> PingTheApi(bool isTest, string pCommand, string pLanguage)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionQueriesConnectionUrl;

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

                    HttpWebResponse resp = await HtttpWebRequestHelper.SendJSONToPayUGeneralApi(url, requestJson, HttpMethod.POST);
                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = await sr.ReadToEndAsync();
                            var des = JsonConvert.DeserializeObject<RootPayUQueriesPingResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(resp.StatusCode + "; " + resp.StatusDescription);
                    }
                }
            }
            catch
            {
                throw;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTest"></param>
        /// <param name="pCommand"></param>
        /// <param name="pLanguage"></param>
        /// <param name="pOrderId"></param>
        /// <returns></returns>
        public static async Task<RootPayUQueryOrderByIdResponse> GetOrderById(bool isTest, string pCommand, string pLanguage,
            int pOrderId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionQueriesConnectionUrl;

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

                    HttpWebResponse resp = await HtttpWebRequestHelper.SendJSONToPayUGeneralApi(url, requestJson, HttpMethod.POST);
                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = await sr.ReadToEndAsync();
                            var des = JsonConvert.DeserializeObject<RootPayUQueryOrderByIdResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(resp.StatusCode + "; " + resp.StatusDescription);
                    }
                }
            }
            catch
            {
                throw;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTest"></param>
        /// <param name="pCommand"></param>
        /// <param name="pLanguage"></param>
        /// <param name="pOrderReferenceCode"></param>
        /// <returns></returns>
        public static async Task<RootPayUQueryOrderByRefResponse> GetOrderByReferenceCode(bool isTest, string pCommand, string pLanguage,
            string pOrderReferenceCode)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionQueriesConnectionUrl;

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

                    HttpWebResponse resp = await HtttpWebRequestHelper.SendJSONToPayUGeneralApi(url, requestJson, HttpMethod.POST);
                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = await sr.ReadToEndAsync();
                            var des = JsonConvert.DeserializeObject<RootPayUQueryOrderByRefResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(resp.StatusCode + "; " + resp.StatusDescription);
                    }
                }
            }
            catch
            {
                throw;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTest"></param>
        /// <param name="pCommand"></param>
        /// <param name="pLanguage"></param>
        /// <param name="pTransactionId"></param>
        /// <returns></returns>
        public static async Task<RootPayUTransactionResponseQueryResponse> GetTransactionResponse(bool isTest, string pCommand, string pLanguage,
            string pTransactionId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionQueriesConnectionUrl;

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

                    HttpWebResponse resp = await HtttpWebRequestHelper.SendJSONToPayUGeneralApi(url, requestJson, HttpMethod.POST);
                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = await sr.ReadToEndAsync();
                            var des = JsonConvert.DeserializeObject<RootPayUTransactionResponseQueryResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(resp.StatusCode + "; " + resp.StatusDescription);
                    }
                }
            }
            catch
            {
                throw;
            }

            return null;
        }
    }
}
