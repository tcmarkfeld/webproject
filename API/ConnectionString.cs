using System;
using MySql.Data.MySqlClient;
namespace webproject
{
    public class ConnectionString
    {
        public string cs { get; set; }

        public ConnectionString()
        {
            string server = "x8autxobia7sgh74.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "rzjhrsv8r22agupi";
            string port = "3306";
            string userName = "kxl4ao0g0vfyaf9s";
            string password = "yi2lmwj2eageojzj";

            cs = $@"server = {server};user = {userName};database = {database};port = {port}; password={password};";
        }
    }
}