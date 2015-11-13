using System;
using Tulpep.PayU.Library.Models.Request.Cross;

namespace Tulpep.PayU.Library.Models.Request.PayUPayments.CreditCard
{
    public class Order
    {
        //Format: Numeric
        //Description: The identifier of the account.
        public int accountId { get; set; }
        //Format: Alphanumeric Size: Min: 1 Max: 255
        //Description: The reference code of the order. 
        //             It represents the identifier of the transaction in the shop’s system.
        private string ReferenceCode;
        public string referenceCode
        {
            get
            {
                return ReferenceCode;
            }
            set
            {
                if (value.Length > 0 && value.Length < 256)
                {
                    ReferenceCode = value;
                }
                else
                {
                    throw new Exception("The MAX length of referenceCode is 255 MIN 1");
                }
            }
        }
        //Format: Alphanumeric Size: Min: 1 Max: 255
        //Description: The description of the order.
        private string Description;
        public string description
        {
            get
            {
                return Description;
            }
            set
            {
                if (value.Length > 0 && value.Length < 256)
                {
                    Description = value;
                }
                else
                {
                    throw new Exception("The MAX length of description is 255 MIN 1");
                }
            }
        }
        //Format: Alphanumeric Size: 2
        //Description: The language used in the emails that are sent to the buyer and seller.
        private string Language;
        public string language
        {
            get
            {
                return Language;
            }
            set
            {
                if (value.Length == 2)
                {
                    Language = value;
                }
                else
                {
                    throw new Exception("The length of language is 2");
                }
            }
        }
        //Format: Alphanumeric Size: Max: 255
        //Description: The signature associated with the order.
        private string Signature;
        public string signature
        {
            get
            {
                return Signature;
            }
            set
            {
                if (value.Length > 0 && value.Length < 256)
                {
                    Signature = value;
                }
                else
                {
                    throw new Exception("The MAX length of signature is 255");
                }
            }
        }
        //Format: Alphanumeric Size: Max: 2048
        //Description: The signature associated with the order.
        private string NotifyUrl;
        public string notifyUrl
        {
            get
            {
                return NotifyUrl;
            }
            set
            {
                if (value.Length > 0 && value.Length < 2049)
                {
                    NotifyUrl = value;
                }
                else
                {
                    throw new Exception("The MAX length of notifyUrl is 2048");
                }
            }
        }
        //Type: AdditionalValues
        //Description: Values or amounts associated with the order. In this field one amount per entry is sent.
        public AdditionalValues additionalValues { get; set; }
        //Type: Buyer
        //Description: Details of the buyer.
        public Buyer buyer { get; set; }
        //Type: ShippingAddress
        //Description: The shipping address.
        public Address shippingAddress { get; set; }
    }
}
