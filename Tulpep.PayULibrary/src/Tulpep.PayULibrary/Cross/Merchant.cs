using System;

namespace Tulpep.PayULibrary.Cross
{
    public class Merchant
    {
        //Type: Alphanumeric Size: Min: 12 Max: 32
        //Description: Contains the authentication data.
        private string ApiKey;
        public string apiKey
        {
            get
            {
                return ApiKey;
            }
            set
            {
                if (value.Length > 11 && value.Length < 33)
                {
                    ApiKey = value;
                }
                else
                {
                    throw new Exception("The MAX length of apiKey is 32 and MIN 12");
                }
            }
        }
        //Type: Alphanumeric Size: Min: 6 Max: 32
        //Description: Contains the authentication data.
        private string ApiLogin;
        public string apiLogin
        {
            get
            {
                return ApiLogin;
            }
            set
            {
                if (value.Length > 5 && value.Length < 33)
                {
                    ApiLogin = value;
                }
                else
                {
                    throw new Exception("The MAX length of apiKey is 32 and MIN 6");
                }
            }
        }
    }
}
