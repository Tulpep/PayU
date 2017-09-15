using System;
using System.Configuration;
using System.Globalization;

namespace Tulpep.PayULibrary.Services.ServicesHelpers
{
    public static class Tax_BaseReturnHelper
    {
        private static decimal taxPercentage;
        public static decimal TaxPercentage
        {
            get
            {
                if (!decimal.TryParse(ConfigurationManager.AppSettings["PAYU_API_TAX_PERCENTAGE"], NumberStyles.Any, CultureInfo.InvariantCulture, out taxPercentage))
                {
                    throw new InvalidOperationException("Invalid PAYU_API_TAX_PERCENTAGE in web.config");
                }
                return taxPercentage;
            }
            private set
            {
                if (!decimal.TryParse(ConfigurationManager.AppSettings["PAYU_API_TAX_PERCENTAGE"], NumberStyles.Any, CultureInfo.InvariantCulture, out taxPercentage))
                {
                    throw new InvalidOperationException("Invalid PAYU_API_TAX_PERCENTAGE in web.config");
                }
            }
        }
        private static decimal taxBaseReturnPercentage;
        public static decimal TaxBaseReturnPercentage
        {
            get
            {
                if (!decimal.TryParse(ConfigurationManager.AppSettings["PAYU_API_RETURNBASE_PERCENTAGE"], NumberStyles.Any, CultureInfo.InvariantCulture, out taxBaseReturnPercentage))
                {
                    throw new InvalidOperationException("Invalid PAYU_API_RETURNBASE_PERCENTAGE in web.config");
                }
                return taxBaseReturnPercentage;
            }
            private set
            {
                if (!decimal.TryParse(ConfigurationManager.AppSettings["PAYU_API_RETURNBASE_PERCENTAGE"], NumberStyles.Any, CultureInfo.InvariantCulture, out taxBaseReturnPercentage))
                {
                    throw new InvalidOperationException("Invalid PAYU_API_RETURNBASE_PERCENTAGE in web.config");
                }
            }
        }

        public static decimal CalculateTaxValue(decimal price)
        {
            decimal result = Math.Round((price / TaxBaseReturnPercentage) * TaxPercentage, 2, MidpointRounding.ToEven);
            return result;
        }

        public static decimal CalculateBaseReturnValue(decimal price)
        {
            decimal result = Math.Round(price / TaxBaseReturnPercentage, 2, MidpointRounding.ToEven);
            return result;
        }
    }
}
