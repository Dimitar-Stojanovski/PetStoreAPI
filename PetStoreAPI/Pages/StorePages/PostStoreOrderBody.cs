using System;
using System.Collections.Generic;
using System.Text;

namespace PetStoreAPI.Pages.StorePages
{
    class PostStoreOrderBody
    {
        
            public int id { get; set; }
            public int petId { get; set; }
            public int quantity { get; set; }
            public string status { get; set; }
            public bool complete { get; set; }
        

    }
}
