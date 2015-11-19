using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.CreditCard.Query
{
    public class RootPayUCreditCardQueryResponse
    {
        public string token { get; set; }
        public string customerId { get; set; }
        public string number { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string document { get; set; }
        public Response_Recurring_Address address { get; set; }
    }
}
