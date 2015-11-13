using System.Collections.Generic;
using Tulpep.PayU.Library.Models.Response.Cross;

namespace Tulpep.PayU.Library.Models.Response.PayUQueries.QueryOrderByIdentifier
{
    public class Payload
    {
        public int id { get; set; }
        public int accountId { get; set; }
        public string status { get; set; }
        public string referenceCode { get; set; }
        public string description { get; set; }
        public string airlineCode { get; set; }
        public string language { get; set; }
        public string notifyUrl { get; set; }
        public Address shippingAddress { get; set; }
        public Buyer buyer { get; set; }
        public List<Transaction> transactions { get; set; }
        public AdditionalValues additionalValues { get; set; }
    }
}
