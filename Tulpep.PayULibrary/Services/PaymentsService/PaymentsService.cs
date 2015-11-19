using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Request.Request_Cross;
using Tulpep.PayULibrary.Models.Request.Request_PayUPayments.CreditCard;
using Tulpep.PayULibrary.Models.Response.Response_PayUPayments.CreditCard;
using Tulpep.PayULibrary.Services.ServicesHelpers;

namespace Tulpep.PayULibrary.Services.PaymentsService
{
    public class PaymentsService
    {
        public RootPayUPaymentCreditCardResponse MakeAPayment(bool isTest, string pCommand, string pLanguaje, string productionOrTestApiKey,
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

                Console.Write(requestJson);
                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //Add these, as we're doing a POST
                    req.ContentType = "application/json; charset=utf-8";
                    req.Accept = "application/json";
                    req.Method = "POST";
                    //We need to count how many bytes we're sending. 
                    //Post'ed Faked Forms should be name=value&
                    byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                    req.ContentLength = bytes.Length;
                    System.IO.Stream os = req.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length); //Push it out there
                    os.Close();
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    if (resp == null)
                        return null;

                    if (resp.StatusCode == HttpStatusCode.OK)
                    {

                        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                        string res = sr.ReadToEnd();
                        var des = JsonConvert.DeserializeObject<RootPayUPaymentCreditCardResponse>(res);
                        if (des.code.Equals(Constants.SUCCESS))
                        {
                            Console.Write(res);
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
