using System;

namespace web_simulator
{
    interface ILog
    {
        void LogDequeue(string location, string typeOfUser, string nameOfUser, int threadCount, DateTime dateTime);
        void LogEnqueue(string location, string typeOfUser, string nameOfUser, DateTime dateTime);
        void LogEachMethod(string location, string typeOfUser, string nameOfUser, string methods, DateTime start, DateTime end);
    }
}

//t15-s100-f50-a25
