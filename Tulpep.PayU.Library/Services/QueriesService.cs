using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using System.Text;
using Tulpep.PayU.Library.Cross;
using Tulpep.PayU.Library.Models.Request.Cross;
using Tulpep.PayU.Library.Models.Request.PayUQueries.Ping;
using Tulpep.PayU.Library.Models.Response.PayUQueries.Ping;

namespace Tulpep.PayU.Library.Services
{
    public class QueriesService
    {
        public bool pingPayU()
        {
            ResourceManager rm = new ResourceManager(typeof(Resources.Tulpep_PayUResources));
            var url = rm.GetString(Constants.DefaultProductionQueriesConnectionUrl);
            if (url != null)
            {
                var query = new RootPayUQueriesPingRequest()
                {
                    test = true,
                    language = Constants.es,
                    command = Constants.PING,
                    merchant = new Merchant()
                    {
                        apiKey = rm.GetString(Constants.APIKey),
                        apiLogin = rm.GetString(Constants.APILogin)
                    }
                };

                string requestJson = JsonConvert.SerializeObject(query);
                try
                {
                    // Create an HttpClient instance 
                    var client = new HttpClient();
                    client.BaseAddress = new Uri(rm.GetString(Constants.DefaultProductionQueriesConnectionUrl));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
                    client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("es"));

                    var response = client.PostAsync("", new StringContent(requestJson, Encoding.UTF8, "application/json")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string res = response.Content.ReadAsStringAsync().Result;
                        RootPayUQueriesPingResponse des = JsonConvert.DeserializeObject<RootPayUQueriesPingResponse>(res);
                        if (des.code.Equals("SUCCESS"))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
