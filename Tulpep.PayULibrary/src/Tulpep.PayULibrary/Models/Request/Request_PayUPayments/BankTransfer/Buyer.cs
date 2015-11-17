using System;

namespace Tulpep.PayULibrary.Models.Request.Request_PayUPayments.BankTransfer
{
    public class Buyer
    {
        //Format: Alphanumeric Size: Max: 255
        //Description: Buyer’s email.
        private string EmailAddress;
        public string emailAddress
        {
            get
            {
                return EmailAddress;
            }
            set
            {
                if (value.Length > 0 && value.Length < 256)
                {
                    EmailAddress = value;
                }
                else
                {
                    throw new Exception("The MAX length of emailAddress is 255 MIN 1");
                }
            }
        }
    }
}
