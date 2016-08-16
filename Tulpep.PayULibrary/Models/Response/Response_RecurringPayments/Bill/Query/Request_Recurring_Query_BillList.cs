namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Bill.Query
{
    public class Request_Recurring_Query_BillList
    {
        public string id { get; set; }
        public int orderId { get; set; }
        public string subscriptionId { get; set; }
        public string state { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public object dateCharge { get; set; }
    }
}
