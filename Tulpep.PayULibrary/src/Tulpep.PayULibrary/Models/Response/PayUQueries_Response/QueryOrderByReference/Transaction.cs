using Tulpep.PayULibrary.Models.Response.Cross_Response;

namespace Tulpep.PayULibrary.Models.Response.PayUQueries_Response.QueryOrderByReference
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
        public AdditionalValues_Response additionalValues { get; set; }
        public ExtraParameters_Response extraParameters { get; set; }
    }
}
