using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Request.Request_Cross;
using Tulpep.PayULibrary.Models.Request.Request_PayUPayments.ActivePaymentMethodsQuery;
using Tulpep.PayULibrary.Models.Request.Request_PayUPayments.BankTransfer;
using Tulpep.PayULibrary.Models.Request.Request_PayUPayments.CreditCard;
using Tulpep.PayULibrary.Models.Response.Response_PayUPayments.ActivePaymentMethodsQuery;
using Tulpep.PayULibrary.Models.Response.Response_PayUPayments.BankTransfer;
using Tulpep.PayULibrary.Models.Response.Response_PayUPayments.CreditCard;
using Tulpep.PayULibrary.Services.ServicesHelpers;

namespace Tulpep.PayULibrary.Services.PaymentsService
{
    public static class PaymentsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTest">Defines if the transaction will be sent as test mode</param>
        /// <param name="pCommand">Defines the command that will be aplied to the API, use Tulpep.PayULibrary.Cross.Constants to set it.</param>
        /// <param name="pLanguage">Defines the languaje wich will be used in the API to generate the responses to the user, 
        /// use Tulpep.PayULibrary.Cross.Constants to set it.</param>
        /// <param name="pCreditCard"></param>
        /// <param name="pTX_VALUE"></param>
        /// <param name="pBuyer"></param>
        /// <param name="pOrderShippingAddress"></param>
        /// <param name="pPayer"></param>
        /// <param name="pExtraParameters"></param>
        /// <param name="pPaymentCountry"></param>
        /// <param name="pPaymentMethod"></param>
        /// <param name="pType"></param>
        /// <param name="pUserAgent"></param>
        /// <param name="pDescription"></param>
        /// <param name="pNotifyUrl"></param>
        /// <param name="pReferenceCode"></param>
        /// <param name="pCookie"></param>
        /// <param name="pDeviceSessionId"></param>
        /// <param name="pIpAddress"></param>
        /// <returns></returns>
        public static async Task<RootPayUPaymentCreditCardResponse> MakeACreditCardPayment(bool isTest, string pCommand, string pLanguage,
            Request_CreditCard_CreditCard pCreditCard, Request_TXVALUE pTX_VALUE, bool calculateTaxes, Request_CreditCard_Buyer pBuyer,
            Address pOrderShippingAddress, Request_CreditCard_Payer pPayer, Request_ExtraParameters pExtraParameters,
            string pPaymentCountry, string pPaymentMethod, string pType, string pUserAgent, string pDescription,
            string pNotifyUrl, string pReferenceCode, string pCookie, string pDeviceSessionId, string pIpAddress)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestMerchantId = ConfigurationManager.AppSettings["PAYU_API_MERCHANTID"];

                int productionOrTestAccountId = int.Parse(ConfigurationManager.AppSettings["PAYU_API_ACCOUNTID"]);

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionPaymentsConnectionUrl;


