using API.Models.Interfaces.Create;
using MySql.Data.MySqlClient;
using webproject;

namespace API.Database.Create
{
    public class CreateAdmin : ICreateAdmin
    {
        void ICreateAdmin.CreateAdmin()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            try
            {
                //string stm = @"INSERT INTO admin(post, date) VALUES(@post, @date)";

                using var cmd = new MySqlCommand(stm, con);

                cmd.Parameters.AddWithValue("@post", post);
                cmd.Parameters.AddWithValue("@date", secondsStripped);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                string stm = @"CREATE TABLE `rzjhrsv8r22agupi`.`admin` (`adminid` INT NOT NULL AUTO_INCREMENT,`firstName` VARCHAR(45) NOT NULL,`lastName` VARCHAR(45) NOT NULL,`email` VARCHAR(45) NOT NULL,`position` VARCHAR(45) NOT NULL,`startdate` DATE NOT NULL,PRIMARY KEY (`adminid`));";
                using var cmd = new MySqlCommand(stm, con);
                cmd.ExecuteNonQuery();

                //stm = @"INSERT INTO posts(post, date) VALUES(@post, @date)";

                using var cmd2 = new MySqlCommand(stm, con);

                cmd2.Parameters.AddWithValue("@post", post);
                cmd2.Parameters.AddWithValue("@date", secondsStripped);
                cmd2.ExecuteNonQuery();
            }
        }
    }
}