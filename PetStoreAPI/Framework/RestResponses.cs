using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace PetStoreAPI.Framework
{
    public class RestResponses
    {
        private Helper helper;
        private RestRequests restRequests;

        public RestResponses()
        {
            helper = new Helper();
            restRequests = new RestRequests();
        }

        public IRestResponse GetResponse(string _endpoint)
        {
            var client = helper.SetUrl(_endpoint);
            var request = restRequests.CreateGetMethod();
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);
            return response;
        }

        public IRestResponse PostResponse(string _endpoint, dynamic _payload)
        {
            var client = helper.SetUrl(_endpoint);
            var jsonString = ModifyContent.SerializeJson(_payload);
            var request = restRequests.CreatePostRequest(jsonString);
            var response = helper.GetResponse(client, request);
            return response;
        }

        public IRestResponse PutResponse(string _endpoint, dynamic _payload)
        {
            var client = helper.SetUrl(_endpoint);
            var jsonString = ModifyContent.SerializeJson(_payload);
            var request = restRequests.CreatePutRequest(jsonString);
            var response = helper.GetResponse(client, request);
            return response;
        }

        public IRestResponse DeleteResponse(string _endpoint)
        {
            var client = helper.SetUrl(_endpoint);
            var request = restRequests.CreateDeleteRequest();
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);
            return response;
        }
    }
}
