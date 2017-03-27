namespace web_simulator
{
    /// <summary>
    ///
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            UserContainer uc = new UserContainer();
            uc.GenerateUsers();
            UserConsumer.Consumer();
        }
    }
}
