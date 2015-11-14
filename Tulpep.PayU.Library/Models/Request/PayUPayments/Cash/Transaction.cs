using System;

namespace Tulpep.PayU.Library.Models.Request.PayUPayments.Cash
{
    public class Transaction
    {
        //Type: Order Size: 
        //Description: The order data.
        public Order order { get; set; }
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
        //Format: Alphanumeric Size: 7
        //Description: Credit card’s expiration date, see examples of availability per payment means. Format YYYY/MM.
        private string ExpirationDate;
        public string expirationDate
        {
            get
            {
                return ExpirationDate;
            }
            set
            {
                if (value.Length == 7)
                {
                    ExpirationDate = value;
                }
                else
                {
                    throw new Exception("The length of securityCode is 7");
                }
            }
        }
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
    }
}
