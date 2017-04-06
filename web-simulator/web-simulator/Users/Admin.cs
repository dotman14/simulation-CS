using System;
using System.Threading;

namespace web_simulator.Users
{
    public class Admin : User
    {
        private const int SLEEP_VIEW_REPORT = 15;

        public const string ADMIN_PRODUCER_LOGFILE = TextFile.FOLDER_LOCATION + "adminProducerFile.txt";
        public const string ADMIN_CONSUMER_LOGFILE = TextFile.FOLDER_LOCATION + "adminConsumerFile.txt";

        public override void Login()
        {
            Console.WriteLine("Admin Login");
        }

        public override void Logout()
        {
            Console.WriteLine("Admin Logout");
        }

        public void ViewReport()
        {
            Console.WriteLine("Admin SLEEP_VIEW_REPORT Start");
            Thread.Sleep(SLEEP_VIEW_REPORT * 1000);
            Console.WriteLine("Admin SLEEP_VIEW_REPORT End");
            Console.WriteLine("Admin SLEEP_VIEW_REPORT took {0}secs", SLEEP_VIEW_REPORT);
        }
    }
}
