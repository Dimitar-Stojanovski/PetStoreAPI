using NUnit.Framework;
using PetStoreAPI.Framework;
using PetStoreAPI.Pages.PetPages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPI.Tests.PetTests
{
    public class GetAPet
    {
        private HttpStatusCode statusCode;

        [Test]
        public async Task GetAPetFromPost()
        {
            Assert.Multiple(async () =>
            {
                var api = new RestResponses();
                var response = await api.GetResponse("pet/33");
                Assert.AreEqual(200, (int)response.StatusCode);
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
