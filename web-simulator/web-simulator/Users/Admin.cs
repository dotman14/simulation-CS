using System;

namespace web_simulator.Users
{
    class Admin : User
    {
        public int InterArrivalTime;
        public string Name;
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

        public override string ToString()
        {
            return $"Name: {Name}; Time: {InterArrivalTime}";
        }
    }
}
