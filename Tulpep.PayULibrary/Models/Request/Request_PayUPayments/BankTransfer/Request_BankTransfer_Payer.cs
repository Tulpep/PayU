using System;

namespace Tulpep.PayULibrary.Models.Request.Request_PayUPayments.BankTransfer
{
    public class Request_BankTransfer_Payer
    {
        //Format: Alphanumeric Size: Max: 150
        //Description: Buyer’s full names.
        private string FullName;
        public string fullName
        {
            get
            {
                return FullName;
            }
            set
            {
                if (value.Length > 0 && value.Length < 151)
                {
                    FullName = value;
                }
                else
                {
                    throw new Exception("The MAX length of fullName is 150 MIN 1");
                }
            }
        }
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
        //Format: Alphanumeric Size: Max: 20
        //Description: Buyer’s contact phone.
        private string ContactPhone;
        public string contactPhone
        {
            get
            {
                return ContactPhone;
            }
            set
            {
                if (value.Length > 0 && value.Length < 21)
                {
                    ContactPhone = value;
                }
                else
                {
                    throw new Exception("The MAX length of contactPhone is 20 MIN 1");
                }
            }
        }
    }
}
