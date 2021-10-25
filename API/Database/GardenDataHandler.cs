using System.Collections.Generic;
using System.Dynamic;
using API.Interfaces;
using API.Models;

namespace API.database
{
    public class GardenDataHandler : IGardenDataHandler
    {
        private Database db { get; set; }
        public GardenDataHandler()
        {
            db = new Database();
        }
        public List<Garden> Select()
        {
            List<Garden> myGarden = new List<Garden>();

            string stm = @"SELECT * from garden";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                Garden temp = new Garden()
                {
                    GardenID = item.gardenid,
                    GardenType = item.gardenType,
                    Information = item.information
                };
                myGarden.Add(temp);
            }
            db.Close();
            return myGarden;
        }

        public List<Garden> SelectID(int id)
        {
            List<Garden> myGarden = new List<Garden>();

            string stm = @"SELECT * from garden where gardenid = '" + id + "'";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                Garden temp = new Garden()
                {
                    GardenID = item.gardenid,
                    GardenType = item.gardenType,
                    Information = item.information
                };
                myGarden.Add(temp);
            }
            db.Close();
            return myGarden;
        }

        public void Delete(Garden garden)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Garden garden)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Garden garden)
        {
            throw new System.NotImplementedException();
        }
    }
}