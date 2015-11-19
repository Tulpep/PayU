using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Request.Request_Cross;
using Tulpep.PayULibrary.Models.Request.Request_PayUPayments.BankTransfer;
using Tulpep.PayULibrary.Models.Request.Request_PayUPayments.CreditCard;
using Tulpep.PayULibrary.Models.Response.Response_PayUPayments.BankTransfer;
using Tulpep.PayULibrary.Models.Response.Response_PayUPayments.CreditCard;
using Tulpep.PayULibrary.Services.ServicesHelpers;

namespace Tulpep.PayULibrary.Services.PaymentsService
{
    public class PaymentsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTest">Defines if the transaction will be sent as test mode</param>
        /// <param name="pCommand">Defines the command that will be aplied to the API, use Tulpep.PayULibrary.Cross.Constants to set it.</param>
        /// <param name="pLanguaje">Defines the languaje wich will be used in the API to generate the responses to the user, 
        /// use Tulpep.PayULibrary.Cross.Constants to set it.</param>
        /// <param name="productionOrTestApiKey"></param>
        /// <param name="productionOrTestApiLogIn"></param>
        /// <param name="productionOrTestAccountId"></param>
        /// <param name="productionOrTestMerchantId"></param>
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
        /// <param name="productionOrTestUrl"></param>
        /// <returns></returns>
        public RootPayUPaymentCreditCardResponse MakeACreditCardPayment(bool isTest, string pCommand, string pLanguaje, string productionOrTestApiKey,
            string productionOrTestApiLogIn, int productionOrTestAccountId, string productionOrTestMerchantId, Request_CreditCard_CreditCard pCreditCard,
            Request_TXVALUE pTX_VALUE, Request_CreditCard_Buyer pBuyer, Address pOrderShippingAddress, Request_CreditCard_Payer pPayer,
            Request_ExtraParameters pExtraParameters, string pPaymentCountry, string pPaymentMethod, string pType, string pUserAgent,
            string pDescription, string pNotifyUrl, string pReferenceCode, string pCookie, string pDeviceSessionId, string pIpAddress,
            string productionOrTestUrl)
        {

            var url = productionOrTestUrl;
            if (url != null)
            {
                string source = productionOrTestApiKey + "~" + productionOrTestMerchantId + "~" + pReferenceCode + "~" +
                    pTX_VALUE.value + "~" + pTX_VALUE.currency;
                MD5 md5Hash = MD5.Create();
                string pSignature = MD5Helper.GetMd5Hash(md5Hash, source);

                var jsonObject = new RootPayUPaymentCreditCardRequest()
                {
                    command = pCommand,
                    language = pLanguaje,
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
                            additionalValues = new Request_AdditionalValues()
                            {
                                TX_VALUE = pTX_VALUE
                            },
                            buyer = pBuyer,
                            description = pDescription,
                            language = pLanguaje,
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

                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    /// <completionlist cref="SSL">
                    /// Add here the SSL certificate 
                    /// </completionlist>
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    req.ContentType = "application/json; charset=utf-8";
                    req.Accept = "application/json";
                    req.Method = "POST";

                    byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                    req.ContentLength = bytes.Length;
                    System.IO.Stream os = req.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length);
                    os.Close();
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                        string res = sr.ReadToEnd();
                        var des = JsonConvert.DeserializeObject<RootPayUPaymentCreditCardResponse>(res);
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
        /// <param name="pLanguaje"></param>
        /// <param name="productionOrTestApiKey"></param>
        /// <param name="productionOrTestApiLogIn"></param>
        /// <param name="pPaymentCountry"></param>
        /// <param name="pPaymentMethod"></param>
        /// <param name="productionOrTestUrl"></param>
        /// <returns></returns>
        public RootPayUPaymentBankListResponse GetAvailableBankList(bool isTest, string pCommand, string pLanguaje, 
            string productionOrTestApiKey, string productionOrTestApiLogIn, string pPaymentCountry, string pPaymentMethod, 
            string productionOrTestUrl)
        {

            var url = productionOrTestUrl;
            if (url != null)
            {

                var jsonObject = new RootPayUPaymentBankListRequest()
                {
                    command = pCommand,
                    language = pLanguaje,
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

                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    /// <completionlist cref="SSL">
                    /// Add here the SSL certificate 
                    /// </completionlist>
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    req.ContentType = "application/json; charset=utf-8";
                    req.Accept = "application/json";
                    req.Method = "POST";

                    byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                    req.ContentLength = bytes.Length;
                    System.IO.Stream os = req.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length);
                    os.Close();
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                        string res = sr.ReadToEnd();
                        var des = JsonConvert.DeserializeObject<RootPayUPaymentBankListResponse>(res);
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
