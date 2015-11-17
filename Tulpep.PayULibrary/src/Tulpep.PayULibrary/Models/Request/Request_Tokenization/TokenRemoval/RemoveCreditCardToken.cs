namespace Tulpep.PayULibrary.Models.Request.Request_Tokenization.TokenRemoval
{
    public class RemoveCreditCardToken
    {
        public string payerId { get; set; }
        public string creditCardTokenId { get; set; }
    }
}
