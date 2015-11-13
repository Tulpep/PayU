namespace Tulpep.PayU.Library.Models.Response.Tokenization.TokenRemoval
{
    public class RootPayUTokenRemovalResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public CreditCardToken creditCardToken { get; set; }
    }
}
