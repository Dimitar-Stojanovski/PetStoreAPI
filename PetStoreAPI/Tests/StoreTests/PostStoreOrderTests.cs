using NUnit.Framework;
using PetStoreAPI.Framework;
using PetStoreAPI.Pages.StorePages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PetStoreAPI.Tests.StoreTests
{
    public class PostStoreOrderTests
    {
        private HttpStatusCode statusCode;

        [Test]
        public void PostStoreOrderTest()
        {
            Assert.Multiple(() =>
            {
                var _inventory = new PostStoreOrderBody
                {
                    id = 123,
                    petId = 33,
                    quantity = 46,
                    status = "placed",
                    complete = true


                };

                var api = new RestResponses();
                var response = api.PostResponse("store/order", _inventory);
                var code = (int)response.StatusCode;
                Assert.AreEqual(200, code);
                var content = ModifyContent.DeserializeJson<PostStoreOrderBody>(response);
                Assert.AreEqual(content.id, 123);
                Assert.AreEqual(content.petId, 33);
                Assert.AreEqual(content.quantity, 46);
                Assert.AreEqual(content.status, "placed");
                Assert.AreEqual(content.complete, true);

            });
           
        }
    }
}
