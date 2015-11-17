using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tulpep.PayULibrary.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_PayUPayments.BankTransfer
{
    // You will also have to collect all data required bt PSE to handle the transaction.
    public class RootPayUPaymentBankTransferRequest
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
        public Transaction transaction { get; set; }
        public bool test { get; set; }
    }
}
