using System;

namespace Tulpep.PayULibrary.Models.Request.Request_Cross
{
    public class Request_TXTAXRETURNBASE
    {
        //Format: Numeric Size: Max: 19 Min: 2
        //Description: Buyer’s contact phone.
        private double tx_value;
        public double value
        {
            get
            {
                return tx_value;
            }
            set
            {
                if (value.ToString().Length > 0 && value.ToString().Length < 20)
                {
                    tx_value = value;
                }
                else
                {
                    throw new Exception("The MAX length of tx_value is 19 MIN 1");
                }
            }
        }
        //Format: Alphanumeric Size: Max: 19 Min: 2
        //Description: Buyer’s contact phone.
        private string Currency;
        public string currency
        {
            get
            {
                return Currency;
            }
            set
            {
                if (value.Length == 3)
                {
                    Currency = value;
                }
                else
                {
                    throw new Exception("The length of currency is 3");
                }
            }
        }
    }
}
