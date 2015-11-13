using Tulpep.PayU.Library.Models.Request.Cross;

namespace Tulpep.PayU.Library.Models.Request.PayUPayments.Cash
{
    public class RootPayUPaymentCashRequest
    {
        public string language { get; set; }
        public string command { get; set; }
        public Merchant merchant { get; set; }
        public Transaction transaction { get; set; }
        public bool test { get; set; }
    }
}
