using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace web_simulator
{
    /// <summary>
    /// Program driver.
    /// </summary>
    class Program
    {
        static void Main()
        {
            try
            {
                var conn = ConfigurationManager.ConnectionStrings["simulator"].ConnectionString;
                var connection = new SqlConnection(conn);

                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                connection.Open();
                var sb = new StringBuilder();
                sb.Append("SELECT * FROM UserMethods");
                var sql = sb.ToString();

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //UserContainer.GenerateUsers();
            //UserConsumer.Consumer();
        }
    }
}
