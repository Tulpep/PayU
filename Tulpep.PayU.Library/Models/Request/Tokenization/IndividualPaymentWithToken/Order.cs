using Tulpep.PayU.Library.Models.Request.Cross;

namespace Tulpep.PayU.Library.Models.Request.Tokenization.IndividualPaymentWithToken
{
    public class Order
    {
        public string accountId { get; set; }
        public string referenceCode { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string signature { get; set; }
        public string notifyUrl { get; set; }
        public AdditionalValues additionalValues { get; set; }
        public Buyer buyer { get; set; }
        public Address shippingAddress { get; set; }
    }
}
