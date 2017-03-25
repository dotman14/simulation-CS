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

        public void Survey()
        {
            Console.WriteLine("Faculty SLEEP_SURVERY Start");
            Thread.Sleep(SLEEP_SURVERY * 1000);
            Console.WriteLine("Faculty SLEEP_SURVERY End");
            Console.WriteLine("Faculty SLEEP_SURVERY took {0}secs", SLEEP_SURVERY);
        }

        public void ViewSchedule()
        {
            Console.WriteLine("Faculty SLEEP_VIEW_SCHEDULE Start");
            Thread.Sleep(SLEEP_VIEW_SCHEDULE * 1000);
            Console.WriteLine("Faculty SLEEP_VIEW_SCHEDULE End");
            Console.WriteLine("Faculty SLEEP_VIEW_SCHEDULE took {0}secs", SLEEP_VIEW_SCHEDULE);
        }

        public void Roaster()
        {
            Console.WriteLine("Faculty SLEEP_ROASTER Start");
            Thread.Sleep(SLEEP_ROASTER * 1000);
            Console.WriteLine("Faculty SLEEP_ROASTER End");
            Console.WriteLine("Faculty SLEEP_ROASTER took {0}secs", SLEEP_ROASTER);
        }

        public void SurveyResults()
        {
            Console.WriteLine("Faculty SLEEP_SURVERY_RESULT Start");
            Thread.Sleep(SLEEP_SURVERY_RESULT * 1000);
            Console.WriteLine("Faculty SLEEP_SURVERY_RESULT End");
            Console.WriteLine("Faculty SLEEP_SURVERY_RESULT took {0}secs", SLEEP_SURVERY_RESULT);
        }
    }
}
