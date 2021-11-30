using PetStoreAPI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CsvHelper;
using System.Globalization;

namespace PetStoreAPI.DataProviders
{
    public class DataForPostStoreOrder
    {
        

        public static IEnumerable<dynamic []> GetDataForCSV()
        {
            using (var reader = new StreamReader(StaticVariables._filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) 
            {
                while (csv.Read())
                {
                    bool IsConverted = true;

                    
                    string id = csv.GetField(0);
                   
                   
                    string petId = csv.GetField(1);
                    


                    string quantity = csv.GetField(2);
                    

                    string status = csv.GetField(3);


                    string complete = csv.GetField(4);
                    

                    yield return new dynamic[] { id, petId, quantity,  status, complete } ;



                }
                
            }
        }
    }
}
