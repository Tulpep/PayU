using Tulpep.PayU.Library.Models.Request.Cross;

namespace Tulpep.PayU.Library.Models.Request.PayUQueries.TransactionResponseQuery
{
    public class RootPayUTransactionResponseQueryRequest
    {
        public bool test { get; set; }
        public string language { get; set; }
        public string command { get; set; }
        public Merchant merchant { get; set; }
        public Details details { get; set; }
    }
}
