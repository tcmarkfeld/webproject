using API.database;
using API.Interfaces;

namespace API.Models
{
    public class Reports
    {
        public int ReportID { get; set; }
        public string ReportInformation { get; set; }
        public IReportsDataHandler DataHandler { get; set; }

        public Reports()
        {
            DataHandler = new ReportsDataHandler();
        }
    }
}