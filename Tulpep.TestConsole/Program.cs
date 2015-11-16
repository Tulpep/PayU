using System;
using System.Security.Cryptography;
using System.Text;
using Tulpep.PayU.Library.Cross;
using Tulpep.PayU.Library.Models.Request.Cross;
using Tulpep.PayU.Library.Models.Request.PayUPayments.CreditCard;
using Tulpep.PayU.Library.Services;

namespace Tulpep.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            QueriesService ping = new QueriesService();
            Console.WriteLine(ping.pingPayU());
            PaymentsService pay = new PaymentsService();
            var pLanguaje = "es";
            var pCommand = "SUBMIT_TRANSACTION";
            var pReferenceCode = "testPanama1";
            var pDescription = "Test order Panama";
            var pNotifyUrl = "http://pruebaslap.xtrweb.com/lap/pruebconf.php";
            var pShippingAddress = new Address()
            {
                country = "CO"
            };
            var pBuyer = new Buyer()
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
            var TX_VALUE = new TXVALUE()
            {
                value = 100000,
                currency = "COP"
            };
            var pCreditCard = new CreditCard()
            {
                number = "5471302114439010",
                securityCode = "934",
                expirationDate = "2018/01",
                name = "test"
            };
            var pType = "AUTHORIZATION_AND_CAPTURE";
            var pPaymentMethod = Constants.MASTERCARD;
            var pPaymentCountry = "CO";
            var pPayer = new Payer()
            {
                fullName = "APPROVED",
                emailAddress = "test@payulatam.com"
            };
            var pIpAddress = "127.0.0.1";
            var pCookie = "cookie_52278879710130";
            var pUserAgent = "Firefox";
            var pExtraParameters = new ExtraParameters()
            {
                INSTALLMENTS_NUMBER = 1,
                RESPONSE_URL = "http://www.misitioweb.com/respuesta.php"
            };
            var pDeviceSessionId = "vghs6tvkcle931686k1900o6e1";
            var pTest = true;
            string source = "6u39nqhq8ftd0hlvnjfs66eh8c~500238~" + pReferenceCode+"~"+TX_VALUE.value+"~COP";
            MD5 md5Hash = MD5.Create();
            string hash = GetMd5Hash(md5Hash, source);
            Console.WriteLine(pay.MakeAPayment(pTest, pCookie, pDeviceSessionId, pCreditCard, hash, pCommand, pLanguaje,TX_VALUE, 
                pBuyer, pShippingAddress, pPayer, pPaymentCountry, pPaymentMethod, pType, pUserAgent, pExtraParameters, pIpAddress,
                pDescription, pNotifyUrl, pReferenceCode));
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
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
