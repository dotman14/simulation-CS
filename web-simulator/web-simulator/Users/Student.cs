using System;

namespace web_simulator.Users
{
    public class Student : User
    {
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

        }

        public void ViewSurvery()
        {

        }

        public void GetMetrics()
        {
            Console.WriteLine("Student GetMetrics");
        }
    }
}
