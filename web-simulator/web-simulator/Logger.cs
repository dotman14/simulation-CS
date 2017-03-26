using System;
using System.IO;

namespace web_simulator
{
    class Logger
    {
        public const string FOLDER_LOCATION = "C:/Users/dotun/Source/Repos/website/web-simulator/web-simulator/TextFiles/";

        public static void InsertUserGeneration(string location, string typeOfUser, string nameOfUser, DateTime dateTime)
        {
            using (StreamWriter sw = File.AppendText(location))
            {
                sw.WriteLine(typeOfUser + nameOfUser + dateTime);
            }
        }
    }
}
