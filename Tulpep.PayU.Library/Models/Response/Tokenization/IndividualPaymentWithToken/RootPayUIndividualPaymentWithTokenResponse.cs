namespace Tulpep.PayU.Library.Models.Response.Tokenization.IndividualPaymentWithToken
{
    class RootPayUIndividualPaymentWithTokenResponse
    {
        public string code { get; set; }
        public string error { get; set; }
        public TransactionResponse transactionResponse { get; set; }
    }
}
