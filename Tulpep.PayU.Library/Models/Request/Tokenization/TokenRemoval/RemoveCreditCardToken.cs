namespace Tulpep.PayU.Library.Models.Request.Tokenization.TokenRemoval
{
    public class RemoveCreditCardToken
    {
        public string payerId { get; set; }
        public string creditCardTokenId { get; set; }
    }
}
