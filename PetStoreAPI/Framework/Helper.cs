using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

        public IRestResponse GetResponse(RestClient client, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }
    }
}
