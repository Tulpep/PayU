using Tulpep.PayU.Library.Models.Request.Cross;

namespace Tulpep.PayU.Library.Models.Request.PayUPayments.Bank
{
    public class RootPayUPaymentBankRequest
    {
        public string isTest { get; set; }
        public string language { get; set; }
        public string command { get; set; }
        public Merchant merchant { get; set; }
        public Transaction transaction { get; set; }
    }
}
