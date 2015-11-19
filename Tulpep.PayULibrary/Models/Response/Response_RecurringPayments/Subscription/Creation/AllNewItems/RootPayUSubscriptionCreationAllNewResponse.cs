using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.Creation.AllNewItems
{
    public class RootPayUSubscriptionCreationAllNewResponse
    {
        public string id { get; set; }
        public Response_Subscription_Creation_AllNewItems_Plan plan { get; set; }
        public Response_Subscription_Creation_AllNewItems_Customer customer { get; set; }
        public int quantity { get; set; }
        public int installments { get; set; }
        public string trialDays { get; set; }
        public long currentPeriodStart { get; set; }
        public long currentPeriodEnd { get; set; }
    }
}
