using Tulpep.PayULibrary.Models.Request.Request_Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_Tokenization.IndividualPaymentWithToken
{
    public class Transaction
    {
        public Order order { get; set; }
        public Payer payer { get; set; }
        public string creditCardTokenId { get; set; }
        public Request_ExtraParameters extraParameters { get; set; }
        public string type { get; set; }
        public string paymentMethod { get; set; }
        public string paymentCountry { get; set; }
        public string deviceSessionId { get; set; }
        public string ipAddress { get; set; }
        public string cookie { get; set; }
        public string userAgent { get; set; }
    }
}
