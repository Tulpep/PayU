using System.Collections.Generic;

namespace Tulpep.PayULibrary.Models.Response.Response_PayUPayments.ActivePaymentMethodsQuery
{
    public class RootPayUActivePaymentMethodResponse
    {
        public string code { get; set; }
        public object error { get; set; }
        public List<Response_ActiveMethod_PaymentMethod> paymentMethods { get; set; }
    }
}
