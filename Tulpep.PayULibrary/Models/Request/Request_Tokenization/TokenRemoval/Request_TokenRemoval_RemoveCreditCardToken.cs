namespace Tulpep.PayULibrary.Models.Request.Request_Tokenization.TokenRemoval
{
    public class Request_TokenRemoval_RemoveCreditCardToken
    {
        public string payerId { get; set; }
        public string creditCardTokenId { get; set; }
    }
}
