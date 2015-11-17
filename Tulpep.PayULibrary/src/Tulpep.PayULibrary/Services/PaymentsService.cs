using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Request.Request_Cross;
using Tulpep.PayULibrary.Models.Request.Request_PayUPayments.CreditCard;
using Tulpep.PayULibrary.Models.Response.PayUPayments_Response.CreditCard;

namespace Tulpep.PayULibrary.Services
{
    public class PaymentsService
    {

        public RootPayUPaymentCreditCardResponse MakeAPayment(bool isTest, string pCookie, string pDeviceSessionId,
            CreditCard pCreditCard, string pCommand, string pLanguaje, TXVALUE pTX_VALUE,
            Buyer pBuyer, Address pOrderShippingAddress, Payer pPayer, string pPaymentCountry, string pPaymentMethod,
            string pType, string pUserAgent, Request_ExtraParameters pExtraParameters, string pIpAddress, string pDescription,
            string pNotifyUrl, string pReferenceCode)
        {

            var url = Constants.DefaultTestPaymentsConnectionUrl;
            if (url != null)
            {
                string source = Constants.TestAPIKey + "~" + Constants.TestMerchantId + "~" + pReferenceCode + "~" + pTX_VALUE.value + "~" + Constants.CO;
                MD5 md5Hash = MD5.Create();
                string pSignature = GetMd5Hash(md5Hash, source);

                var jsonObject = new RootPayUPaymentCreditCardRequest()
                {
                    command = pCommand,
                    language = pLanguaje,
                    merchant = new Merchant()
                    {
                        apiKey = Constants.TestAPIKey,
                        apiLogin = Constants.TestAPILogin
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
                            accountId = int.Parse(Constants.TestAccountId),
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
                    client.BaseAddress = new Uri(Constants.DefaultTestPaymentsConnectionUrl);
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

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
