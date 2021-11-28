using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStoreAPI.Framework
{
    public class RestRequests
    {
        private RestRequest restRequest = null;

        public RestRequest CreateGetMethod()
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public RestRequest CreatePostRequest(string _payload)
        {
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", _payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreatePutRequest(string _payload)
        {
            restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", _payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateDeleteRequest()
        {
            restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }


    }
}
