using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_simulator
{
    interface ILog
    {
        void LogUserCreation(string location, string typeOfUser, string nameOfUser, DateTime dateTime);

        void LogUserActivity(string location, string typeOfUser, string nameOfUser, string timeTaken, string methods,
            DateTime dateTime);
    }
}
