using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.NewCard
{
    public class Response_Subscription_Creation_NewCard_Customer
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public List<Response_Subscription_Creation_NewCard_CreditCard> creditCards { get; set; }
    }
}
