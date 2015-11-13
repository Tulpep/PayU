using System;
using System.Collections.Generic;

namespace Tulpep.PayU.Library.Models.Response.PayUPayments.BankTransfer
{
    class RootPayUPaymentBankListResponse
    {
        //Format: Alphanumeric Size:
        //Description: The overall response code. ERROR, SUCCESS.
        public string code { get; set; }
        //Format: Alphanumeric Size: Max: 2048
        //Description: The message associated with the error when code is ERROR.
        private string Error;
        public string error
        {
            get
            {
                return Error;
            }
            set
            {
                if (value != null)
                {
                    if (value.Length > 0 && value.Length < 2049)
                    {
                        Error = value;
                    }
                    else
                        throw new Exception("The MAX length of error is 2048");
                }
                else
                {
                    Error = value;
                }
            }
        }
        public List<Bank> banks { get; set; }
    }
}
