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

        public RootPayUPaymentCreditCardResponse MakeAPayment()
        {
            ResourceManager rm = new ResourceManager(typeof(Resources.Tulpep_PayUResources));
            var url = rm.GetString(Constants.DefaultProductionPaymentsConnectionUrl);
            if (url != null)
            {
                var jsonObject = new RootPayUPaymentCreditCardRequest()
                {
                    command = Constants.SUBMIT_TRANSACTION,
                    language = Constants.es,
                    merchant = new Merchant()
                    {
                        apiKey = rm.GetString(Constants.APIKey),
                        apiLogin = rm.GetString(Constants.APILogin)
                    },
                    test = false,
                    transaction = new Transaction()
                    {
                        cookie = "pt1t38347bs6jc9ruv2ecpv7o2",
                        creditCard = new CreditCard()
                        {
                            name = "REJECTED",
                            expirationDate = "2014/12",
                            securityCode = "321",
                            number = "4850110000000000"
                        },
                        deviceSessionId = "vghs6tvkcle931686k1900o6e1",
                        extraParameters = new ExtraParameters()
                        {
                            INSTALLMENTS_NUMBER = 1
                        },
                        ipAddress = "127.0.0.1",
                        order = new Order()
                        {
                            accountId = int.Parse(rm.GetString(Constants.AccountId)),
                            additionalValues = new AdditionalValues()
                            {
                                TX_VALUE = new TXVALUE()
                                {
                                    value = 10000,
                                    currency = "COP"
                                }
                            },
                            buyer = new Buyer()
                            {
                                merchantBuyerId = "1",
                                contactPhone = "7563126",
                                dniNumber = "5415668464654",
                                emailAddress = "buyer_test@test.com",
                                fullName = "First name and second buyer  name",
                                shippingAddress = new Address()
                                {
                                    city = "Medellin",
                                    country = "CO",
                                    phone = "7563126",
                                    postalCode = "000000",
                                    state = "Antioquia",
                                    street1 = "calle 100",
                                    street2 = "5555487"
                                }
                            },
                            description = "payment test",
                            language = Constants.es,
                            notifyUrl = "http://www.tes.com/confirmation",
                            referenceCode = "payment_test_00000001",
                            signature = CreateSignature.GenerateHash(rm.GetString(Constants.APIKey)+"~"+rm.GetString(Constants.MerchantId)+
                            "~payment_test_00000001~10000~COP", "Payment"),
                            shippingAddress = new Address()
                            {
                                street1 = "Viamonte",
                                street2 = "1366",
                                city = "Medellin",
                                country = "CO",
                                phone = "7563126",
                                postalCode = "000000",
                                state = "Antioquia"
                            }
                        },
                        payer = new Payer()
                        {
                            billingAddress = new Address()
                            {
                                city = "Bogota",
                                country = "CO",
                                phone = "7563126",
                                postalCode = "000000",
                                state = "Bogota DC",
                                street1 = "calle 93",
                                street2 = "125544"
                            },
                            contactPhone = "7563126",
                            dniNumber= "5415668464654",
                            emailAddress = "payer_test@test.com",
                            fullName = "First name and second payer name",
                            merchantPayerId = "1"
                        },
                        paymentCountry = "CO",
                        paymentMethod = "VISA",
                        type = Constants.AUTHORIZATION_AND_CAPTURE,
                        userAgent = "Mozilla/5.0 (Windows NT 5.1; rv:18.0) Gecko/20100101 Firefox/18.0"
                    }
                };

                string requestJson = JsonConvert.SerializeObject(jsonObject);
                try
                {
                    // Create an HttpClient instance 
                    //var client = new HttpClient(new HttpClientHandler
                    //{
                    //    ClientCertificateOptions = ClientCertificateOption.Automatic
                    //});
                    var client = new HttpClient();
                    client.BaseAddress = new Uri(rm.GetString(Constants.DefaultProductionPaymentsConnectionUrl));
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
