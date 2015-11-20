using Tulpep.PayULibrary.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_PayUPayments.ActivePaymentMethodsQuery
{
    public class RootPayUActivePaymentMethodRequest
    {
        public bool test { get; set; }
        public string language { get; set; }
        public string command { get; set; }
        public Merchant merchant { get; set; }
    }
}
