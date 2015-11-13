﻿namespace Tulpep.PayU.Library.Models.Response.PayUQueries.QueryOrderByReference
{
    public class Payer
    {
        public string merchantPayerId { get; set; }
        public string fullName { get; set; }
        public string billingAddress { get; set; }
        public string emailAddress { get; set; }
        public string contactPhone { get; set; }
        public string dniNumber { get; set; }
    }
}
