using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.NewCard
{
    public class Request_Subscription_Creation_NewCard_CreditCard
    {
        public string name { get; set; }
        public string document { get; set; }
        public string number { get; set; }
        public string expMonth { get; set; }
        public string expYear { get; set; }
        public string type { get; set; }
        public Request_Recurring_Address address { get; set; }
    }
}
