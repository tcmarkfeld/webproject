using API.Models.Interfaces.Create;
using MySql.Data.MySqlClient;
using webproject;

namespace API.Database.Create
{
    public class CreateCorporateGarden : ICreateCorporateGarden
    {
        void ICreateCorporateGarden.CreateCorporateGarden()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            try
            {
                string stm = @"INSERT INTO corporategarden(post, date) VALUES(@post, @date)";

                using var cmd = new MySqlCommand(stm, con);

                //cmd.Parameters.AddWithValue("@post", post);
                //cmd.Parameters.AddWithValue("@date", secondsStripped);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                string stm = @"CREATE TABLE `rzjhrsv8r22agupi`.`corporategarden` (`gardenid` INT NOT NULL AUTO_INCREMENT,`information` LONGTEXT NULL,PRIMARY KEY (`gardenid`));";
                using var cmd = new MySqlCommand(stm, con);
                cmd.ExecuteNonQuery();

                stm = @"INSERT INTO corporategarden(post, date) VALUES(@post, @date)";

                using var cmd2 = new MySqlCommand(stm, con);

                //cmd2.Parameters.AddWithValue("@post", post);
                //cmd2.Parameters.AddWithValue("@date", secondsStripped);
                cmd2.ExecuteNonQuery();
            }
        }
    }
}