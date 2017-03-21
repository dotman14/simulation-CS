using System;

namespace web_simulator.Users
{
    class Admin : User
    {
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
            Console.WriteLine("Admin View Report");
        }
    }
}
