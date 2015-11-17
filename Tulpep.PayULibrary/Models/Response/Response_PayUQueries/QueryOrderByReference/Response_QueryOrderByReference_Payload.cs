using System.Collections.Generic;
using Tulpep.PayULibrary.Cross;
using Tulpep.PayULibrary.Models.Response.Response_Cross;

namespace Tulpep.PayULibrary.Models.Response.Response_PayUQueries.QueryOrderByReference
{
    public class Response_QueryOrderByReference_Payload
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
        public Response_QueryOrderByReference_Buyer buyer { get; set; }
        public List<Response_QueryOrderByReference_Transaction> transactions { get; set; }
        public Response_AdditionalValues additionalValues { get; set; }
    }
}
