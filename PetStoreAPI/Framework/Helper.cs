using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PetStoreAPI.Framework
{
    public class Helper
    {
        private RestClient restClient;
        private const string _URL = "https://petstore.swagger.io/v2/";

        public RestClient SetUrl(string _endpoint)
        {
            var url = Path.Combine(_URL, _endpoint);
            restClient = new RestClient(url);
            return restClient;
        }

        public async Task <RestResponse> GetResponse(RestClient client, RestRequest restRequest)
        {
            return await restClient.ExecuteAsync(restRequest);
        }
    }
}
