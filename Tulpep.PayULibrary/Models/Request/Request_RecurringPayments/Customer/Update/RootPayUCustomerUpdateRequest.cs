namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Customer.Update
{
    /// <summary>
    /// Url	/rest/v4.3/customers/{customerId} Method PUT 
    /// Description Updates the customer’s information in the system.{customerId} : Identifier of the client to be updated.
    /// </summary>
    public class RootPayUCustomerUpdateRequest
    {
        public string fullName { get; set; }
        public string email { get; set; }
    }
}
