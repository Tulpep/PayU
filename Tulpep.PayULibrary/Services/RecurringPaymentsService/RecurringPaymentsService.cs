using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Plan.Creation;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Plan.Creation;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Plan.Query;
using Tulpep.PayULibrary.Services.ServicesHelpers;

namespace Tulpep.PayULibrary.Services.RecurringPaymentsService
{
    public static class RecurringPaymentsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="productionOrTestApiKey"></param>
        /// <param name="productionOrTestApiLogIn"></param>
        /// <param name="productionOrTestAccountId"></param>
        /// <param name="pDescription"></param>
        /// <param name="pInterval"></param>
        /// <param name="pIntervalCount"></param>
        /// <param name="pMaxPaymentsAllowed"></param>
        /// <param name="pPaymentAttemptsDelay"></param>
        /// <param name="pPlanCode"></param>
        /// <param name="productionOrTestUrl"></param>
        /// <returns></returns>
        public static RootPayUPlanCreationResponse CreateAPlan(string pLanguage, string productionOrTestApiKey,
            string productionOrTestApiLogIn, string productionOrTestAccountId,
            string pDescription, string pInterval, string pIntervalCount, string pMaxPaymentsAllowed,
            string pPaymentAttemptsDelay, string pPlanCode, List<Request_Recurring_AdditionalValue> pAdditionalValues,
            string productionOrTestUrl)
        {

            var url = productionOrTestUrl;
            if (url != null)
            {
                url = productionOrTestUrl + PayU_Constants.DefaultPlanRecurringPaymentsUrl;

                string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                string pBse64 = CryptoHelper.GetBase64Hash(source);

                var jsonObject = new RootPayUPlanCreationRequest()
                {
                    accountId = productionOrTestAccountId,
                    description = pDescription,
                    interval = pInterval,
                    intervalCount = pIntervalCount,
                    maxPaymentsAllowed = pMaxPaymentsAllowed,
                    paymentAttemptsDelay = pPaymentAttemptsDelay,
                    planCode = pPlanCode,
                    additionalValues = pAdditionalValues
                };

                string requestJson = JsonConvert.SerializeObject(jsonObject);

                try
                {
                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(url, requestJson,
                        pLanguage, pBse64, HttpMethod.POST);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                        string res = sr.ReadToEnd();
                        var des = JsonConvert.DeserializeObject<RootPayUPlanCreationResponse>(res);
                        if (des != null)
                        {
                            return des;
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {

                        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                        string res = sr.ReadToEnd();
                        var des = JsonConvert.DeserializeObject<RootPayUPlanCreationResponse>(res);
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
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        return new RootPayUPlanCreationResponse()
                        {
                            id = "You have registered it before",
                        };
                    }
                    throw;
                }
            }
            return null;
        }


        public static RootPayUPlanQueryResponse GetAPlan(string pLanguage, string productionOrTestApiKey,
            string productionOrTestApiLogIn, string pPlanCode, string productionOrTestUrl)
        {

            var url = productionOrTestUrl;
            if (url != null)
            {
                url = productionOrTestUrl + PayU_Constants.DefaultPlanRecurringPaymentsUrl + pPlanCode;

                string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                string pBse64 = CryptoHelper.GetBase64Hash(source);

                try
                {
                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(url, null,
                        pLanguage, pBse64, HttpMethod.GET);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                        string res = sr.ReadToEnd();
                        var des = JsonConvert.DeserializeObject<RootPayUPlanQueryResponse>(res);
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
