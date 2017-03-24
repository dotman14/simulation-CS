using System;
using System.Threading;

namespace web_simulator.Users
{
    public class Faculty : User
    {
        const int SLEEP_SURVERY = 9;
        const int SLEEP_VIEW_SCHEDULE = 10;
        const int SLEEP_ROASTER = 7;
        const int SLEEP_SURVERY_RESULT = 11;

        public override void Login()
        {
            Console.WriteLine("Faculty Login");
        }

        public override void Logout()
        {
            Console.WriteLine("Faculty Logout");
        }

        public int Survey()
        {
            Thread.Sleep(SLEEP_SURVERY * 1000);
            return SLEEP_SURVERY;
        }

        public int ViewSchedule()
        {
            Thread.Sleep(SLEEP_VIEW_SCHEDULE * 1000);
            return SLEEP_VIEW_SCHEDULE;
        }

        public int Roaster()
        {
            Thread.Sleep(SLEEP_ROASTER * 1000);
            return SLEEP_ROASTER;
        }

        public int SurveyResults()
        {
            Thread.Sleep(SLEEP_SURVERY_RESULT * 1000);
            return SLEEP_SURVERY_RESULT;
        }
    }
}
