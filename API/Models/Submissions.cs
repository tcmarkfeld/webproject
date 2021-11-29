using API.database;
using API.Interfaces;

namespace API.Models
{
    public class Submissions
    {
        public int ID { get; set; }
        public string Plant { get; set; }
        public ISubmissionsDataHandler DataHandler { get; set; }

        public Submissions()
        {
            DataHandler = new SubmissionsDataHandler();
        }
    }
}