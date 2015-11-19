using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.NewCard
{
    public class Request_Subscription_Creation_NewCard_Customer
    {
        public string id { get; set; }
        public List<Request_Subscription_Creation_NewCard_Customer> creditCards { get; set; }
    }
}
