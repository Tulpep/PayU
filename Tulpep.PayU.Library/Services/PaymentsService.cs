using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using System.Text;
using Tulpep.PayU.Library.Cross;
using Tulpep.PayU.Library.Models.Request.Cross;
using Tulpep.PayU.Library.Models.Request.PayUPayments.CreditCard;
using Tulpep.PayU.Library.Models.Response.PayUPayments.CreditCard;

namespace Tulpep.PayU.Library.Services
{
    public class PaymentsService
    {

        public RootPayUPaymentCreditCardResponse MakeAPayment(bool isTest, string pCookie, string pDeviceSessionId, 
            CreditCard pCreditCard, string pSignature, string pCommand, string pLanguaje, TXVALUE pTX_VALUE,
            Buyer pBuyer, Address pOrderShippingAddress, Payer pPayer, string pPaymentCountry, string pPaymentMethod,
            string pType, string pUserAgent, ExtraParameters pExtraParameters, string pIpAddress, string pDescription,
            string pNotifyUrl, string pReferenceCode)
        {
            ResourceManager rm = new ResourceManager(typeof(Resources.Tulpep_PayUResources));
            var url = rm.GetString(Constants.DefaultTestPaymentsConnectionUrl);
            if (url != null)
            {
                var jsonObject = new RootPayUPaymentCreditCardRequest()
                {
                    command = pCommand,
                    language = pLanguaje,
                    merchant = new Merchant()
                    {
                        apiKey = rm.GetString(Constants.TestAPIKey),
                        apiLogin = rm.GetString(Constants.TestAPILogin)
                    },
                    test = isTest,
                    transaction = new Transaction()
                    {
                        cookie = pCookie,
                        creditCard = pCreditCard,
                        deviceSessionId = pDeviceSessionId,
                        extraParameters = pExtraParameters,
                        ipAddress = pIpAddress,
                        order = new Order()
                        {
                            accountId = int.Parse(rm.GetString(Constants.TestAccountId)),
                            additionalValues = new AdditionalValues()
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
                    // Create an HttpClient instance 
                    var client = new HttpClient(new HttpClientHandler
                    {
                        ClientCertificateOptions = ClientCertificateOption.Automatic
                    });
                    client.BaseAddress = new Uri(rm.GetString(Constants.DefaultTestPaymentsConnectionUrl));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
                    client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("es"));

                    var response = client.PostAsync("", new StringContent(requestJson, Encoding.UTF8, "application/json")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string res = response.Content.ReadAsStringAsync().Result;
                        var des = JsonConvert.DeserializeObject<RootPayUPaymentCreditCardResponse>(res);
                        if (des.code.Equals("SUCCESS"))
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
