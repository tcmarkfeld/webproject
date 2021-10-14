using API.Models.Interfaces.Delete;
using MySql.Data.MySqlClient;
using webproject;

namespace API.Database.Delete
{
    public class DeleteAdmin : IDeleteAdmin
    {
        void IDeleteAdmin.DeleteAdmin()
        {
            // IGetPosts getPosts = new GetThePosts();
            // getPosts.GetPosts();
            // int id = 0;
            // System.Console.WriteLine("What is the ID of the post you would like to delete?");
            // try
            // {
            //     id = int.Parse(System.Console.ReadLine());
            // }
            // catch (System.Exception e)
            // {
            //     System.Console.WriteLine("Invalid selection. Must be a valid integer", e);
            // }

            // ConnectionString myConnection = new ConnectionString();
            // string cs = myConnection.cs;

            // using var con = new MySqlConnection(cs);
            // con.Open();

            // string stm0 = @"select count(*) from posts;";
            // using var cmd0 = new MySqlCommand(stm0, con);
            // cmd0.ExecuteNonQuery();
            // int temp = int.Parse(cmd0.ExecuteScalar().ToString());

            // if (id <= temp && id > 0)
            // {
            //     string stm = @"DELETE FROM posts WHERE (`id` =" + id + ");";
            //     using var cmd = new MySqlCommand(stm, con);
            //     cmd.ExecuteNonQuery();

            //     System.Console.WriteLine($"Post {id} has been successfully deleted");
            // }
            // else
            // {
            //     System.Console.WriteLine($"Invalid selection. ID {id} does not exist");
            // }
        }
    }
}