using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.AdditionalCharges.Query.BySubscription
{
    public class RootPayUAdditionalChargesQueryBySbtnResponse
    {
        public List<Response_Subscription_Query_RecurringBillItemList> recurringBillItemList { get; set; }
    }
}
