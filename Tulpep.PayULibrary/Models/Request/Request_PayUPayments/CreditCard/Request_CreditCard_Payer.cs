﻿using System;
using Tulpep.PayULibrary.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_PayUPayments.CreditCard
{
    public class Request_CreditCard_Payer
    {
        //Format: Alphanumeric Size: Max: 100
        //Description: Buyer’s identifier of the buyer in the shop’s system
        private string MerchantPayerId;
        public string merchantPayerId
        {
            get
            {
                return MerchantPayerId;
            }
            set
            {
                if (value.Length > 0 && value.Length < 101)
                {
                    MerchantPayerId = value;
                }
                else
                {
                    throw new Exception("The MAX length of merchantPayerId is 100 MIN 1");
                }
            }
        }
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
        //Format: Alphanumeric Size: Max: 20
        //Description: Buyer’s contact phone.
        private string DniNumber;
        public string dniNumber
        {
            get
            {
                return DniNumber;
            }
            set
            {
                if (value.Length > 0 && value.Length < 21)
                {
                    DniNumber = value;
                }
                else
                {
                    throw new Exception("The MAX length of dniNumber is 20 MIN 1");
                }
            }
        }
        public Address billingAddress { get; set; }
    }
}
