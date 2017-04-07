namespace web_simulator
{
    class Program
    {
        static void Main()
        {
            UserContainer.GenerateUsers();
            UserConsumer.Consumer();
        }
    }
}
