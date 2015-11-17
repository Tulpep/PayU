namespace Tulpep.PayULibrary.Models.Response.Response_Tokenization.TokenRemoval
{
    public class RootPayUTokenRemovalResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public Response_TokenRemoval_CreditCardToken creditCardToken { get; set; }
    }
}
