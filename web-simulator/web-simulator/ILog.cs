using System;

namespace web_simulator
{
    interface ILog
    {
        void LogUserCreation(string location, string typeOfUser, string nameOfUser, string dateTime);
        //void LogUserActivity(string location, string typeOfUser, string nameOfUser, string timeTaken, string methods, string dateTime);
        void LogEachMethod(string location, string typeOfUser, string nameOfUser, string methods, string start, string end);
    }
}
