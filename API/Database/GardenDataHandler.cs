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

        public List<Garden> SelectHighest()
        {
            List<Garden> myGarden = new List<Garden>();

            string stm = @"SELECT gardenid from garden order by gardenid desc limit 1";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                Garden temp = new Garden()
                {
                    GardenID = item.gardenid
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

        public void Delete(int id)
        {
            string stm = $@"DELETE FROM garden WHERE gardenid = {id}";

            db.Open();
            db.Delete(stm);
            db.Close();
        }

        public void Insert(Garden garden)
        {
            var values = GetValues(garden);
            string stm = @"INSERT INTO garden(gardenid,gardentype,information) VALUES(@id,@type,@info)";

            db.Open();
            db.Insert(stm, values);
            db.Close();
        }

        public void Update(Garden garden)
        {
            var values = GetValues(garden);
            string stm = @"UPDATE garden SET gardenType = @type, information = @info WHERE gardenid = @id";

            db.Open();
            db.Update(stm, values);
            db.Close();
        }

        public Dictionary<string, object> GetValues(Garden garden)
        {
            var values = new Dictionary<string, object>(){
                {"@id", garden.GardenID},
                {"@type", garden.GardenType},
                {"@info", garden.Information}
            };

            return values;
        }
    }
}