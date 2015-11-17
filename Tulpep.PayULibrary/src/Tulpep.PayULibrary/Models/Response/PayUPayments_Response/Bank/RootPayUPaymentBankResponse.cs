namespace Tulpep.PayULibrary.Models.Response.PayUPayments_Response.Bank
{
    class RootPayUPaymentBankResponse
    {
        //Format: Alphanumeric Size:
        //Description: The overall response code. ERROR, SUCCESS.
        public string code { get; set; }
        //The response’s data.
        public TransactionResponse transactionResponse { get; set; }
    }
}
