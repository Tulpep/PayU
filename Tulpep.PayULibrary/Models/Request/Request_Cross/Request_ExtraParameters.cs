using Newtonsoft.Json;

namespace Tulpep.PayULibrary.Models.Request.Request_Cross
{
    //Additional parameters or data associated with a transaction.
    //These parameters may vary according to the payment means or shop’s preferences.
    public class Request_ExtraParameters
    {
        //The parameter’s name.Example: ”INSTALLMENTS_NUMBER”, “RESPONSE_URL”, “PSE_REFERENCE1", etc.
        //See the use of this variable in the examples by country.
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int INSTALLMENTS_NUMBER { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RESPONSE_URL { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PSE_REFERENCE1 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FINANCIAL_INSTITUTION_CODE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string USER_TYPE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PSE_REFERENCE2 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PSE_REFERENCE3 { get; set; }
    }
}
