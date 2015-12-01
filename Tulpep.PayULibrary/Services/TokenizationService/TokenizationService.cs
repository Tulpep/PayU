using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Security.Cryptography;
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Request.Request_Cross;
using Tulpep.PayULibrary.Models.Request.Request_Tokenization.IndividualCreditCardRegistration;
using Tulpep.PayULibrary.Models.Request.Request_Tokenization.IndividualPaymentWithToken;
using Tulpep.PayULibrary.Models.Request.Request_Tokenization.MassiveCreditCardRegistration;
using Tulpep.PayULibrary.Models.Response.Response_Tokenization.IndividualCreditCardRegistration;
using Tulpep.PayULibrary.Models.Response.Response_Tokenization.IndividualPaymentWithToken;
using Tulpep.PayULibrary.Models.Response.Response_Tokenization.MassiveCreditCardRegistration;
using Tulpep.PayULibrary.Services.ServicesHelpers;

namespace Tulpep.PayULibrary.Services.TokenizationService
{
    public static class TokenizationService
    {
        /// <summary>
        /// Using this feature you can register a customer’s credit card data and get a token sequential number.
        /// </summary>
        /// <param name="pCommand"></param>
        /// <param name="pLanguage"></param>
        /// <param name="productionOrTestApiKey"></param>
        /// <param name="productionOrTestApiLogIn"></param>
        /// <param name="productionOrTestUrl"></param>
        /// <param name="pCreditCard"></param>
        /// <returns></returns>
        public static RootPayUIndividualCreditCardRegistrationResponse IndividualCreditCardRegistration(string pCommand, string pLanguage,
            string productionOrTestApiKey, string productionOrTestApiLogIn, string productionOrTestUrl,
            Request_IndividualCreditCardRegistration_CreditCardToken pCreditCard)
        {
            if (string.IsNullOrWhiteSpace(productionOrTestApiKey))
            {
                productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];
            }

            if (string.IsNullOrWhiteSpace(productionOrTestApiLogIn))
            {
                productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];
            }

