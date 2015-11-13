using Tulpep.PayU.Library.Models.Request.Cross;

namespace Tulpep.PayU.Library.Models.Request.PayUQueries.QueryOrderByReference
{
    public class RootPayUQueryOrderByRefRequest
    {
        public bool test { get; set; }
        public string language { get; set; }
        public string command { get; set; }
        public Merchant merchant { get; set; }
        public Details details { get; set; }
    }
}
