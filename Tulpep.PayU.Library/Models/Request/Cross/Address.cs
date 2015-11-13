using System;

namespace Tulpep.PayU.Library.Models.Request.Cross
{
    public class Address
    {
        //Format: Alphanumeric Size: Min: 1 Max: 100
        //Description: First line of the address.
        private string Street1;
        public string street1
        {
            get
            {
                return Street1;
            }
            set
            {
                if (value.Length > 0 && value.Length < 101)
                {
                    Street1 = value;
                }
                else
                {
                    throw new Exception("The MAX length of street1 is 100 MIN 1");
                }
            }
        }
        //Format: Alphanumeric Size: Min: 1 Max: 100
        //Description: Second line of the address.
        private string Street2;
        public string street2
        {
            get
            {
                return Street2;
            }
            set
            {
                if (value.Length > 0 && value.Length < 101)
                {
                    Street2 = value;
                }
                else
                {
                    throw new Exception("The MAX length of street2 is 100 MIN 1");
                }
            }
        }
        //Format: Alphanumeric Size: Min: 1 Max: 50
        //Description: City.
        private string City;
        public string city
        {
            get
            {
                return City;
            }
            set
            {
                if (value.Length > 0 && value.Length < 51)
                {
                    City = value;
                }
                else
                {
                    throw new Exception("The MAX length of city is 50 MIN 1");
                }
            }
        }
        //Format: Alphanumeric Size: Min: 1 Max: 40
        //Description: State or province.
        //             For Brazil send only 2 characters.Example: If it is Sao Paulo then send SP
        private string State;
        public string state
        {
            get
            {
                return State;
            }
            set
            {
                if (value.Length > 0 && value.Length < 41)
                {
                    State = value;
                }
                else
                {
                    throw new Exception("The MAX length of state is 40 MIN 1");
                }
            }
        }
        //Format: Alphanumeric Size: 2
        //Description: Country.
        private string Country;
        public string country
        {
            get
            {
                return Country;
            }
            set
            {
                if (value.Length == 2)
                {
                    Country = value;
                }
                else
                {
                    throw new Exception("The length of country is 2");
                }
            }
        }
        //Format: Alphanumeric Size: Min: 1 Max: 8
        //Description: Postal code.
        private string PostalCode;
        public string postalCode
        {
            get
            {
                return PostalCode;
            }
            set
            {
                if (value.Length > 0 && value.Length < 9)
                {
                    PostalCode = value;
                }
                else
                {
                    throw new Exception("The MAX length of postalCode is 8 MIN 1");
                }
            }
        }
        //Format: Alphanumeric Size: Min: 1 Max: 11
        //Description: Phone associated with the address.
        private string Phone;
        public string phone
        {
            get
            {
                return Phone;
            }
            set
            {
                if (value.Length > 0 && value.Length < 12)
                {
                    Phone = value;
                }
                else
                {
                    throw new Exception("The MAX length of phone is 11 MIN 1");
                }
            }
        }
    }
}
