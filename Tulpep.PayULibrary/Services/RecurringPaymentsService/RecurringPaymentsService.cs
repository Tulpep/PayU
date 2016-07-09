using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
#region Tulpep PayU Library
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.AdditionalCharges.Creation;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.AdditionalCharges.Update;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.CreditCard.Creation;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.CreditCard.Update;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Customer.Creation;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Customer.Update;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Plan.Creation;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Plan.Update;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.AllExistingElements;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.AllNewItems;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.NewCard;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.NewPlan;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Update;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.AdditionalCharges.Creation;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.AdditionalCharges.Delete;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.AdditionalCharges.Query.ByDescriptionOfExtraCharge;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.AdditionalCharges.Query.ByIdOfExtraCharge;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.AdditionalCharges.Query.BySubscription;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.AdditionalCharges.Update;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Bill.Query;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.CreditCard.Creation;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.CreditCard.Delete;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.CreditCard.Query;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.CreditCard.Update;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Customer.Creation;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Customer.Delete;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Customer.Query;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Customer.Update;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Plan.Creation;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Plan.Query;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Plan.Update;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.AllExistingElements;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.AllNewItems;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.NewCard;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.NewPlan;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Delete;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Query;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Update;
using Tulpep.PayULibrary.Services.ServicesHelpers;
#endregion

namespace Tulpep.PayULibrary.Services.RecurringPaymentsService
{
    public static class RecurringPaymentsService
    {