                var url = productionOrTestUrl;
                if (url != null)
                {
                    string source = productionOrTestApiKey + "~" + productionOrTestMerchantId + "~" + pReferenceCode + "~" +
                        pTX_VALUE.value + "~" + pTX_VALUE.currency;
                    MD5 md5Hash = MD5.Create();
                    string pSignature = CryptoHelper.GetMd5Hash(md5Hash, source);

                    var jsonObject = new RootPayUPaymentCreditCardRequest()
                    {
                        command = pCommand,
                        language = pLanguage,
                        merchant = new Merchant()
                        {
                            apiKey = productionOrTestApiKey,
                            apiLogin = productionOrTestApiLogIn
                        },
                        test = isTest,
                        transaction = new Request_CreditCard_Transaction()
                        {
                            cookie = pCookie,
                            creditCard = pCreditCard,
                            deviceSessionId = pDeviceSessionId,
                            extraParameters = pExtraParameters,
                            ipAddress = pIpAddress,
                            order = new Request_CreditCard_Order()
                            {
                                accountId = productionOrTestAccountId,
                                additionalValues = calculateTaxes ? new Request_AdditionalValues()
                                {
                                    TX_VALUE = pTX_VALUE,
                                    TX_TAX = new Request_TXTAX()
                                    {
                                        currency = pTX_VALUE.currency,
                                        value = Tax_BaseReturnHelper.CalculateTaxValue(pTX_VALUE.value)
                                    },
                                    TX_TAX_RETURN_BASE = new Request_TXTAXRETURNBASE()
                                    {
                                        currency = pTX_VALUE.currency,
                                        value = Tax_BaseReturnHelper.CalculateBaseReturnValue(pTX_VALUE.value)
                                    }
                                } : new Request_AdditionalValues() {
                                    TX_VALUE = pTX_VALUE,
                                    TX_TAX = new Request_TXTAX()
                                    {
                                        currency = pTX_VALUE.currency,
                                        value = 0
                                    },
                                    TX_TAX_RETURN_BASE = new Request_TXTAXRETURNBASE()
                                    {
                                        currency = pTX_VALUE.currency,
                                        value = 0
                                    }
                                },
                                buyer = pBuyer,
                                description = pDescription,
                                language = pLanguage,
                                notifyUrl = pNotifyUrl,
                                referenceCode = pReferenceCode,
                                signature = pSignature,
                                shippingAddress = pOrderShippingAddress
                            },
                            payer = pPayer,
                            paymentCountry = pPaymentCountry,
                            paymentMethod = pPaymentMethod,
                            type = pType,
                            userAgent = pUserAgent
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
                            var des = JsonConvert.DeserializeObject<RootPayUPaymentCreditCardResponse>(res);
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
            catch (Exception)
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
        /// <param name="pTX_VALUE"></param>
        /// <param name="pBuyer"></param>
        /// <param name="pPayer"></param>
        /// <param name="pExtraParameters">
        /// You muust capture the: FINANCIAL_INSTITUTION_CODE, USER_TYPE, DOCUMENT_TYPE (SET IN PSE_REFERENCE2), 
        /// DOCUMENT_NUMBER (SET IN PSE_REFERENCE3) AND THE IPADDRES ( SET IN PSE_REFERENCE1).
        /// </param>
        /// <param name="pPaymentCountry"></param>
        /// <param name="pPaymentMethod"></param>
        /// <param name="pType"></param>
        /// <param name="pUserAgent"></param>
        /// <param name="pDescription"></param>
        /// <param name="pNotifyUrl"></param>
        /// <param name="pReferenceCode"></param>
        /// <param name="pCookie"></param>
        /// <param name="pDeviceSessionId"></param>
        /// <param name="pIpAddress"></param>
        /// <returns></returns>
        public static async Task<RootPayUPaymentBankTransferResponse> MakeABankTransferPayment(bool isTest, string pCommand, string pLanguage,
           Request_TXVALUE pTX_VALUE, bool calculateTaxes, Request_BankTransfer_Buyer pBuyer, Request_BankTransfer_Payer pPayer,
           Request_ExtraParameters pExtraParameters, string pPaymentCountry, string pPaymentMethod, string pType, string pUserAgent,
           string pDescription, string pNotifyUrl, string pReferenceCode, string pCookie, string pDeviceSessionId,
           string pIpAddress)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestMerchantId = ConfigurationManager.AppSettings["PAYU_API_MERCHANTID"];

                int productionOrTestAccountId = int.Parse(ConfigurationManager.AppSettings["PAYU_API_ACCOUNTID"]);

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionPaymentsConnectionUrl;

                var url = productionOrTestUrl;
                if (url != null)
                {
                    string source = productionOrTestApiKey + "~" + productionOrTestMerchantId + "~" + pReferenceCode + "~" +
                        pTX_VALUE.value + "~" + pTX_VALUE.currency;
                    MD5 md5Hash = MD5.Create();
                    string pSignature = CryptoHelper.GetMd5Hash(md5Hash, source);

                    var jsonObject = new RootPayUPaymentBankTransferRequest()
                    {
                        command = pCommand,
                        language = pLanguage,
                        test = isTest,
                        merchant = new Merchant()
                        {
                            apiKey = productionOrTestApiKey,
                            apiLogin = productionOrTestApiLogIn
                        },
                        transaction = new Request_BankTransfer_Transaction()
                        {
                            cookie = pCookie,
                            extraParameters = pExtraParameters,
                            ipAddress = pIpAddress,
                            payer = pPayer,
                            paymentCountry = pPaymentCountry,
                            paymentMethod = pPaymentMethod,
                            type = pType,
                            userAgent = pUserAgent,
                            order = new Request_BankTransfer_Order()
                            {
                                accountId = productionOrTestAccountId,
                                additionalValues = calculateTaxes ? new Request_AdditionalValues()
                                {
                                    TX_VALUE = pTX_VALUE,
                                    TX_TAX = new Request_TXTAX()
                                    {
                                        currency = pTX_VALUE.currency,
                                        value = Tax_BaseReturnHelper.CalculateTaxValue(pTX_VALUE.value)
                                    },
                                    TX_TAX_RETURN_BASE = new Request_TXTAXRETURNBASE()
                                    {
                                        currency = pTX_VALUE.currency,
                                        value = Tax_BaseReturnHelper.CalculateBaseReturnValue(pTX_VALUE.value)
                                    }
                                } : new Request_AdditionalValues() {
                                    TX_VALUE = pTX_VALUE,
                                    TX_TAX = new Request_TXTAX()
                                    {
                                        currency = pTX_VALUE.currency,
                                        value = 0
                                    },
                                    TX_TAX_RETURN_BASE = new Request_TXTAXRETURNBASE()
                                    {
                                        currency = pTX_VALUE.currency,
                                        value = 0
                                    }
                                },
                                buyer = pBuyer,
                                description = pDescription,
                                language = pLanguage,
                                notifyUrl = pNotifyUrl,
                                referenceCode = pReferenceCode,
                                signature = pSignature
                            }
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
                            var des = JsonConvert.DeserializeObject<RootPayUPaymentBankTransferResponse>(res);
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
            catch (Exception)
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
        /// <param name="pPaymentCountry"></param>
        /// <param name="pPaymentMethod"></param>
        /// <returns></returns>
        public static async Task<RootPayUPaymentBankListResponse> GetAvailableBankList(bool isTest, string pCommand, string pLanguage,
            string pPaymentCountry, string pPaymentMethod)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionPaymentsConnectionUrl;

                var url = productionOrTestUrl;
                if (url != null)
                {

                    var jsonObject = new RootPayUPaymentBankListRequest()
                    {
                        command = pCommand,
                        language = pLanguage,
                        bankListInformation = new Request_BankTransfer_BankListInformation()
                        {
                            paymentMethod = pPaymentMethod,
                            paymentCountry = pPaymentCountry
                        },
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
                            var des = JsonConvert.DeserializeObject<RootPayUPaymentBankListResponse>(res);
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
            catch (Exception)
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
        /// <returns></returns>
        public static async Task<RootPayUActivePaymentMethodResponse> GetActivePaymentMethods(bool isTest, string pCommand, string pLanguage)
        {
            try
            {
                string productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];

                string productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];

                string productionOrTestUrl = ConfigurationManager.AppSettings["PAYU_API_CONNECTION_URL"] + PayU_Constants.DefaultProductionPaymentsConnectionUrl;

                var url = productionOrTestUrl;
                if (url != null)
                {

                    var jsonObject = new RootPayUActivePaymentMethodRequest()
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
                            var des = JsonConvert.DeserializeObject<RootPayUActivePaymentMethodResponse>(res);
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
            catch (Exception)
            {
                throw;
            }
            return null;
        }

    }
}
