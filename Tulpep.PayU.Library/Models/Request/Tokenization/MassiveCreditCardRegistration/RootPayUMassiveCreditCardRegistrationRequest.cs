using System;
using Tulpep.PayU.Library.Models.Request.Cross;

namespace Tulpep.PayU.Library.Models.Request.Tokenization.MassiveCreditCardRegistration
{
    //Using this feature you can register various customer’s credit card data and get token sequential numbers.
    //For massive credit card tokenization you must create a file with CSV format with the following conditions:  
    //Each credit card register to be tokenized must contain data for the registration of a credit card, 
    //separated by commas in the following order: Payer ID, full name, credit card number, expiration date, franchise, 
    //and identification number.
    //The file should have no header. The first line shows the first record.
    //The file must be encoded under the UTF-8 standard.
    //The file must not have more than 10,000 registers.
    public class RootPayUMassiveCreditCardRegistrationRequest
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
