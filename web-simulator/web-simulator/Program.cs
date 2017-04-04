using System;

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
			catch (TypeInitializationException e)
            {
				Console.WriteLine(e.InnerException);
            }
            //UserContainer.GenerateUsers();
            //UserConsumer.Consumer();
        }
    }
}
