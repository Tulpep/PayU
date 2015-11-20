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
        public string FINANCIAL_INSTITUTION_CODE { get; set; }
        /// <summary>
        /// You must display a list where the payer chooses whether he is a "natural person" (N) or a "legal person” (J).
        /// ‘N’ o ‘J’, depending on what the payer has chosen, must be sent in the USER_TYPE request parameter in the petition
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string USER_TYPE { get; set; }
        /// <summary>
        /// User Ip address
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PSE_REFERENCE1 { get; set; }
        /// <summary>
        /// You must display another list on the form that allows the payer to choose the type of document, 
        /// the chosen ISO of the document must be submitted in the PSE_REFERENCE2 parameter in the (SUBMIT_TRANSACTION) request. 
        /// The supported ISO codes are:
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PSE_REFERENCE2 { get; set; }
        /// <summary>
        /// you must capture the payer’s ID number and send it in the PSE_REFERENCE3 request parameter 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PSE_REFERENCE3 { get; set; }
    }
}
