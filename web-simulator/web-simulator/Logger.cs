using System;
using System.IO;

namespace web_simulator
{
    /// <summary>
    ///
    /// </summary>
    class Logger
    {
        public const string FOLDER_LOCATION = "C:/Users/dotun/Source/Repos/website/web-simulator/web-simulator/TextFiles/";

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="typeOfUser"></param>
        /// <param name="nameOfUser"></param>
        /// <param name="dateTime"></param>
        public static void LogUserCreation(string location, string typeOfUser, string nameOfUser, DateTime dateTime)
        {
            using (StreamWriter sw = File.AppendText(location))
            {
                sw.WriteLine(typeOfUser + nameOfUser + dateTime);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="typeOfUser"></param>
        /// <param name="nameOfUser"></param>
        /// <param name="timeTaken"></param>
        /// <param name="dateTime"></param>
        public static void LogUserActivity(string location, string typeOfUser, string nameOfUser, string timeTaken, DateTime dateTime)
        {
            using (StreamWriter sw = File.AppendText(location))
            {
                sw.WriteLine(typeOfUser + nameOfUser + timeTaken + dateTime);
            }
        }
    }
}
