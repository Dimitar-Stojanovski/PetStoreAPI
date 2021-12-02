using NUnit.Framework;
using PetStoreAPI.DataProviders;
using PetStoreAPI.Framework;
using PetStoreAPI.Pages.PetPages;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PetStoreAPI.Tests.PetTests
{
    public class CreateAPetTests
    {
        private HttpStatusCode statusCode;

        [TestCaseSource(typeof(DataForCreateAPet), nameof(DataForCreateAPet.TestDataForCreatingPet))]

        public void CreateAPet(int id, int catId, string catName, string url1, string url2, int tagId, string tagName,string status)
        {
            Assert.Multiple(() =>
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
                var response = api.PostResponse("pet", _pet);
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
    }
}
