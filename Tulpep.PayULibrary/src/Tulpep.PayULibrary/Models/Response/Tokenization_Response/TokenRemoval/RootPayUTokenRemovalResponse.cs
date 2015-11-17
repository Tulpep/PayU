namespace Tulpep.PayULibrary.Models.Response.Tokenization_Response.TokenRemoval
{
    public class RootPayUTokenRemovalResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public CreditCardToken creditCardToken { get; set; }
    }
}
