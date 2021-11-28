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
        public void PostStoreOrderTest(int id, int petId, int quantity, string status, bool complete)
        {
            Assert.Multiple(() =>
            {
                var _inventory = new PostStoreOrderBody
                {
                    id = id,
                    petId = petId,
                    quantity = quantity,
                    status = status,
                    complete = complete


                };

                var api = new RestResponses();
                var response = api.PostResponse("store/order", _inventory);
                var code = (int)response.StatusCode;
                Assert.AreEqual(200, code);
                var content = ModifyContent.DeserializeJson<PostStoreOrderBody>(response);
                Assert.AreEqual(content.id, id);
                Assert.AreEqual(content.petId, petId);
                Assert.AreEqual(content.quantity, quantity);
                Assert.AreEqual(content.status, status);
                Assert.AreEqual(content.complete, complete);

            });


           
        }

        [Test]
        public void VerifyThatTheOrderIsPlaced()
        {
            Assert.Multiple(() =>
            {
                var api = new RestResponses();
                var response = api.GetResponse("store/order/123");
                var code = (int)response.StatusCode;
                Assert.AreEqual(200, code);
                var _inventory = ModifyContent.DeserializeJson<PostStoreOrderBody>(response);
                Assert.AreEqual(_inventory.id, 123);
                Assert.AreEqual(_inventory.petId, 33);
                Assert.AreEqual(_inventory.quantity, 46);
                Assert.AreEqual(_inventory.status, "placed");
                Assert.AreEqual(_inventory.complete, true);
            });
        }
    }
}
