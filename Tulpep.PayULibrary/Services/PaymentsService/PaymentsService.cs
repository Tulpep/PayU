using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Request.Request_Cross;
using Tulpep.PayULibrary.Models.Request.Request_PayUPayments.CreditCard;
using Tulpep.PayULibrary.Models.Response.Response_PayUPayments.CreditCard;
using Tulpep.PayULibrary.Services.ServicesHelpers;

namespace Tulpep.PayULibrary.Services.PaymentsService
{
    class PaymentsService
    {
        public RootPayUPaymentCreditCardResponse MakeAPayment(bool isTest, string pCookie, string pDeviceSessionId,
            Request_CreditCard_CreditCard pCreditCard, string pCommand, string pLanguaje, Request_TXVALUE pTX_VALUE,
            Request_CreditCard_Buyer pBuyer, Address pOrderShippingAddress, Request_CreditCard_Payer pPayer, string pPaymentCountry, string pPaymentMethod,
            string pType, string pUserAgent, Request_ExtraParameters pExtraParameters, string pIpAddress, string pDescription,
            string pNotifyUrl, string pReferenceCode)
        {

            var url = Constants.DefaultProductionPaymentsConnectionUrl;
            if (url != null)
            {
                string source = Constants.APIKey + "~" + Constants.MerchantId + "~" + pReferenceCode + "~" + pTX_VALUE.value + "~" + pTX_VALUE.currency;
                MD5 md5Hash = MD5.Create();
                string pSignature = MD5Helper.GetMd5Hash(md5Hash, source);

                var jsonObject = new RootPayUPaymentCreditCardRequest()
                {
                    command = pCommand,
                    language = pLanguaje,
                    merchant = new Merchant()
                    {
                        apiKey = Constants.APIKey,
                        apiLogin = Constants.APILogin
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
                            accountId = int.Parse(Constants.AccountId),
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
                    //Create an HttpClient instance
                    var client = new HttpClient();
                    client.BaseAddress = new Uri(Constants.DefaultProductionPaymentsConnectionUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
                    client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("es"));

                    var response = client.PostAsync("", new StringContent(requestJson, Encoding.UTF8, "application/json")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string res = response.Content.ReadAsStringAsync().Result;
                        var des = JsonConvert.DeserializeObject<RootPayUPaymentCreditCardResponse>(res);
                        if (des.code.Equals(Constants.SUCCESS))
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