            var url = productionOrTestUrl;
            if (url != null)
            {

                var jsonObject = new RootPayUIndividualCreditCardRegistrationRequest()
                {
                    command = pCommand,
                    language = pLanguage,
                    merchant = new Merchant()
                    {
                        apiKey = productionOrTestApiKey,
                        apiLogin = productionOrTestApiLogIn
                    },
                    creditCardToken =pCreditCard
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
                        var des = JsonConvert.DeserializeObject<RootPayUIndividualCreditCardRegistrationResponse>(res);
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
        /// Using this feature you can register various customer’s credit card data and get token sequential numbers.
        /// For massive credit card tokenization you must create a file with CSV format with the following conditions:  
        /// Each credit card register to be tokenized must contain data for the registration of a credit card, 
        /// separated by commas in the following order: Payer ID, full name, credit card number, expiration date, franchise, 
        /// and identification number.
        /// The file should have no header.The first line shows the first record.
        /// The file must be encoded under the UTF-8 standard.
        /// The file must not have more than 10,000 registers.
        /// </summary>
        /// <param name="pCommand"></param>
        /// <param name="pLanguage"></param>
        /// <param name="productionOrTestApiKey"></param>
        /// <param name="productionOrTestApiLogIn"></param>
        /// <param name="productionOrTestUrl"></param>
        /// <param name="pContentFilePath"></param>
        /// <returns></returns>
        public static RootPayUMassiveCreditCardRegistrationResponse MassiveCreditCardRegistration(string pCommand, string pLanguage,
            string productionOrTestApiKey, string productionOrTestApiLogIn, string productionOrTestUrl,
            string pContentFilePath)
        {
            if (string.IsNullOrWhiteSpace(productionOrTestApiKey))
            {
                productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];
            }

            if (string.IsNullOrWhiteSpace(productionOrTestApiLogIn))
            {
                productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];
            }

            var url = productionOrTestUrl;
            if (url != null)
            {

                var jsonObject = new RootPayUMassiveCreditCardRegistrationRequest()
                {
                    command = pCommand,
                    language = pLanguage,
                    merchant = new Merchant()
                    {
                        apiKey = productionOrTestApiKey,
                        apiLogin = productionOrTestApiLogIn
                    },
                    contentFile = pContentFilePath
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
                        var des = JsonConvert.DeserializeObject<RootPayUMassiveCreditCardRegistrationResponse>(res);
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
        /// This feature allows you to make collections using a Token code that was previously created by our system, 
        /// and which was used to store your customers’ credit cards data safely.
        /// </summary>
        /// <param name="isTest"></param>
        /// <param name="pCommand"></param>
        /// <param name="pLanguage"></param>
        /// <param name="productionOrTestApiKey"></param>
        /// <param name="productionOrTestApiLogIn"></param>
        /// <param name="productionOrTestAccountId"></param>
        /// <param name="productionOrTestMerchantId"></param>
        /// <param name="pCreditCardTokenId"></param>
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
        /// <param name="productionOrTestUrl"></param>
        /// <returns></returns>
        public static RootPayUIndividualPaymentWithTokenResponse IndividualPaymentWithToken(bool isTest, string pCommand, string pLanguage, 
            string productionOrTestApiKey, string productionOrTestApiLogIn, int productionOrTestAccountId, 
            string productionOrTestMerchantId, string pCreditCardTokenId, Request_TXVALUE pTX_VALUE, 
            Request_IndividualPaymentWithToken_Buyer pBuyer, Address pOrderShippingAddress, 
            Request_IndividualPaymentWithToken_Payer pPayer, Request_ExtraParameters pExtraParameters, string pPaymentCountry, 
            string pPaymentMethod, string pType, string pUserAgent, string pDescription, string pNotifyUrl, string pReferenceCode, 
            string pCookie, string pDeviceSessionId, string pIpAddress, string productionOrTestUrl)
        {
            if (string.IsNullOrWhiteSpace(productionOrTestApiKey))
            {
                productionOrTestApiKey = ConfigurationManager.AppSettings["PAYU_API_KEY"];
            }

            if (string.IsNullOrWhiteSpace(productionOrTestApiLogIn))
            {
                productionOrTestApiLogIn = ConfigurationManager.AppSettings["PAYU_API_LOGIN"];
            }

            var url = productionOrTestUrl;
            if (url != null)
            {
                string source = productionOrTestApiKey + "~" + productionOrTestMerchantId + "~" + pReferenceCode + "~" +
                   pTX_VALUE.value + "~" + pTX_VALUE.currency;
                MD5 md5Hash = MD5.Create();
                string pSignature = CryptoHelper.GetMd5Hash(md5Hash, source);

                var jsonObject = new RootPayUIndividualPaymentWithTokenRequest()
                {
                    command = pCommand,
                    language = pLanguage,
                    merchant = new Merchant()
                    {
                        apiKey = productionOrTestApiKey,
                        apiLogin = productionOrTestApiLogIn
                    },
                    transaction = new Request_IndividualPaymentWithToken_Transaction()
                    {
                        cookie = pCookie,
                        creditCardTokenId = pCreditCardTokenId,
                        deviceSessionId = pDeviceSessionId,
                        userAgent = pUserAgent,
                        ipAddress = pIpAddress, 
                        paymentCountry = pPaymentCountry,
                        paymentMethod = pPaymentMethod,
                        type = pType,
                        payer = pPayer,
                        order = new Request_IndividualPaymentWithToken_Order()
                        {
                            accountId = productionOrTestAccountId,
                            buyer = pBuyer,
                            description = pDescription,
                            language = pLanguage,
                            notifyUrl = pNotifyUrl,
                            referenceCode = pReferenceCode,
                            shippingAddress = pOrderShippingAddress,
                            additionalValues = new Request_AdditionalValues()
                            {
                                TX_VALUE = pTX_VALUE,
                            },
                            signature = pSignature
                        },
                        extraParameters = pExtraParameters
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
                        var des = JsonConvert.DeserializeObject<RootPayUIndividualPaymentWithTokenResponse>(res);
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
