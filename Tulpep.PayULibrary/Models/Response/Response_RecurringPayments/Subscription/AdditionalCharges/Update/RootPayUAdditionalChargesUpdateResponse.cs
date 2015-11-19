﻿using System.Collections.Generic;
using Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Cross;

namespace Tulpep.PayULibrary.Models.Response.Response_RecurringPayments.Subscription.AdditionalCharges.Update
{
    public class RootPayUAdditionalChargesUpdateResponse
    {
        public string id { get; set; }
        public string description { get; set; }
        public List<Response_Recurring_AdditionalValue> additionalValues { get; set; }
        public string subscriptionId { get; set; }
    }
}