
namespace web_simulator
{
    /// <summary>
    /// Program driver.
    /// </summary>
    class Program
    {
        static void Main()
        {
            UserContainer.GenerateUsers();
            UserConsumer.Consumer();
        }
    }
}
