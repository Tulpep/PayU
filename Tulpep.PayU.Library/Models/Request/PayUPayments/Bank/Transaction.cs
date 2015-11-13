using System;

namespace Tulpep.PayU.Library.Models.Request.PayUPayments.Bank
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
                if (value.Length == 32)
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
                if (value.Length == 32)
                {
                    PaymentMethod = value;
                }
                else
                {
                    throw new Exception("The length of type is 32");
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
        //Type: Payer Size: 
        //Description: Payer’s data.
        public Payer payer { get; set; }
    }
}
