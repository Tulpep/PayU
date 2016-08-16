using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Request.Request_Cross;
using Tulpep.PayULibrary.Models.Request.Request_PayUPayments.CreditCard;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.NewCard;
using Tulpep.PayULibrary.Models.Request.Request_Tokenization.IndividualPaymentWithToken;
using Tulpep.PayULibrary.Services.PaymentsService;
using Tulpep.PayULibrary.Services.QueriesService;
using Tulpep.PayULibrary.Services.RecurringPaymentsService;
using Tulpep.PayULibrary.Services.TokenizationService;

namespace TestPayU
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var pLanguaje = PayU_Constants.LANGUAGE_ES;
                var pCommand = PayU_Constants.COMMAND_SUBMIT_TRANSACTION;
                var pReferenceCode = "TestCOlombia07";
                var pDescription = "Test order Panama";
                var pNotifyUrl = "http://pruebaslap.xtrweb.com/lap/pruebconf.php";
                var pShippingAddress = new Address()
                {
                    country = PayU_Constants.COUNTRY_CO
                };
                var pBuyer = new Request_CreditCard_Buyer()
                {
                    fullName = "APPROVED",
                    emailAddress = "test@payulatam.com",
                    dniNumber = "1155255887",
                    shippingAddress = new Address()
                    {
                        street1 = "Calle 93 B 17 – 25",
                        city = "Panama",
                        state = "Panama",
                        country = "CO",
                        postalCode = "000000",
                        phone = "5582254"
                    }
                };
                var pTX_VALUE = new Request_TXVALUE()
                {
                    value = 100000,
                    currency = "COP"
                };
                var pCreditCard = new Request_CreditCard_CreditCard()
                {
                    number = "4111111111111111",
                    securityCode = "123",
                    expirationDate = "2018/01",
                    name = "test"
                };
                var pType = PayU_Constants.TRANSACTION_TYPE_AUTHORIZATION_AND_CAPTURE;
                var pPaymentMethod = PayU_Constants.PAYMENT_METHOD_VISA;
                var pPaymentCountry = "CO";
                var pPayer = new Request_CreditCard_Payer()
                {
                    fullName = "APPROVED",
                    emailAddress = "test@payulatam.com"
                };
                var pIpAddress = "127.0.0.1";
                var pCookie = "cookie_52278879710130";
                var pUserAgent = "Firefox";
                var pExtraParameters = new Request_ExtraParameters()
                {
                    INSTALLMENTS_NUMBER = 1,
                    RESPONSE_URL = "http://www.misitioweb.com/respuesta.php"
                };
                var pDeviceSessionId = "vghs6tvkcle931686k1900o6e1";
                var pTest = false;

                List<Request_Recurring_AdditionalValue> pAddirionalValues = new List<Request_Recurring_AdditionalValue>();

                var plan_Val = new Request_Recurring_AdditionalValue()
                {
                    name = "PLAN_VALUE",
                    value = "6000",
                    currency = PayU_Constants.CURRENCY_COP
                };
                //var plan_Tax = new Request_Recurring_AdditionalValue()
                //{
                //    name = "PLAN_TAX",
                //    value = "160",
                //    currency = PayU_Constants.CURRENCY_COP
                //};
                //var return_Base = new Request_Recurring_AdditionalValue()
                //{
                //    name = "PLAN_TAX_RETURN_BASE",
                //    value = "1000",
                //    currency = PayU_Constants.CURRENCY_COP
                //};

                pAddirionalValues.Add(plan_Val);
                //pAddirionalValues.Add(plan_Tax);
                //pAddirionalValues.Add(return_Base);

                Console.WriteLine("Making a ping to the Payu API");
                Console.WriteLine((await QueriesService.PingTheApi(pTest, PayU_Constants.METHOD_PING, pLanguaje)).code);
                Console.WriteLine("Registering a Payment in the PayU system");
                var payment = await PaymentsService.MakeACreditCardPayment(pTest, pCommand, pLanguaje, pCreditCard,
                pTX_VALUE, true, pBuyer, pShippingAddress, pPayer, pExtraParameters, pPaymentCountry, pPaymentMethod, pType, pUserAgent,
                pDescription, pNotifyUrl, pReferenceCode, pCookie, pDeviceSessionId, pIpAddress);
                Console.WriteLine(payment.code);
                Console.WriteLine("Getting available list of bank ready in the PayU system");
                Console.WriteLine((await PaymentsService.GetAvailableBankList(pTest, PayU_Constants.COMMAND_GET_BANKS_LIST, pLanguaje,
                    PayU_Constants.COUNTRY_CO, PayU_Constants.PAYMENT_METHOD_PSE)).code);
                Console.WriteLine("Getting an order by reference code");
                Console.WriteLine((await QueriesService.GetOrderByReferenceCode(pTest, PayU_Constants.COMMAND_ORDER_DETAIL_BY_REFERENCE_CODE, pLanguaje,
                    pReferenceCode)).code);
                //Console.WriteLine("creating a recurring plan in the PayU system");
                //Console.WriteLine(RecurringPaymentsService.CreateAPlan(pLanguaje, "PuntoHome Premium Plan", "YEAR", "1", "4", "1", "1", "1", "0", "PHME_Premium_Plan_1", pAddirionalValues).id);
                //Console.WriteLine("query that plan in the PayU system");
                //var planExist = RecurringPaymentsService.GetAPlan(PayU_Constants.LANGUAGE_ES, "PHME_Premium_Plan_1");
                //Console.WriteLine(planExist != null ? planExist.id : "plan does not exist");
                //Console.WriteLine("updating a recurring plan in the PayU system");
                //Console.WriteLine(RecurringPaymentsService.UpdateAPlan(pLanguaje, "Larnia Premium Plan", "1", "1", "4", "PHME_Premium_Plan_1", pAddirionalValues).id);
                //Console.WriteLine("query updated plan in the PayU system");
                //planExist = RecurringPaymentsService.GetAPlan(PayU_Constants.LANGUAGE_ES, "PHME_Premium_Plan_1");
                //Console.WriteLine(planExist != null ? planExist.id : "plan does not exist");
                //Console.WriteLine("Getting an order by id code");
                //Console.WriteLine(QueriesService.GetOrderById(false, PayU_Constants.COMMAND_ORDER_DETAIL,
                //                 PayU_Constants.LANGUAGE_ES, payment.transactionResponse.orderId).code);
                //Console.WriteLine("Adding new costumer to payu");
                //var costId = RecurringPaymentsService.CreateACustomer(PayU_Constants.LANGUAGE_ES, "juan.hernandez@tulpep.com", "Juan Carlos Hernandez Ramos");
                //Console.WriteLine(costId.id);
                //Console.WriteLine("Query costumer to payu");
                //var custumer = RecurringPaymentsService.GetACustomer(PayU_Constants.LANGUAGE_ES, "35c576td0iya");
                //Console.WriteLine("Add New card to a subscription");
                //var planCreditCard = new Request_Subscription_Creation_NewCard_CreditCard()
                //{
                //    number = "4916523740316159",
                //    document = "103242915",
                //    expMonth = "01",
                //    expYear = "2018",
                //    name = "test",
                //    type = PayU_Constants.PAYMENT_METHOD_VISA,
                //    address = new Request_Recurring_Address()
                //    {
                //        line1 = "Calle 93 B 17 – 25",
                //        line2 = "Calle 93 B 17 – 25",
                //        line3 = "Calle 93 B 17 – 25",
                //        city = "Panama",
                //        state = "Panama",
                //        country = "CO",
                //        postalCode = "000000",
                //        phone = "5582254"
                //    }
                //};
                //var planList = new List<Request_Subscription_Creation_NewCard_CreditCard>();
                //planList.Add(planCreditCard);
                //var planCustomer = new Request_Subscription_Creation_NewCard_Customer()
                //{
                //    id = costId.id,
                //    creditCards = planList
                //};
                //Console.WriteLine(RecurringPaymentsService.CreateASubscriptionNewCard(PayU_Constants.LANGUAGE_ES, "1", "1", "0", planCustomer,
                //    new Request_Subscription_Creation_NewCard_Plan() { planCode = "PHME_Premium_Plan_1" }).id);
                //Console.WriteLine("Create a credit card token");
                //var createdCreditCard = RecurringPaymentsService.CreateACreditCard(PayU_Constants.LANGUAGE_ES, planCreditCard.document, planCreditCard.expMonth, planCreditCard.expYear,
                //    planCreditCard.name, planCreditCard.number, planCreditCard.type, planCreditCard.address, costId.id);
                //Console.WriteLine(createdCreditCard.token);
                //Console.WriteLine("Query created credit card token");
                //var cQueryToken = RecurringPaymentsService.GetACustomer(PayU_Constants.LANGUAGE_ES, "1ed3amsh85jq");
                //Console.WriteLine("Query created subscription");
                //var cQuerysubs = RecurringPaymentsService.GetASubscription(PayU_Constants.LANGUAGE_ES, "6a8df74s2au1");
                //var ValidUntil = cQuerysubs.currentPeriodEnd > 0 ? new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local).AddMilliseconds(cQuerysubs.currentPeriodEnd) : cQuerysubs.currentPeriodEnd == -1 ? DateTime.UtcNow.Date.AddMonths(2) : (DateTime?)null;
                //ValidUntil = cQuerysubs.currentPeriodStart > 0 ? new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local).AddMilliseconds(cQuerysubs.currentPeriodStart) : cQuerysubs.currentPeriodStart == -1 ? DateTime.UtcNow.Date.AddMonths(2) : (DateTime?)null;

                //Console.WriteLine("Query created billing");
                //var cQuerybill = RecurringPaymentsService.GetAnAdditionalChargeBySubscriptionId(PayU_Constants.LANGUAGE_ES, "6a8df74s2au1");

                //Console.WriteLine("delete subscription by id");
                //var deletedSubs = RecurringPaymentsService.DeleteASubscription(PayU_Constants.LANGUAGE_ES, "");
                //Console.WriteLine("Getting an order by reference code");
                //var consultbyReference = QueriesService.GetOrderByReferenceCode(pTest, PayU_Constants.COMMAND_ORDER_DETAIL_BY_REFERENCE_CODE, pLanguaje, "Recurring_Larnia_Plan_2 - 35c576td0iya");
                //var updatecredit = RecurringPaymentsService.UpdateASubscription(PayU_Constants.LANGUAGE_ES, "71276517-d745-478a-be18-733c9be4b79c", "fc910nd1zlba");

                //var deletecredit = RecurringPaymentsService.DeleteACreditCard(PayU_Constants.LANGUAGE_ES, "1ed3amsh85jq", "71276517-d745-478a-be18-733c9be4b79c");

                //Console.WriteLine(cQueryToken.number);
                //Console.WriteLine("Make a payment with created credit card token");
                //var pBuyerT = new Request_IndividualPaymentWithToken_Buyer()
                //{
                //    fullName = "APPROVED",
                //    emailAddress = "test@payulatam.com",
                //    dniNumber = "1155255887",
                //    shippingAddress = new Address()
                //    {
                //        street1 = "Calle 93 B 17 – 25",
                //        city = "Panama",
                //        state = "Panama",
                //        country = "CO",
                //        postalCode = "000000",
                //        phone = "5582254"
                //    }
                //};
                //var pPayerT = new Request_IndividualPaymentWithToken_Payer()
                //{
                //    fullName = "APPROVED",
                //    emailAddress = "test@payulatam.com"
                //};
                //var payToken = TokenizationService.IndividualPaymentWithToken(false, PayU_Constants.COMMAND_SUBMIT_TRANSACTION, PayU_Constants.LANGUAGE_ES,
                //    cQueryToken.token, pTX_VALUE, pBuyerT, pShippingAddress, pPayerT, pExtraParameters, PayU_Constants.COUNTRY_CO, cQueryToken.type,
                //    PayU_Constants.TRANSACTION_TYPE_AUTHORIZATION_AND_CAPTURE, pUserAgent, pDescription, pNotifyUrl, pReferenceCode, pCookie,
                //    pDeviceSessionId, pIpAddress);
                //Console.WriteLine(payToken.code);
                //Console.WriteLine("Delete created credit card");
                //var cdeleteToken = RecurringPaymentsService.DeleteACreditCard(PayU_Constants.LANGUAGE_ES, costId.id, createdCreditCard.token);

                //Console.WriteLine("creating a recurring plan in the PayU system");
                //Console.WriteLine(RecurringPaymentsService.CreateAPlan(PayU_Constants.LANGUAGE_ES, "Recurring_Larnia_Plan_10", "MONTH", "1", "-1", "1", "0", "0", "1", "Recurring_Larnia_Plan_10", pAddirionalValues).id);
                //Console.WriteLine(RecurringPaymentsService.CreateAPlan(PayU_Constants.LANGUAGE_ES, "Recurring_Larnia_Plan_20", "MONTH", "1", "-1", "1", "0", "0", "1", "Recurring_Larnia_Plan_20", pAddirionalValues).id);
                //Console.WriteLine(RecurringPaymentsService.CreateAPlan(PayU_Constants.LANGUAGE_ES, "Recurring_Larnia_Plan_30", "MONTH", "1", "-1", "1", "0", "0", "1", "Recurring_Larnia_Plan_30", pAddirionalValues).id);
                //Console.WriteLine(RecurringPaymentsService.CreateAPlan(PayU_Constants.LANGUAGE_ES, "Recurring_Larnia_Plan_40", "MONTH", "1", "-1", "1", "0", "0", "1", "Recurring_Larnia_Plan_40", pAddirionalValues).id);

                //var deletedPlan = RecurringPaymentsService.DeleteAPlan(PayU_Constants.LANGUAGE_ES, "Recurring_Larnia_Plan_10");
                //deletedPlan = RecurringPaymentsService.DeleteAPlan(PayU_Constants.LANGUAGE_ES, "Recurring_Larnia_Plan_20");
                //deletedPlan = RecurringPaymentsService.DeleteAPlan(PayU_Constants.LANGUAGE_ES, "Recurring_Larnia_Plan_30");
                //deletedPlan = RecurringPaymentsService.DeleteAPlan(PayU_Constants.LANGUAGE_ES, "Recurring_Larnia_Plan_40");

                Console.WriteLine("Press any key to stop...");
                Console.ReadKey();
            }).Wait();
        }
    }
}
