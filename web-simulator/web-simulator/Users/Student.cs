﻿using System;
using System.Threading;

namespace web_simulator.Users
{
    public class Student : User
    {/// <summary>
    ///
    /// </summary>
        private const int SLEEP_COMPLETE_SURVERY = 17;
        private const int SLEEP_VIEW_SURVERY = 23;

        public const string STUDENT_PRODUCER_LOGFILE = TextFile.FOLDER_LOCATION + "studentProducerFile.txt";
        public const string STUDENT_CONSUMER_LOGFILE = TextFile.FOLDER_LOCATION + "studentConsumerFile.txt";

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
            Thread.Sleep(SLEEP_COMPLETE_SURVERY * 1000);
        }

        public void ViewSurvery()
        {
            Thread.Sleep(SLEEP_VIEW_SURVERY * 1000);
        }
    }
}
