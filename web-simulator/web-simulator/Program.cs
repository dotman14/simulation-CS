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
               Sql.LogUserCreation("UserProduce", "twwwwes555t", "tedasdasdasdst", DateTime.MaxValue);
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
