using System;
using System.Threading;

namespace web_simulator.Users
{
    public class Student : User
    {
        private const int SLEEP_COMPLETE_SURVERY = 15;
        private const int SLEEP_VIEW_SURVERY = 9;

        public const string STUDENT_PRODUCER_LOGFILE = Logger.FOLDER_LOCATION + "studentProducerFile.txt";
        public const string STUDENT_CONSUMER_LOGFILE = Logger.FOLDER_LOCATION + "studentConsumerFile.txt";
        public const string STUDENT_METHODTIME_LOGFILE = Logger.FOLDER_LOCATION + "studentMethodTimeFile.txt";

        /// <summary>
        ///
        /// </summary>
        public override void Login()
        {
            Console.WriteLine("Student Login");
        }

        /// <summary>
        ///
        /// </summary>
        public override void Logout()
        {
            Console.WriteLine("Student Logout");
        }

        /// <summary>
        ///
        /// </summary>
        public void CompleteSurvery()
        {
            Console.WriteLine("Student CompleteSurvery Start");
            Thread.Sleep(SLEEP_COMPLETE_SURVERY * 1000);
            Console.WriteLine("Student CompleteSurvery End");
            Console.WriteLine("Student CompleteSurvery took 15secs");
        }

        /// <summary>
        ///
        /// </summary>
        public void ViewSurvery()
        {
            Console.WriteLine("Student ViewSurvery Start");
            Thread.Sleep(SLEEP_VIEW_SURVERY * 1000);
            Console.WriteLine("Student ViewSurvery End");
            Console.WriteLine("Student ViewSurvery took 9secs");
        }
    }
}
