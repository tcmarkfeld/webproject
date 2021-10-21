using System.Collections.Generic;
using System.Dynamic;
using API.Interfaces;
using API.Models;

namespace API.database
{
    public class HousePlantDataHandler : IHousePlantDataHandler
    {
        private Database db { get; set; }
        public HousePlantDataHandler()
        {
            db = new Database();
        }
        public void Delete(HousePlant housePlant)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(HousePlant housePlant)
        {
            throw new System.NotImplementedException();
        }

        public List<HousePlant> Select()
        {
            List<HousePlant> myGarden = new List<HousePlant>();

            string stm = @"SELECT * from houseplant";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                HousePlant temp = new HousePlant()
                {
                    GardenID = item.gardenid,
                    Information = item.information
                };
                myGarden.Add(temp);
            }
            db.Close();
            return myGarden;
        }

        public void Update(HousePlant housePlant)
        {
            throw new System.NotImplementedException();
        }
    }
}