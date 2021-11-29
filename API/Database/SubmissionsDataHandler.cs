using System.Collections.Generic;
using System.Dynamic;
using API.Interfaces;
using API.Models;

namespace API.database
{
    public class SubmissionsDataHandler : ISubmissionsDataHandler
    {
        private Database db { get; set; }
        public SubmissionsDataHandler()
        {
            db = new Database();
        }
        public void Delete(int id)
        {
            string stm = $@"DELETE FROM submissions WHERE id = {id}";
            db.Open();
            db.Delete(stm);
            db.Close();
        }

        public void Insert(Submissions submissions)
        {
            var values = GetValues(submissions);

            string stm = @"INSERT INTO submissions(id,plant) VALUES(@id,@plant)";

            db.Open();
            db.Insert(stm, values);
            db.Close();
        }

        public List<Submissions> Select()
        {
            List<Submissions> mySubmission = new List<Submissions>();

            string stm = @"SELECT * from submissions";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                Submissions temp = new Submissions()
                {
                    ID = item.id,
                    Plant = item.plant,
                };
                mySubmission.Add(temp);
            }
            db.Close();
            return mySubmission;
        }

        public void Update(Submissions submissions)
        {
            var values = GetValues(submissions);
            string stm = @"UPDATE submissions SET plant = @plant WHERE id = @id";

            db.Open();
            db.Update(stm, values);
            db.Close();
        }

        public Dictionary<string, object> GetValues(Submissions submissions)
        {
            var values = new Dictionary<string, object>(){
                {"@id", submissions.ID},
                {"@plant", submissions.Plant},
            };

            return values;
        }
    }
}