using System;
using Tulpep.PayU.Library.Models.Request.Cross;

namespace Tulpep.PayU.Library.Models.Request.Tokenization.MassivePaymentsWithToken
{
    //This feature will allow you to make massive collections using the Token that were previously created by our system
    //For this functionality you need to create a CSV file under the following conditions:  
    //Each transaction register to be processed must contain its processing data separated by commas in the following order: 
    //Account ID (identifier of the virtual PayU account), Token, security code, number of installments, sale description, 
    //buyer’s email, currency (ISO code), total (including tax), tax, base value of reimbursement, additional value, language (ISO code).
    //The file should have no header. The first line shows the first record.
    //The file must be encoded under the UTF-8 standard.
    //The file must not have more than 10,000 records
    public class RootPayUMassivePaymentsWithTokenRequest
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
        public string contentFile { get; set; }
    }
}
