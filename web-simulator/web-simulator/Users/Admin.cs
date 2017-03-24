using System;
using System.Threading;

namespace web_simulator.Users
{
	public class Admin : User
    {
		const int sleepViewReport = 10;

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
			Thread.Sleep(sleepViewReport * 1000);
			return sleepViewReport;
        }
    }
}
