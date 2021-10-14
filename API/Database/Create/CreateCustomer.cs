using API.Models.Interfaces.Create;
using MySql.Data.MySqlClient;
using webproject;

namespace API.Database.Create
{
    public class CreateCustomer : ICreateCustomer
    {
        void ICreateCustomer.CreateCustomer()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            try
            {
                string stm = @"INSERT INTO customer(post, date) VALUES(@post, @date)";

                using var cmd = new MySqlCommand(stm, con);

                //cmd.Parameters.AddWithValue("@post", post);
                //cmd.Parameters.AddWithValue("@date", secondsStripped);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                string stm = @"CREATE TABLE `rzjhrsv8r22agupi`.`customer` (`customerid` INT NOT NULL AUTO_INCREMENT,`firstname` VARCHAR(45) NOT NULL,`lastname` VARCHAR(45) NOT NULL,`birthdate` DATE NOT NULL,`email` VARCHAR(45) NOT NULL,`creditcard` INT(16) NULL,`shippingaddress` VARCHAR(45) NULL,`billingaddress` VARCHAR(45) NULL,PRIMARY KEY (`customerid`));";
                using var cmd = new MySqlCommand(stm, con);
                cmd.ExecuteNonQuery();

                stm = @"INSERT INTO customer(post, date) VALUES(@post, @date)";

                using var cmd2 = new MySqlCommand(stm, con);

                //cmd2.Parameters.AddWithValue("@post", post);
                //cmd2.Parameters.AddWithValue("@date", secondsStripped);
                cmd2.ExecuteNonQuery();
            }
        }
    }
}