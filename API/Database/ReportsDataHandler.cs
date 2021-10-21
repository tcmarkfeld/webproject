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
            throw new System.NotImplementedException();
        }

        public void Insert(Reports reports)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}