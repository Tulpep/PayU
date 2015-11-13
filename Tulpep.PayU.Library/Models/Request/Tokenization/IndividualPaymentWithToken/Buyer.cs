using Tulpep.PayU.Library.Models.Request.Cross;

namespace Tulpep.PayU.Library.Models.Request.Tokenization.IndividualPaymentWithToken
{
    public class Buyer
    {
        public string merchantBuyerId { get; set; }
        public string fullName { get; set; }
        public string emailAddress { get; set; }
        public string contactPhone { get; set; }
        public string dniNumber { get; set; }
        public Address shippingAddress { get; set; }
    }
}
