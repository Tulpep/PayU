namespace Tulpep.PayULibrary.Models.Response.Tokenization_Response.IndividualPaymentWithToken
{
    class RootPayUIndividualPaymentWithTokenResponse
    {
        public string code { get; set; }
        public string error { get; set; }
        public TransactionResponse transactionResponse { get; set; }
    }
}
