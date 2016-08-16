using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Bill.Query
{
    public class RootPayUBillQueryResponse
    {
        public List<Request_Recurring_Query_BillList> recurringBillList { get; set; }
    }
}
