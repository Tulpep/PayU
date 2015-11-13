using System.Collections.Generic;

namespace Tulpep.PayU.Library.Models.Response.Cross
{
    public class ExtraParameters
    {
        public string BANK_URL { get; set; }
        public string URL_PAYMENT_RECEIPT_HTML { get; set; }
        public long EXPIRATION_DATE { get; set; }
        public int REFERENCE { get; set; }
        public List<Entry> entry { get; set; }
        public string RESPONSE_URL { get; set; }
        public string INSTALLMENTS_NUMBER { get; set; }
    }
}
