using API.Models.Interfaces.Create;
using MySql.Data.MySqlClient;
using webproject;

namespace API.Database.Create
{
    public class CreatePlant : ICreatePlant
    {
        void ICreatePlant.CreatePlant()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            try
            {
                string stm = @"INSERT INTO plantinformation(post, date) VALUES(@post, @date)";

                using var cmd = new MySqlCommand(stm, con);

                //cmd.Parameters.AddWithValue("@post", post);
                //cmd.Parameters.AddWithValue("@date", secondsStripped);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                string stm = @"CREATE TABLE `rzjhrsv8r22agupi`.`plantinformation` (`plantid` INT NOT NULL AUTO_INCREMENT,`plantname` VARCHAR(45) NOT NULL,`location` VARCHAR(45) NOT NULL,`notimeswater` VARCHAR(45) NOT NULL,`information` LONGTEXT NOT NULL,`sunneeds` VARCHAR(45) NOT NULL,PRIMARY KEY (`plantid`));";
                using var cmd = new MySqlCommand(stm, con);
                cmd.ExecuteNonQuery();

                stm = @"INSERT INTO plantinformation(post, date) VALUES(@post, @date)";

                using var cmd2 = new MySqlCommand(stm, con);

                //cmd2.Parameters.AddWithValue("@post", post);
                //cmd2.Parameters.AddWithValue("@date", secondsStripped);
                cmd2.ExecuteNonQuery();
            }
        }
    }
}