using System;

namespace Tulpep.PayULibrary.Services.ServicesHelpers
{
    public static class MathHelper
    { 
        public static decimal RoundDecimal(decimal price)
        {
            decimal result = Math.Round(price, 2, MidpointRounding.ToEven);
            return result;
        }
    }
}
