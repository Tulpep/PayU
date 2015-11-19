using System.Collections.Generic;
using Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.AdditionalCharges.Update
{
    /// <summary>
    /// Url	/rest/v4.3/recurringBillItems/{recurringBillItemId}	 Method PUT 
    /// Description Updates the information from an additional charge in an invoice{recurringBillItemId} : 
    /// Identifier of the additional charge.
    /// </summary>
    public class RootPayUAdditionalChargesUpdateRequest
    {
        public string description { get; set; }
        public List<Request_Recurring_AdditionalValue> additionalValues { get; set; }
    }
}
