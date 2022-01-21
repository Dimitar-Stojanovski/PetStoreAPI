using NUnit.Framework;
using PetStoreAPI.DataProviders;
using PetStoreAPI.Framework;
using PetStoreAPI.Pages.PetPages;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPI.Tests.PetTests
{
    public class CreateAPetTests
    {
        

        [TestCaseSource(typeof(DataForCreateAPet), nameof(DataForCreateAPet.TestDataForCreatingPet))]

        public async Task CreateAPet(int id, int catId, string catName, string url1, string url2, int tagId, string tagName,string status)
        {
            Assert.Multiple(async () =>
            {
                var _pet = new AddAPetBody
                {
                    id = id,
                    category = new AddAPetBody.Category { id = catId, name = catName },
                    photoUrls = new[] { url1, url2 },
                    tags = new[] { new AddAPetBody.Tag { id = tagId, name = tagName }, new AddAPetBody.Tag { id = tagId, name = tagName } },
                    status = status,

                };

                var api = new RestResponses();
                var response = await api.PostResponse("pet", _pet);
                var code = (int)response.StatusCode;
                Assert.AreEqual(200, code);
                var content = ModifyContent.DeserializeJson<AddAPetBody>(response);
                Assert.AreEqual(content.id, id);
                Assert.AreEqual(content.category.id, catId);
                Assert.AreEqual(content.category.name, catName);
                Assert.AreEqual(content.photoUrls[0], url1);
                Assert.AreEqual(content.photoUrls[1], url2);
                Assert.AreEqual(content.tags[0].id, tagId);
                Assert.AreEqual(content.tags[0].name, tagName);
                Assert.AreEqual(content.tags[1].id, tagId);
                Assert.AreEqual(content.tags[1].name, tagName);
                Assert.AreEqual(content.status, status);

                
                

            });
        }

        [Test]
        public async Task UpdateAPet()
        {
            string filePath = @"C:\Users\user\Source\Repos\PetStoreAPI\PetStoreAPI\DataProviders\UpdatePet.json";
            Assert.Multiple(async () =>
            {
                var _payload = ModifyContent.ParseJson<AddAPetBody>(filePath);
                var api = new RestResponses();
                var response = await api.PutResponse("pet", _payload);
                var content = ModifyContent.DeserializeJson<AddAPetBody>(response);
                Assert.AreEqual((int)response.StatusCode, 200);
                Assert.AreEqual(content.id, 42);
                Assert.AreEqual(content.category.id, 12);
                Assert.AreEqual(content.category.name, "German Shepperd");
                Assert.AreEqual(content.name, "Rex");
                Assert.AreEqual(content.photoUrls[0], "URL 1");
                Assert.AreEqual(content.tags[0].id, 12);
                Assert.AreEqual(content.tags[0].name, "tag 1");
                Assert.AreEqual(content.status, "available");

            });     
        }

        
    }
}
