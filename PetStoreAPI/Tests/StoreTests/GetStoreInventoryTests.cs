using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using NUnit;
using NUnit.Framework;
using PetStoreAPI.Framework;
using PetStoreAPI.Pages.StorePages;

namespace PetStoreAPI.Tests.StoreTests
{
    public class GetStoreInventoryTests
    {
        private HttpStatusCode statusCode;
        [Test]

        public void GetPetInventoriesByStatus()
        {
            Assert.Multiple(() =>
            {
                var api = new RestResponses();
                var response = api.GetResponse("store/inventory");
                var code = (int)response.StatusCode;
                Assert.AreEqual(200, code);
                var _inventory = ModifyContent.DeserializeJson<GetStoreInventoryBody>(response);
                Assert.AreEqual(_inventory.sold, 13);
                Assert.AreEqual(_inventory._void, 4);
                Assert.AreEqual(_inventory._string, 244);
                Assert.AreEqual(_inventory.alive, 1);
                Assert.AreEqual(_inventory._null, 5);
                Assert.AreEqual(_inventory.Maçãâ_, 3);
                Assert.AreEqual(_inventory.pending, 3);
                Assert.AreEqual(_inventory.available, 723);
                Assert.AreEqual(_inventory._4ill, 2);
                Assert.AreEqual(_inventory.free, 1);

            });
           
            
           
        }
    }
}
