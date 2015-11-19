using Newtonsoft.Json;

namespace Tulpep.PayULibrary.Models.Response.Response_Cross
{
    public class Response_AdditionalValues
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PMTAXADMINISTRATIVEFEE PM_TAX_ADMINISTRATIVE_FEE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_TXADDITIONALVALUE TX_ADDITIONAL_VALUE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PMTAXADMINISTRATIVEFEERETURNBASE PM_TAX_ADMINISTRATIVE_FEE_RETURN_BASE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_TXVALUE TX_VALUE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PAYERINTERESTVALUE PAYER_INTEREST_VALUE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PMTAXRETURNBASE PM_TAX_RETURN_BASE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PMADMINISTRATIVEFEE PM_ADMINISTRATIVE_FEE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PMVALUE PM_VALUE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_TXADMINISTRATIVEFEE TX_ADMINISTRATIVE_FEE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PMNETWORKVALUE PM_NETWORK_VALUE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PMADDITIONALVALUE PM_ADDITIONAL_VALUE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PMTAX PM_TAX { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_TXTAXRETURNBASE TX_TAX_RETURN_BASE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PAYERPRICINGVALUES PAYER_PRICING_VALUES { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PMPURCHASEVALUE PM_PURCHASE_VALUE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_TXTAX TX_TAX { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_MERCHANTCOMMISSIONVALUE MERCHANT_COMMISSION_VALUE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_TXTAXADMINISTRATIVEFEE TX_TAX_ADMINISTRATIVE_FEE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_PAYERCOMMISSIONVALUE PAYER_COMMISSION_VALUE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_TXTAXADMINISTRATIVEFEERETURNBASE TX_TAX_ADMINISTRATIVE_FEE_RETURN_BASE { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Response_MERCHANTINTERESTVALUE MERCHANT_INTEREST_VALUE { get; set; }
    }
}
