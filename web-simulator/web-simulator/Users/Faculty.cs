using System;
using System.Threading;

namespace web_simulator.Users
{
    public class Faculty : User
    {
        /// <summary>
        ///
        /// </summary>
        private const int SLEEP_SURVERY = 13;
        private const int SLEEP_VIEW_SCHEDULE = 9;
        private const int SLEEP_ROASTER = 11;
        private const int SLEEP_SURVERY_RESULT = 17;

        public const string FACULTY_PRODUCER_LOGFILE = TextFile.FOLDER_LOCATION + "facultyProducerFile.txt";
        public const string FACULTY_CONSUMER_LOGFILE = TextFile.FOLDER_LOCATION + "facultyConsumerFile.txt";

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
            Thread.Sleep(SLEEP_SURVERY * 1000);
        }

        public void ViewSchedule()
        {
            Thread.Sleep(SLEEP_VIEW_SCHEDULE * 1000);
        }

        public void Roaster()
        {
            Thread.Sleep(SLEEP_ROASTER * 1000);
        }

        public void SurveyResults()
        {
            Thread.Sleep(SLEEP_SURVERY_RESULT * 1000);
        }
    }
}
