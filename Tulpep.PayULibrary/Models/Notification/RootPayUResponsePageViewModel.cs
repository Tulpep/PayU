namespace Tulpep.PayULibrary.Models.Notification
{
    public class RootPayUResponsePageViewModel
    {
        public string merchantId { get; set; }
        public string transactionState { get; set; }
        public string risk { get; set; }
        public string polResponseCode { get; set; }
        public string referenceCode { get; set; }
        public string reference_pol { get; set; }
        public string signature { get; set; }
        public string polPaymentMethod { get; set; }
        public string polPaymentMethodType { get; set; }
        public string installmentsNumber { get; set; }
        public string TX_VALUE { get; set; }
        public string TX_TAX { get; set; }
        public string buyerEmail { get; set; }
        public string processingDate { get; set; }
        public string currency { get; set; }
        public string cus { get; set; }
        public string pseBank { get; set; }
        public string lng { get; set; }
        public string description { get; set; }
        public string lapResponseCode { get; set; }
        public string lapPaymentMethod { get; set; }
        public string lapPaymentMethodType { get; set; }
        public string lapTransactionState { get; set; }
        public string message { get; set; }
        public string extra1 { get; set; }
        public string extra2 { get; set; }
        public string extra3 { get; set; }
        public string authorizationCode { get; set; }
        public string merchant_address { get; set; }
        public string merchant_name { get; set; }
        public string merchant_url { get; set; }
        public string orderLanguage { get; set; }
        public string pseCycle { get; set; }
        public string pseReference1 { get; set; }
        public string pseReference2 { get; set; }
        public string pseReference3 { get; set; }
        public string telephone { get; set; }
        public string transactionId { get; set; }
        public string trazabilityCode { get; set; }
        public string TX_ADMINISTRATIVE_FEE { get; set; }
        public string TX_TAX_ADMINISTRATIVE_FEE { get; set; }
        public string TX_TAX_ADMINISTRATIVE_FEE_RETURN_BASE { get; set; }

    }
}
