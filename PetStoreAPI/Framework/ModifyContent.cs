using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using RestSharp;

namespace PetStoreAPI.Framework
{
   public static class ModifyContent
    {
        public static T DeserializeJson<T>(RestResponse response) 
        {
            var content = response.Content;
            return JsonSerializer.Deserialize<T>(content);
        }

        public static string SerializeJson(dynamic _content)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(_content, options);
        }

        public static T ParseJson<T>(string _payload)
        {
            return JsonSerializer.Deserialize<T>(File.ReadAllText(_payload));
        }
    }
}
