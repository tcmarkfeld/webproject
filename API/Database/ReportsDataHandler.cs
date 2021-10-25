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
        public void Delete(Reports reports)
        {
            string stm = $@"DELETE FROM reports WHERE reportid = {reports.ReportID}";
            db.Delete(stm);
        }

        public void Insert(Reports reports)
        {
            string stm = @"INSERT INTO reports(reportid,report_information) VALUES(@id,@info)";
            db.Open();
            Dictionary<string,object> fields = new Dictionary<string, object>();
            fields.Add("@id",reports.ReportID);
            fields.Add("@info",reports.ReportInformation);
            db.Insert(stm,fields);
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
            string stm = @"UPDATE reports SET report_information = @info WHERE reportid = @id";
            db.Open();
            Dictionary<string,object> fields = new Dictionary<string, object>();
            fields.Add("@id",reports.ReportID);
            fields.Add("@info",reports.ReportInformation);
            db.Update(stm,fields);
            db.Close();
        }
    }
}