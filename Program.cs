using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace DatabaseWinAuthChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string db = ConfigurationManager.AppSettings["db"];
            string server = ConfigurationManager.AppSettings["server"];
            Console.WriteLine($"DB:{db}; Server:{server}; Windows Authentication: {Environment.UserName}");
            var connString = $"Server= {server}; Database= {db}; Integrated Security=True;";
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
                con.Close();
                Console.WriteLine("Connection Success.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Connection Failed.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();

        }
    }
}
