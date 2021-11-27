using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace API.database
{
    public class Database
    {
        public string cs { get; set; }
        public MySqlConnection Conn { get; set; }
        public Database()
        {
            string server = Environment.GetEnvironmentVariable("qlg_database_server");

            string name = Environment.GetEnvironmentVariable("qlg_database_name");

            string port = Environment.GetEnvironmentVariable("qlg_database_port");

            string userName = Environment.GetEnvironmentVariable("qlg_database_username");

            string password = Environment.GetEnvironmentVariable("qlg_database_password");

            System.Console.WriteLine("got the database " + server);

            this.cs = $@"server = {server};userName = {userName};database = {name};port = {port}; password={password};";
            this.Conn = new MySqlConnection(this.cs);
        }

        public void Open()
        {
            this.Conn.Open();
        }

        public void Close()
        {
            this.Conn.Close();
        }

        public List<ExpandoObject> Select(string query)
        {
            List<ExpandoObject> results = new();
            try
            {
                using var cmd = new MySqlCommand(query, this.Conn);
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var temp = new ExpandoObject() as IDictionary<string, Object>;
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        temp.TryAdd(rdr.GetName(i), rdr.GetValue(i));
                    }

                    results.Add((ExpandoObject)temp);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Select Query Error");
                System.Console.WriteLine(e.Message);
            }

            return results;
        }

        public void Insert(string query, Dictionary<string, object> values)
        {
            QueryWithData(query, values);
        }

        public void Update(string query, Dictionary<string, object> values)
        {
            QueryWithData(query, values);
        }

        public void Delete(string stm)
        {
            using var cmd = new MySqlCommand(stm,this.Conn);
            cmd.ExecuteNonQuery();
        }
        

        private void QueryWithData(string query, Dictionary<string, object> values)
        {
            try
            {
                using var cmd = new MySqlCommand(query, this.Conn);
                foreach (var p in values)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error Inserting Data");
                System.Console.WriteLine(e.Message);
            }
        }
    }
}