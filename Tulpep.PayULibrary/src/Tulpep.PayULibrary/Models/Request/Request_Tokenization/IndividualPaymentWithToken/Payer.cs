using Tulpep.PayULibrary.Cross;

namespace Tulpep.PayULibrary.Models.Request.Request_Tokenization.IndividualPaymentWithToken
{
    public class Payer
    {
        public string merchantPayerId { get; set; }
        public string fullName { get; set; }
        public string emailAddress { get; set; }
        public string contactPhone { get; set; }
        public string dniNumber { get; set; }
        public Address billingAddress { get; set; }
    }
}
