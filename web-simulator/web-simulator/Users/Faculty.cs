using System;
using System.Threading;

namespace web_simulator.Users
{
	public class Faculty : User
    {
		const int sleepSurvery = 9;
		const int sleepViewSchedule = 10;
		const int sleepRoaster = 7;
		const int sleepSurveryResult = 11;

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
			Thread.Sleep(sleepSurvery * 1000);
			return sleepSurvery;
        }

        public int ViewSchedule()
        {
			Thread.Sleep(sleepViewSchedule * 1000);
			return sleepViewSchedule;
        }

        public int Roaster()
        {
			Thread.Sleep(sleepRoaster * 1000);
			return sleepRoaster;
        }

        public int SurveyResults()
        {
			Thread.Sleep(sleepSurveryResult * 1000);
			return sleepSurveryResult;
        }
    }
}
