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

        public int ViewReport()
        {
            Thread.Sleep(SLEEP_VIEW_REPORT * 1000);
            return SLEEP_VIEW_REPORT;
        }
    }
}
