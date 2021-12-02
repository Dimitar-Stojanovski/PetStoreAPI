using System;
using System.Collections.Generic;
using System.Text;

namespace PetStoreAPI.DataProviders
{
    public class DataForCreateAPet
    {
        public static object[] TestDataForCreatingPet =
        {
            new object [] {12, 33, "Clea", "url1", "url2", 55, "TagDog1", "available"},
            new object [] {13, 34, "Clea1", "url11", "url22", 555, "TagDog12", "out of stock"},
            new object [] {12, 33, "Clea2", "url111", "url222", 5555, "TagDog123", "not available"}
        };
    }
}
