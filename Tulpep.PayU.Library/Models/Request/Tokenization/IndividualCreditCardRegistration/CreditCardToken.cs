using System;

namespace Tulpep.PayU.Library.Models.Request.Tokenization.IndividualCreditCardRegistration
{
    public class CreditCardToken
    {
        //Format: Alphanumeric Size: Max: 100
        //Description: Buyer’s identifier of the buyer in the shop’s system
        private string PayerId;
        public string payerId
        {
            get
            {
                return PayerId;
            }
            set
            {
                if (value.Length > 0 && value.Length < 101)
                {
                    PayerId = value;
                }
                else
                {
                    throw new Exception("The MAX length of PayerId is 100 MIN 1");
                }
            }
        }
        //Format: Alphanumeric Size: Max: 150
        //Description: Buyer’s full names.
        private string Name;
        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                if (value.Length > 0 && value.Length < 151)
                {
                    Name = value;
                }
                else
                {
                    throw new Exception("The MAX length of Name is 150 MIN 1");
                }
            }
        }
        //Format: Alphanumeric Size: Max: 20
        //Description: Buyer’s contact phone.
        private string IdentificationNumber;
        public string identificationNumber
        {
            get
            {
                return IdentificationNumber;
            }
            set
            {
                if (value.Length > 0 && value.Length < 21)
                {
                    IdentificationNumber = value;
                }
                else
                {
                    throw new Exception("The MAX length of dniNumber is 20 MIN 1");
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
        //Format: Alphanumeric Size: Min: 13 Max: 20
        //Description: Credit card’s number.
        private string Number;
        public string number
        {
            get
            {
                return Number;
            }
            set
            {
                if (value.Length > 12 && value.Length < 21)
                {
                    Number = value;
                }
                else
                {
                    throw new Exception("The MAX length of number is 20 and MIN 13");
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
    }
}
