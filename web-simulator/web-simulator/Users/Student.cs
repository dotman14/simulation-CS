using System;
using System.Threading;

namespace web_simulator.Users
{
    public class Student : User
    {
        const int SLEEP_COMPLETE_SURVERY = 15;
        const int SLEEP_VIEW_SURVERY = 9;

        public override void Login()
        {
            Console.WriteLine("Student Login");
        }

        public override void Logout()
        {
            Console.WriteLine("Student Logout");
        }

        public int CompleteSurvery()
        {
            Thread.Sleep(SLEEP_COMPLETE_SURVERY * 1000);
            return SLEEP_COMPLETE_SURVERY;
        }

        public int ViewSurvery()
        {
            Thread.Sleep(SLEEP_VIEW_SURVERY * 1000);
            return SLEEP_VIEW_SURVERY;
        }
    }
}
