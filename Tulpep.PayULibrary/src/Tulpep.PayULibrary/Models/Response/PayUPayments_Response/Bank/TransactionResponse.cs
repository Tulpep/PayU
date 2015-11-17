using System;
using Tulpep.PayULibrary.Models.Response.Cross_Response;

namespace Tulpep.PayULibrary.Models.Response.PayUPayments_Response.Bank
{
    public class TransactionResponse
    {
        //Format: Numeric Size:
        //Description: 	The generated or existing order identifier within PayU.
        public int orderId { get; set; }
        //Format: Alphanumeric Size: 36
        //Description: The identifier of the transaction within PayU.
        private string TransactionId;
        public string transactionId
        {
            get
            {
                return TransactionId;
            }
            set
            {
                if (value.Length == 36)
                {
                    TransactionId = value;
                }
                else
                {
                    throw new Exception("The TransactionId length is 36");
                }
            }
        }
        //Format: Alphanumeric Size: Max: 32
        //Description: The identifier of the transaction within PayU.
        private string State;
        public string state
        {
            get
            {
                return State;
            }
            set
            {
                if (value.Length > 0 && value.Length < 33)
                {
                    State = value;
                }
                else
                {
                    throw new Exception("The MAX State length is 32 MIN 1");
                }
            }
        }
        public string pendingReason { get; set; }
        //Format: Alphanumeric Size: Max: 64
        //Description: The identifier of the transaction within PayU.
        private string ResponseCode;
        public string responseCode
        {
            get
            {
                return ResponseCode;
            }
            set
            {
                if (value.Length > 0 && value.Length < 65)
                {
                    ResponseCode = value;
                }
                else
                {
                    throw new Exception("The MAX ResponseCode length is 64 MIN 1");
                }
            }
        }
        public ExtraParameters_Response extraParameters { get; set; }
    }
}
