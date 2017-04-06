using System;

namespace web_simulator
{
    interface ILog
    {
        void LogUserCreation(string location, string typeOfUser, string nameOfUser, DateTime dateTime);
        ///void LogUserActivity(string location, string typeOfUser, string nameOfUser, string timeTaken, string methods, string dateTime);
        void LogEachMethod(string location, string typeOfUser, string nameOfUser, string methods, DateTime start, DateTime end);
    }
}
