using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Response.Response_Cross
{
    public class Response_ExtraParameters
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BANK_URL { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string URL_PAYMENT_RECEIPT_HTML { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public long EXPIRATION_DATE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int REFERENCE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Response_Entry> entry { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RESPONSE_URL { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string INSTALLMENTS_NUMBER { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MERCHANT_PROFILE_ID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MAX_SHIPPING_MERCHANT { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MIN_SHIPPING_PAYER { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PERCENT_SHIPPING_MERCHANT { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MAX_SHIPPING_PAYER { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MIN_SHIPPING_MERCHANT { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PRICING_PROFILE_GROUP_ID { get; set; }
    }
}
