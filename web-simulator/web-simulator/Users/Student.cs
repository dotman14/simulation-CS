using System;
using System.Threading;

namespace web_simulator.Users
{
    public class Student : User
    {
		const int sleepCompleteSurvery = 15;
		const int sleepViewSurvery = 9;

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
			Thread.Sleep(sleepCompleteSurvery * 1000);
			return sleepCompleteSurvery;
        }

        public int ViewSurvery()
        {
			Thread.Sleep(sleepViewSurvery * 1000);
			return sleepViewSurvery;
        }
    }
}
