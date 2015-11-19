namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Customer.Query
{
    public class Request_Customer_Query_Subscription
    {
        public string id { get; set; }
        public string quantity { get; set; }
        public string installments { get; set; }
        public string currentPeriodStart { get; set; }
        public string currentPeriodEnd { get; set; }
        public Request_Customer_Query_Plan plan { get; set; }
    }
}
