using System;
using System.Threading;

namespace web_simulator.Users
{
    public class Admin : User
    {
        const int SLEEP_VIEW_REPORT = 10;

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
