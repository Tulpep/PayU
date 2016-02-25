﻿using System;
using System.Collections.Generic;
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Request.Request_Cross;
using Tulpep.PayULibrary.Models.Request.Request_PayUPayments.CreditCard;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;
using Tulpep.PayULibrary.Services.PaymentsService;
using Tulpep.PayULibrary.Services.QueriesService;
using Tulpep.PayULibrary.Services.RecurringPaymentsService;

namespace TestPayU
{
    class Program
    {
        static void Main(string[] args)
        {
            var pLanguaje = PayU_Constants.LANGUAGE_ES;
            var pCommand = PayU_Constants.COMMAND_SUBMIT_TRANSACTION;
            var pReferenceCode = "TestCOlombia";
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
            var pTest = true;

            List<Request_Recurring_AdditionalValue> pAddirionalValues = new List<Request_Recurring_AdditionalValue>();

            var plan_Val = new Request_Recurring_AdditionalValue()
            {
                name = "PLAN_VALUE",
                value = "6000",
                currency = PayU_Constants.CURRENCY_COP
            };
            var plan_Tax = new Request_Recurring_AdditionalValue()
            {
                name = "PLAN_TAX",
                value = "160",
                currency = PayU_Constants.CURRENCY_COP
            };
            var return_Base = new Request_Recurring_AdditionalValue()
            {
                name = "PLAN_TAX_RETURN_BASE",
                value = "1000",
                currency = PayU_Constants.CURRENCY_COP
            };

            pAddirionalValues.Add(plan_Val);
            pAddirionalValues.Add(plan_Tax);
            pAddirionalValues.Add(return_Base);

            Console.WriteLine("Making a ping to the Payu API");
            Console.WriteLine(QueriesService.PingTheApi(pTest, PayU_Constants.METHOD_PING, pLanguaje).code);
            Console.WriteLine("Registering a Payment in the PayU system");
            Console.WriteLine(PaymentsService.MakeACreditCardPayment(pTest, pCommand, pLanguaje, pCreditCard,
            pTX_VALUE, pBuyer, pShippingAddress, pPayer, pExtraParameters, pPaymentCountry, pPaymentMethod, pType, pUserAgent,
            pDescription, pNotifyUrl, pReferenceCode, pCookie, pDeviceSessionId, pIpAddress).code);
            Console.WriteLine("Getting available list of bank ready in the PayU system");
            Console.WriteLine(PaymentsService.GetAvailableBankList(pTest, PayU_Constants.COMMAND_GET_BANKS_LIST, pLanguaje,
                PayU_Constants.COUNTRY_CO, PayU_Constants.PAYMENT_METHOD_PSE).code);
            Console.WriteLine("Getting an order by reference code");
            Console.WriteLine(QueriesService.GetOrderByReferenceCode(pTest, PayU_Constants.COMMAND_ORDER_DETAIL_BY_REFERENCE_CODE, pLanguaje, pReferenceCode).code);
            Console.WriteLine("creating a recurring plan in the PayU system");
            Console.WriteLine(RecurringPaymentsService.CreateAPlan(pLanguaje, "PuntoHome Premium Plan", "YEAR", "1", "4", "1","1","1", "0", "PHME_Premium_Plan_1", pAddirionalValues).id);
            Console.WriteLine("query that plan in the PayU system");
            var planExist = RecurringPaymentsService.GetAPlan(PayU_Constants.LANGUAGE_ES, "PHME_Premium_Plan_1");
            Console.WriteLine(planExist != null ? planExist.id : "plan does not exist");
            Console.WriteLine("updating a recurring plan in the PayU system");
            Console.WriteLine(RecurringPaymentsService.UpdateAPlan(pLanguaje, "Larnia Premium Plan", "1", "1", "4", "PHME_Premium_Plan_1", pAddirionalValues).id);
            Console.WriteLine("query updated plan in the PayU system");
            planExist = RecurringPaymentsService.GetAPlan(PayU_Constants.LANGUAGE_ES, "PHME_Premium_Plan_1");
            Console.WriteLine(planExist != null ? planExist.id : "plan does not exist");
            Console.WriteLine("Getting an order by id code");
            Console.WriteLine(QueriesService.GetOrderById(false, PayU_Constants.COMMAND_ORDER_DETAIL,
                             PayU_Constants.LANGUAGE_ES, 7665206).code);
            Console.WriteLine("Adding new costumer to payu");
            var costId = RecurringPaymentsService.CreateACustomer(PayU_Constants.LANGUAGE_ES, "juan.hernandez@tulpep.com", "Juan Carlos Hernandez Ramos").id;
            Console.WriteLine(costId);
            Console.WriteLine("Query costumer to payu");
            Console.WriteLine(RecurringPaymentsService.GetACustomer(PayU_Constants.LANGUAGE_ES, costId).fullName);

            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }

    }
}