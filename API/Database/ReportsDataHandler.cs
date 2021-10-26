using System.Collections.Generic;
using System.Dynamic;
using API.Interfaces;
using API.Models;

namespace API.database
{
    public class ReportsDataHandler : IReportsDataHandler
    {
        private Database db { get; set; }
        public ReportsDataHandler()
        {
            db = new Database();
        }
        public void Delete(int id)
        {
            string stm = $@"DELETE FROM reports WHERE reportid = {id}";
            db.Open();
            db.Delete(stm);
            db.Close();
        }

        public void Insert(Reports reports)
        {
            var values = GetValues(reports);

            string stm = @"INSERT INTO reports(reportid,report_information) VALUES(@id,@info)";

            db.Open();
            db.Insert(stm, values);
            db.Close();
        }

        public List<Reports> Select()
        {
            List<Reports> myReport = new List<Reports>();

            string stm = @"SELECT * from reports";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                Reports temp = new Reports()
                {
                    ReportID = item.reportid,
                    ReportInformation = item.report_information
                };
                myReport.Add(temp);
            }
            db.Close();
            return myReport;
        }

        public void Update(Reports reports)
        {
            var values = GetValues(reports);
            string stm = @"UPDATE reports SET report_information = @info WHERE reportid = @id";

            db.Open();
            db.Update(stm, values);
            db.Close();
        }

        public Dictionary<string, object> GetValues(Reports reports)
        {
            var values = new Dictionary<string, object>(){
                {"@id", reports.ReportID},
                {"@info", reports.ReportInformation}
            };

            return values;
        }
    }
}