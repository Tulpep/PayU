using Tulpep.PayU.Library.Models.Response.Cross;

namespace Tulpep.PayU.Library.Models.Response.PayUQueries.QueryOrderByReference
{
    public class Transaction
    {
        public string id { get; set; }
        public string order { get; set; }
        public CreditCard creditCard { get; set; }
        public string type { get; set; }
        public string parentTransactionId { get; set; }
        public string paymentMethod { get; set; }
        public string source { get; set; }
        public string paymentCountry { get; set; }
        public TransactionResponse transactionResponse { get; set; }
        public object deviceSessionId { get; set; }
        public string ipAddress { get; set; }
        public string cookie { get; set; }
        public string userAgent { get; set; }
        public string expirationDate { get; set; }
        public Payer payer { get; set; }
        public AdditionalValues additionalValues { get; set; }
        public ExtraParameters extraParameters { get; set; }
    }
}
