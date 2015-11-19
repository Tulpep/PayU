namespace Tulpep.PayULibrary.Models.Response.Response_Tokenization.IndividualPaymentWithToken
{
    public class RootPayUIndividualPaymentWithTokenResponse
    {
        public string code { get; set; }
        public string error { get; set; }
        public Response_IndividualPaymentWithToken_TransactionResponse transactionResponse { get; set; }
    }
}
