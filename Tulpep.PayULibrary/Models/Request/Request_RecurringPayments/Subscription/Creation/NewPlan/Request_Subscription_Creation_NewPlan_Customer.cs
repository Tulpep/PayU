using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Creation.NewPlan
{
    public class Request_Subscription_Creation_NewPlan_Customer
    {
        public string id { get; set; }
        public List<Request_Subscription_Creation_NewPlan_CreditCard> creditCards { get; set; }
    }
}
