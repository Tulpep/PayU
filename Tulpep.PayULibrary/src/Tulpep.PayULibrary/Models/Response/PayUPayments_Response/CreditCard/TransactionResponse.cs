using System;
using Tulpep.PayULibrary.Models.Response.Cross_Response;

namespace Tulpep.PayULibrary.Models.Response.PayUPayments_Response.CreditCard
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
        //Format: Alphanumeric Size: Max: 255
        //Description: The response code returned by the financial network.
        public string paymentNetworkResponseCode { get; set; }
        //Format: Alphanumeric Size: Max: 255
        //Description: The error message returned by the financial network.
        public string paymentNetworkResponseErrorMessage { get; set; }
        //Format: Alphanumeric Size: Max: 32
        //Description: The traceability code returned by the financial network. 
        public string trazabilityCode { get; set; }
        //Format: Alphanumeric Size: Max: 12
        //Description: The authorization code returned by the financial network.
        public string authorizationCode { get; set; }
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
        public string errorCode { get; set; }
        public string responseMessage { get; set; }
        public string transactionDate { get; set; }
        public string transactionTime { get; set; }
        public string operationDate { get; set; }
        public ExtraParameters_Response extraParameters { get; set; }
    }
}
