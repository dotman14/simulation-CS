using System;

namespace web_simulator.Users
{
    class Faculty : User
    {
        public override void Login()
        {
            Console.WriteLine("Faculty Login");
        }

        public override void Logout()
        {
            Console.WriteLine("Faculty Login");
        }

        public void Survey()
        {
            Console.WriteLine("Faculty Survey");
        }

        public void ViewSchedule()
        {
            Console.WriteLine("Faculty ViewSchedule");
        }

        public void Roaster()
        {
            Console.WriteLine("Faculty Roaster");
        }

        public void SurveyResults()
        {
            Console.WriteLine("Faculty SurveyResults");
        }
    }
}
