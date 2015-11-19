namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Customer.Creation
{
    /// <summary>
    /// Url	/rest/v4.3/customers/ Method POST Description Creation of a customer in the system.
    /// </summary>
    public class RootPayUCustomerCreationRequest
    {
        public string fullName { get; set; }
        public string email { get; set; }
    }
}
