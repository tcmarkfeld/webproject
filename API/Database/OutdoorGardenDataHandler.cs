using System.Collections.Generic;
using System.Dynamic;
using API.Interfaces;
using API.Models;

namespace API.database
{
    public class OutdoorGardenDataHandler : IOutdoorGardenDataHandler
    {
        private Database db { get; set; }
        public OutdoorGardenDataHandler()
        {
            db = new Database();
        }
        public void Delete(OutdoorGarden outdoorGarden)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(OutdoorGarden outdoorGarden)
        {
            throw new System.NotImplementedException();
        }

        public List<OutdoorGarden> Select()
        {
            List<OutdoorGarden> myGarden = new List<OutdoorGarden>();

            string stm = @"SELECT * from outdoorgarden";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                OutdoorGarden temp = new OutdoorGarden()
                {
                    GardenID = item.gardenid,
                    Information = item.information
                };
                myGarden.Add(temp);
            }
            db.Close();
            return myGarden;
        }

        public void Update(OutdoorGarden outdoorGarden)
        {
            throw new System.NotImplementedException();
        }
    }
}