namespace Tulpep.PayULibrary.Models.Response.Response_PayUQueries.TransactionResponseQuery
{
    public class Response_TransactionResponseQuery_Payload
    {
        public string state { get; set; }
        public string paymentNetworkResponseCode { get; set; }
        public string paymentNetworkResponseErrorMessage { get; set; }
        public string trazabilityCode { get; set; }
        public string authorizationCode { get; set; }
        public string pendingReason { get; set; }
        public string responseCode { get; set; }
        public string errorCode { get; set; }
        public string responseMessage { get; set; }
        public string transactionDate { get; set; }
        public string transactionTime { get; set; }
        public string operationDate { get; set; }
        public string extraParameters { get; set; }
    }
}
