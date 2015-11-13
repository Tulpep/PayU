﻿using System;
using Tulpep.PayU.Library.Models.Request.Cross;

namespace Tulpep.PayU.Library.Models.Request.PayUPayments.BankTransfer
{
    // PSE is a two steps process so you have to call this Model to adquire 
    // the list of aviable banks
    public class RootPayUPaymentBankListRequest
    {
        //Format: Alphanumeric Size: 2
        //Description: The language used in the petition. 
        //             Used for error messages of the system.
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
                    throw new Exception("The length of languaje is two");
                }
            }
        }
        //Format: Alphanumeric Size: Max = 32
        //Description: Use SUBMIT_TRANSACTION.
        private string Command;
        public string command
        {
            get
            {
                return Command;
            }
            set
            {
                if (value.Length <= 32)
                {
                    Command = value;
                }
                else
                {
                    throw new Exception("The max length of command is 32");
                }
            }
        }
        //Type: Merchant Size: 
        //Description: Contains the authentication data.
        public Merchant merchant { get; set; }
        //Format: Boolean Size: 
        //Description: True if this is a test request, false otherwise. 
        //Depending on the type of transaction or operation, 
        //the behavior of this field varies according to the value.
        public bool test { get; set; }
        public BankListInformation bankListInformation { get; set; }
    }
}
