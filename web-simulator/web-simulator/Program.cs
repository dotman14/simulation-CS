namespace web_simulator
{
    /// <summary>
    /// Program driver.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            UserContainer.GenerateUsers();
            UserConsumer.Consumer();
        }
    }
}
