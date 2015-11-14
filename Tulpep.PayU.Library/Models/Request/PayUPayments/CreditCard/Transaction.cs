using System;
using Tulpep.PayU.Library.Models.Request.Cross;

namespace Tulpep.PayU.Library.Models.Request.PayUPayments.CreditCard
{
    public class Transaction
    {
        //Type: Order Size: 
        //Description: The order data.
        public Order order { get; set; }
        //Type: Payer Size: 
        //Description: Payer’s data.
        public Payer payer { get; set; }
        //Type: CreditCard Size: 
        //Description: Credit card’s data.
        public CreditCard creditCard { get; set; }
        //Type: ExtraParameters Size: 
        //Description: Contains the Information of a parameter.
        public ExtraParameters extraParameters { get; set; }
        //Format: Alphanumeric Size: 32
        //Description: For authorization and capture: AUTHORIZATION_AND_CAPTURE
        //             For authorization: AUTHORIZATION
        private string Type;
        public string type
        {
            get
            {
                return Type;
            }
            set
            {
                if (value.Length < 32)
                {
                    Type = value;
                }
                else
                {
                    throw new Exception("The length of type is 32");
                }
            }
        }
        //Format: Alphanumeric Size: 32
        //Description: Payment method.
        private string PaymentMethod;
        public string paymentMethod
        {
            get
            {
                return PaymentMethod;
            }
            set
            {
                if (value.Length < 32)
                {
                    PaymentMethod = value;
                }
                else
                {
                    throw new Exception("The length of type is 32");
                }
            }
        }
        //Format: Alphanumeric Size: 2
        //Description: The Country where the web is published
        private string PaymentCountry;
        public string paymentCountry
        {
            get
            {
                return PaymentCountry;
            }
            set
            {
                if (value.Length == 2)
                {
                    PaymentCountry = value;
                }
                else
                {
                    throw new Exception("The length of paymentCountry is 2");
                }
            }
        }
        //Format: Alphanumeric Size: MAx = 255
        //Description: The session identifier of the device where the transaction was performed from.
        private string DeviceSessionId;
        public string deviceSessionId
        {
            get
            {
                return DeviceSessionId;
            }
            set
            {
                if (value.Length <= 255)
                {
                    DeviceSessionId = value;
                }
                else
                {
                    throw new Exception("The max length of deviceSessionId is 255");
                }
            }
        }
        //Format: Alphanumeric Size: MAx = 39
        //Description: The IP address of the device where the transaction was performed from.
        private string IpAddress;
        public string ipAddress
        {
            get
            {
                return IpAddress;
            }
            set
            {
                if (value.Length <= 39)
                {
                    IpAddress = value;
                }
                else
                {
                    throw new Exception("The max length of ipAddress is 39");
                }
            }
        }
        //Format: Alphanumeric Size: MAx = 255
        //Description: The cookie stored on the device where the transaction was performed from.
        private string Cookie;
        public string cookie
        {
            get
            {
                return Cookie;
            }
            set
            {
                if (value.Length <= 255)
                {
                    Cookie = value;
                }
                else
                {
                    throw new Exception("The max length of cookie is 255");
                }
            }
        }
        //Format: Alphanumeric Size: MAx = 1024
        //Description: The user agent of the browser from which the transaction was performed.
        private string UserAgent;
        public string userAgent
        {
            get
            {
                return UserAgent;
            }
            set
            {
                if (value.Length <= 1024)
                {
                    UserAgent = value;
                }
                else
                {
                    throw new Exception("The max length of userAgent is 1024");
                }
            }
        }
    }
}
