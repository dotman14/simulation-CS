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

        public void CompleteSurvery()
        {
            Console.WriteLine("Student CompleteSurvery Start");
            Thread.Sleep(SLEEP_COMPLETE_SURVERY * 1000);
            Console.WriteLine("Student CompleteSurvery End");
            Console.WriteLine("Student CompleteSurvery took 15secs");
        }

        public void ViewSurvery()
        {
            Console.WriteLine("Student ViewSurvery Start");
            Thread.Sleep(SLEEP_VIEW_SURVERY * 1000);
            Console.WriteLine("Student ViewSurvery End");
            Console.WriteLine("Student ViewSurvery took 9secs");
        }
    }
}
