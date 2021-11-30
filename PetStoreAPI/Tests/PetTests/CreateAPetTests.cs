using NUnit.Framework;
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

        [Test]

        public void CreateAPet()
        {
            Assert.Multiple(() =>
            {
                var _pet = new AddAPetBody
                {
                    id = 33,
                    category = new AddAPetBody.Category { id = 31, name = "Doggie" },
                    photoUrls = new[] { "Picture 1", "Picture 2" },
                    tags = new[] { new AddAPetBody.Tag { id = 22, name = "Doggie" }, new AddAPetBody.Tag { id = 33, name = "Dogo" } },
                    status = "available",

                };

                var api = new RestResponses();
                var response = api.PostResponse("pet", _pet);
                var code = (int)response.StatusCode;
                Assert.AreEqual(200, code);
                var content = ModifyContent.DeserializeJson<AddAPetBody>(response);
                Assert.AreEqual(content.id, 33);
                Assert.AreEqual(content.category.id, 31);
                Assert.AreEqual(content.category.name, "Doggie");
                Assert.AreEqual(content.photoUrls[0], "Picture 1");
                Assert.AreEqual(content.photoUrls[1], "Picture 2");
                Assert.AreEqual(content.tags[0].id, 22);
                Assert.AreEqual(content.tags[0].name, "Doggie");
                Assert.AreEqual(content.tags[1].id, 33);
                Assert.AreEqual(content.tags[1].name, "Dogo");
                Assert.AreEqual(content.status, "available");

            });
        }
    }
}
