using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public async Task <RestResponse> GetResponse(string _endpoint)
        {
            var client = helper.SetUrl(_endpoint);
            var request = restRequests.CreateGetMethod();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponse(client, request);
            return response;
        }

        public async Task <RestResponse> PostResponse (string _endpoint, dynamic _payload)
        {
            var client = helper.SetUrl(_endpoint);
            //var jsonString = ModifyContent.SerializeJson(_payload);
            var request = restRequests.CreatePostRequest(_payload);
            var response = await helper.GetResponse(client, request);
            return response;
        }

        public async Task <RestResponse> PutResponse(string _endpoint, dynamic _payload)
        {
            var client = helper.SetUrl(_endpoint);
            //var jsonString = ModifyContent.SerializeJson(_payload);
            var request = restRequests.CreatePutRequest(_payload);
            var response = await helper.GetResponse(client, request);
            return response;
        }

        public async Task <RestResponse> DeleteResponse(string _endpoint)
        {
            var client = helper.SetUrl(_endpoint);
            var request = restRequests.CreateDeleteRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponse(client, request);
            return response;
        }
    }
}