        #region Plan
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pDescription"></param>
        /// <param name="pInterval"></param>
        /// <param name="pIntervalCount"></param>
        /// <param name="pMaxPaymentsAllowed"></param>
        /// <param name="pPaymentAttemptsDelay"></param>
        /// <param name="pMaxPaymentAttempts"></param>
        /// <param name="pMaxPendingPayments"></param>
        /// <param name="pPlanCode"></param>
        /// <param name="pAdditionalValues"></param>
        /// <returns></returns>
        public static RootPayUPlanCreationResponse CreateAPlan(string pLanguage,
            string pDescription, string pInterval, string pIntervalCount, string pMaxPaymentsAllowed,
            string pMaxPaymentAttempts, string pMaxPendingPayments, string pTrialDays,
            string pPaymentAttemptsDelay, string pPlanCode,
            List<Request_Recurring_AdditionalValue> pAdditionalValues)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestAccountId = ConfigurationManager.AppSettings["PAYU_API_ACCOUNTID"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultPlanRecurringPaymentsUrl;

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
                        maxPaymentAttempts = pMaxPaymentAttempts,
                        maxPendingPayments = pMaxPendingPayments,
                        trialDays = pTrialDays,
                        additionalValues = pAdditionalValues
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.POST);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUPlanCreationResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUPlanCreationResponse>(res);
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
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    throw;
                }
                throw;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pDescription"></param>
        /// <param name="pMaxPendingPayments"></param>
        /// <param name="pMaxPaymentAttempts"></param>
        /// <param name="pPaymentAttemptsDelay"></param>
        /// <param name="pPlanCode"></param>
        /// <param name="pAdditionalValues"></param>
        /// <returns></returns>
        public static RootPayUPlanUpdateResponse UpdateAPlan(string pLanguage, string pDescription, string pMaxPendingPayments,
            string pMaxPaymentAttempts,
           string pPaymentAttemptsDelay, string pPlanCode, List<Request_Recurring_AdditionalValue> pAdditionalValues)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultPlanRecurringPaymentsUrl + pPlanCode;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUPlanUpdateRequest()
                    {
                        description = pDescription,
                        paymentAttemptsDelay = pPaymentAttemptsDelay,
                        planCode = pPlanCode,
                        additionalValues = pAdditionalValues,
                        maxPaymentAttempts = pMaxPaymentAttempts,
                        maxPendingPayments = pMaxPendingPayments
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.PUT);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUPlanUpdateResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUPlanUpdateResponse>(res);
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
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    return new RootPayUPlanUpdateResponse()
                    {
                        id = "there might be a problem please try again.",
                    };
                }
                throw;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pPlanCode"></param>
        /// <returns></returns>
        public static RootPayUPlanQueryResponse GetAPlan(string pLanguage, string pPlanCode)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultPlanRecurringPaymentsUrl + pPlanCode;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                                           pLanguage, pBse64, HttpMethod.GET);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUPlanQueryResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw ex;
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pPlanCode"></param>
        /// <returns></returns>
        public static bool DeleteAPlan(string pLanguage, string pPlanCode)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultPlanRecurringPaymentsUrl + pPlanCode;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);


                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                        pLanguage, pBse64, HttpMethod.DELETE);

                    if (resp == null)
                        return false;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("Plan does not exist in Payu" + ex.Message);
                }
            }

            return false;
        }
        #endregion

        #region Customer

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pEnail"></param>
        /// <param name="pFullName"></param>
        /// <returns></returns>
        public static RootPayUCustomerCreationResponse CreateACustomer(string pLanguage, string pEnail, string pFullName)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultCustomerRecurringPaymentsUrl;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUCustomerCreationRequest()
                    {
                        email = pEnail,
                        fullName = pFullName
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.POST);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCustomerCreationResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCustomerCreationResponse>(res);
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
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    throw;
                }
                throw;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pEnail"></param>
        /// <param name="pFullName"></param>
        /// <returns></returns>
        public static RootPayUCustomerUpdateResponse UpdateACustomer(string pLanguage, string pCustomerId,
            string pEnail, string pFullName)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultCustomerRecurringPaymentsUrl + pCustomerId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUCustomerUpdateRequest()
                    {
                        email = pEnail,
                        fullName = pFullName
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.PUT);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCustomerUpdateResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCustomerUpdateResponse>(res);
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
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    return new RootPayUCustomerUpdateResponse()
                    {
                        id = "there migth be a problem please try again later",
                    };
                }
                throw;
            }

            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pCustomerId"></param>
        /// <returns></returns>
        public static RootPayUCustomerQueryResponse GetACustomer(string pLanguage, string pCustomerId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultCustomerRecurringPaymentsUrl + pCustomerId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);


                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                        pLanguage, pBse64, HttpMethod.GET);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCustomerQueryResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pCustomerId"></param>
        /// <returns></returns>
        public static RootPayUCustomerDeleteResponse DeleteACustomer(string pLanguage, string pCustomerId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultCustomerRecurringPaymentsUrl + pCustomerId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);


                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                        pLanguage, pBse64, HttpMethod.DELETE);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCustomerDeleteResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }
        #endregion

        #region Credit Card

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pDocument"></param>
        /// <param name="pExpMonth"></param>
        /// <param name="pExpYearm"></param>
        /// <param name="pName"></param>
        /// <param name="pNumber"></param>
        /// <param name="pType"></param>
        /// <param name="pAddress"></param>
        /// <param name="pCustomerId"></param>
        /// <returns></returns>
        public static RootPayUCreditCardCreationResponse CreateACreditCard(
            string pLanguage, string pDocument, string pExpMonth, string pExpYearm, string pName, string pNumber, string pType,
            Request_Recurring_Address pAddress, string pCustomerId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultCustomerRecurringPaymentsUrl + pCustomerId +
                        PayU_Constants.DefaultCreditCardRecurringPaymentsUrl;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUCreditCardCreationRequest()
                    {
                        document = pDocument,
                        expMonth = pExpMonth,
                        expYear = pExpYearm,
                        name = pName,
                        number = pNumber,
                        type = pType,
                        address = pAddress
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.POST);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCreditCardCreationResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCreditCardCreationResponse>(res);
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
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    throw;
                }
                throw;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pDocument"></param>
        /// <param name="pExpMonth"></param>
        /// <param name="pExpYearm"></param>
        /// <param name="pName"></param>
        /// <param name="pAddress"></param>
        /// <param name="pCreditCardToken"></param>
        /// <returns></returns>
        public static RootPayUCreditCardUpdateResponse UpdateACreditCard(
            string pLanguage, string pDocument, string pExpMonth, string pExpYearm, string pName,
            Request_Recurring_Address pAddress, string pCreditCardToken)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultCreditCardRecurringPaymentsUrl + pCreditCardToken;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUCreditCardUpdateRequest()
                    {
                        document = pDocument,
                        expMonth = pExpMonth,
                        expYear = pExpYearm,
                        name = pName,
                        address = pAddress,
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.PUT);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCreditCardUpdateResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCreditCardUpdateResponse>(res);
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
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    return new RootPayUCreditCardUpdateResponse()
                    {
                        token = "there migth be a problem please try again",
                    };
                }
                throw;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pCreditCardToken"></param>
        /// <returns></returns>
        public static RootPayUCreditCardQueryResponse GetACreditCard(string pLanguage, string pCreditCardToken)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultCreditCardRecurringPaymentsUrl + pCreditCardToken;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                        pLanguage, pBse64, HttpMethod.GET);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCreditCardQueryResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pCreditCardToken"></param>
        /// <returns></returns>
        public static RootPayUCreditCardDeleteResponse DeleteACreditCard(string pLanguage, string pCustomerId, string pCreditCardToken)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultCustomerRecurringPaymentsUrl + pCustomerId + PayU_Constants.DefaultCreditCardRecurringPaymentsUrl + pCreditCardToken;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);


                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                        pLanguage, pBse64, HttpMethod.DELETE);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUCreditCardDeleteResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }
        #endregion

        #region Subscription

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pInstallments"></param>
        /// <param name="pQuantity"></param>
        /// <param name="pTrialDays"></param>
        /// <param name="pCustomer"></param>
        /// <param name="pPlan"></param>
        /// <returns></returns>
        public static RootPayUSubscriptionCreationAllNewResponse CreateASubscriptionAllMew(string pLanguage, string pInstallments,
            string pQuantity, string pTrialDays,
            Request_Subscription_Creation_AllNewItems_Customer pCustomer,
            Request_Subscription_Creation_AllNewItems_Plan pPlan)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultSubscriptionRecurringPaymentsUrl;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUSubscriptionCreationAllNewRequest()
                    {
                        installments = pInstallments,
                        quantity = pQuantity,
                        trialDays = pTrialDays,
                        customer = pCustomer,
                        plan = pPlan
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.POST);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUSubscriptionCreationAllNewResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUSubscriptionCreationAllNewResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pInstallments"></param>
        /// <param name="pQuantity"></param>
        /// <param name="pTrialDays"></param>
        /// <param name="pCustomer"></param>
        /// <param name="pPlan"></param>
        /// <returns></returns>
        public static RootPayUSubscriptionCreationAllExistingElementsResponse CreateASubscriptionAllExisting(string pLanguage,
            string pInstallments, string pQuantity, string pTrialDays,
            Request_Subscription_Creation_AllExistingElements_Customer pCustomer,
            Request_Subscription_Creation_AllExistingElements_Plan pPlan)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultSubscriptionRecurringPaymentsUrl;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUSubscriptionCreationAllExistingElementsRequest()
                    {
                        installments = pInstallments,
                        quantity = pQuantity,
                        trialDays = pTrialDays,
                        customer = pCustomer,
                        plan = pPlan
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.POST);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUSubscriptionCreationAllExistingElementsResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUSubscriptionCreationAllExistingElementsResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pInstallments"></param>
        /// <param name="pQuantity"></param>
        /// <param name="pTrialDays"></param>
        /// <param name="pCustomer"></param>
        /// <param name="pPlan"></param>
        /// <returns></returns>
        public static RootPayUSubscriptionCreationNewCardResponse CreateASubscriptionNewCard(string pLanguage,
            string pInstallments, string pQuantity, string pTrialDays,
            Request_Subscription_Creation_NewCard_Customer pCustomer,
            Request_Subscription_Creation_NewCard_Plan pPlan)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultSubscriptionRecurringPaymentsUrl;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUSubscriptionCreationNewCardRequest()
                    {
                        installments = pInstallments,
                        quantity = pQuantity,
                        trialDays = pTrialDays,
                        customer = pCustomer,
                        plan = pPlan
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.POST);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUSubscriptionCreationNewCardResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUSubscriptionCreationNewCardResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pInstallments"></param>
        /// <param name="pTrialDays"></param>
        /// <param name="pCustomer"></param>
        /// <param name="pPlan"></param>
        /// <returns></returns>
        public static RootPayUSubscriptionCreationNewPlanResponse CreateASubscriptionNewPlan(string pLanguage,
            string pInstallments, string pTrialDays,
            Request_Subscription_Creation_NewPlan_Customer pCustomer,
            Request_Subscription_Creation_NewPlan_Plan pPlan)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultSubscriptionRecurringPaymentsUrl;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUSubscriptionCreationNewPlanRequest()
                    {
                        installments = pInstallments,
                        trialDays = pTrialDays,
                        customer = pCustomer,
                        plan = pPlan
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.POST);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUSubscriptionCreationNewPlanResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUSubscriptionCreationNewPlanResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// It only updates the CrefitCar of a subcription 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pCreditCardToken"></param>
        /// <param name="pSubscriptionId"></param>
        /// <returns></returns>
        public static RootPayUSubscriptionUpdateResponse UpdateASubscription(string pLanguage, string pCreditCardToken,
            string pSubscriptionId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultSubscriptionRecurringPaymentsUrl + pSubscriptionId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUSubscriptionUpdateRequest()
                    {
                        creditCardToken = pCreditCardToken
                    };
                    string requestJson = JsonConvert.SerializeObject(jsonObject);
                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.PUT);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUSubscriptionUpdateResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pSubscriptionId"></param>
        /// <returns></returns>
        public static RootPayUSubscriptionQueryResponse GetASubscription(string pLanguage, string pSubscriptionId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultSubscriptionRecurringPaymentsUrl + pSubscriptionId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);


                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                        pLanguage, pBse64, HttpMethod.GET);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUSubscriptionQueryResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pSubscriptionId"></param>
        /// <returns></returns>
        public static RootPayUSubscriptionDeleteResponse DeleteASubscription(string pLanguage, string pSubscriptionId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultSubscriptionRecurringPaymentsUrl + pSubscriptionId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                        pLanguage, pBse64, HttpMethod.DELETE);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUSubscriptionDeleteResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }
        #endregion

        #region Additional charges

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pSubscriptionId"></param>
        /// <param name="pDescription"></param>
        /// <param name="pAdditionalValues"></param>
        /// <returns></returns>
        public static RootPayUAdditionalChargesCreationResponse CreateAnAdditionalCharge(string pLanguage,
            string pSubscriptionId, string pDescription, List<Request_Recurring_AdditionalValue> pAdditionalValues)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultSubscriptionRecurringPaymentsUrl + pSubscriptionId
                        + PayU_Constants.DefaultAdditionalChargesRecurringPaymentsUrl;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUAdditionalChargesCreationRequest()
                    {
                        description = pDescription,
                        additionalValues = pAdditionalValues
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                        pLanguage, pBse64, HttpMethod.POST);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUAdditionalChargesCreationResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                    else if (resp.StatusCode == HttpStatusCode.Created)
                    {

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUAdditionalChargesCreationResponse>(res);
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
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    throw;
                }
                throw;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pSubscriptionId"></param>
        /// <param name="pDescription"></param>
        /// <param name="pAdditionalValues"></param>
        /// <param name="pRecurringBillItemId"></param>
        /// <returns></returns>
        public static RootPayUAdditionalChargesUpdateResponse UpdateAnAdditionalCharge(string pLanguage,
            string pDescription, List<Request_Recurring_AdditionalValue> pAdditionalValues,
            string pRecurringBillItemId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultAdditionalChargesRecurringPaymentsUrl + pRecurringBillItemId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    var jsonObject = new RootPayUAdditionalChargesUpdateRequest()
                    {
                        description = pDescription,
                        additionalValues = pAdditionalValues
                    };

                    string requestJson = JsonConvert.SerializeObject(jsonObject);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, requestJson,
                       pLanguage, pBse64, HttpMethod.PUT);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUAdditionalChargesUpdateResponse>(res);
                            sr.Close();
                            if (des != null)
                            {
                                return des;
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pRecurringBillItemId"></param>
        /// <returns></returns>
        public static RootPayUAdditionalChargesQueryByIdResponse GetAnAdditionalChargeById(string pLanguage,
            string pRecurringBillItemId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultAdditionalChargesRecurringPaymentsUrl + pRecurringBillItemId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);


                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                       pLanguage, pBse64, HttpMethod.GET);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUAdditionalChargesQueryByIdResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pDescription"></param>
        /// <returns></returns>
        public static RootPayUAdditionalChargesQueryByDtnResponse GetAnAdditionalChargeByDescription(string pLanguage,
            string pDescription)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultAdditionalChargesRecurringPaymentsUrl +
                        PayU_Constants.DefaultAdditionalChargesRecurringPaymentsDescriptionParam + pDescription;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);


                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                       pLanguage, pBse64, HttpMethod.GET);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUAdditionalChargesQueryByDtnResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pSubscriptionId"></param>
        /// <returns></returns>
        public static RootPayUAdditionalChargesQueryBySbtnResponse GetAnAdditionalChargeBySubscriptionId(string pLanguage,
            string pSubscriptionId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultAdditionalChargesRecurringPaymentsUrl +
                        PayU_Constants.DefaultAdditionalChargesRecurringPaymentsSubscriptionParam + pSubscriptionId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                       pLanguage, pBse64, HttpMethod.GET);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUAdditionalChargesQueryBySbtnResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pRecurringBillItemId"></param>
        /// <returns></returns>
        public static RootPayUAdditionalChargesDeleteResponse DeleteAnAdditionalCharge(string pLanguage,
            string pRecurringBillItemId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultAdditionalChargesRecurringPaymentsUrl + pRecurringBillItemId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);


                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                       pLanguage, pBse64, HttpMethod.DELETE);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUAdditionalChargesDeleteResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
            return null;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pSubscriptionId"></param>
        /// <returns></returns>
        public static RootPayUBillQueryResponse GetARecurringBillBySubscriptionId(string pLanguage,
            string pSubscriptionId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultRecurringBillUrl +
                        PayU_Constants.DefaultRecurringBillUrlSubscriptionParam + pSubscriptionId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                       pLanguage, pBse64, HttpMethod.GET);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUBillQueryResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLanguage"></param>
        /// <param name="pCustomerId"></param>
        /// <returns></returns>
        public static RootPayUBillQueryResponse GetARecurringBillsByCustomerId(string pLanguage,
            string pCustomerId)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionRecurringPaymentsConnectionUrl;

                if (!string.IsNullOrWhiteSpace(productionOrTestUrl))
                {
                    productionOrTestUrl = productionOrTestUrl + PayU_Constants.DefaultRecurringBillUrl +
                        PayU_Constants.DefaultRecurringBillUrlCustomerParam + pCustomerId;

                    string source = productionOrTestApiLogIn + ":" + productionOrTestApiKey;
                    string pBse64 = CryptoHelper.GetBase64Hash(source);

                    HttpWebResponse resp = HtttpWebRequestHelper.SendJSONToPayURecurringPaymentsApi(productionOrTestUrl, null,
                       pLanguage, pBse64, HttpMethod.GET);

                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                        {
                            string res = sr.ReadToEnd();
                            var des = JsonConvert.DeserializeObject<RootPayUBillQueryResponse>(res);
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
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return null;
        }
        #endregion
    }
}
