using System;

namespace Tulpep.PayULibrary.Models.Request.Request_PayUPayments.CreditCard
{
    public class Request_CreditCard_CreditCard
    {
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
        //Format: Alphanumeric Size: Min: 1 Max: 4
        //Description: Credit card’s security (CVC2, CVV2, CID).
        private string SecurityCode;
        public string securityCode
        {
            get
            {
                return SecurityCode;
            }
            set
            {
                if (value.Length > 0 && value.Length < 5)
                {
                    SecurityCode = value;
                }
                else
                {
                    throw new Exception("The MAX length of securityCode is 1 and MIN 4");
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
        //Format: Alphanumeric Size: Min: 1 Max: 255
        //Description: The name on the credit card.
        private string Name;
        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                if (value.Length > 0 && value.Length < 256)
                {
                    Name = value;
                }
                else
                {
                    throw new Exception("The MAX length of name is 1 and MIN 255");
                }
            }
        }
    }
}
