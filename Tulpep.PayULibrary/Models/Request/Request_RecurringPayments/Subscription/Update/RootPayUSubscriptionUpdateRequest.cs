namespace Tulpep.PayULibrary.Models.Request.Request_RecurringPayments.Subscription.Update
{
    /// <summary>
    /// Url	/rest/v4.3/subscriptions/{subscriptionId} Method PUT 
    /// Description Update information associated with the specified subscription. 
    /// At the moment it is only possible to update the token of the credit card to which the charge of the subscription is made.
    /// {subscriptionId} : Identification of the subscription.
    /// 
    /// Only updates a credit card of a registered subscription
    /// </summary>
    public class RootPayUSubscriptionUpdateRequest
    {
        public string creditCardToken { get; set; }
    }
}
