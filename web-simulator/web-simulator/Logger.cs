using System;
using System.IO;

namespace web_simulator
{
    /// <summary>
    /// A simple class to handle log information.
	/// There may be need to extend this class in the future (make it an interface and create concrete class to insert into txt files).
    /// </summary>
    class Logger
    {
        //public const string FOLDER_LOCATION = "C:/Users/dotun/Source/Repos/website/web-simulator/web-simulator/TextFiles/";
		public const string FOLDER_LOCATION = "/Users/dotun/Projects/web-simulator/web-simulator/TextFiles/";

        /// <summary>
        /// This method is used to insert time which an object is created and consumed into a text file.
        /// </summary>
        /// <param name="location">path to the file we want to write to</param>
        /// <param name="typeOfUser">Class an object belongs</param>
        /// <param name="nameOfUser">name of the user we are trying to record</param>
        /// <param name="dateTime">Time all actions on an object was completed</param>
        public static void LogUserCreation(string location, string typeOfUser, string nameOfUser, DateTime dateTime)
        {
            using (StreamWriter sw = File.AppendText(location))
            {
                sw.WriteLine(typeOfUser + nameOfUser + dateTime);
            }
        }

        /// <summary>
        /// This method is used to insert time taken to run methods on an object into a text file.
        /// </summary>
        /// <param name="location">path to the file we want to write to</param>
        /// <param name="typeOfUser">Class an object belongs</param>
        /// <param name="nameOfUser">name of the user we are trying to record</param>
        /// <param name="timeTaken">Time taken to run all the methods for an object</param>
        /// <param name="dateTime">Time all actions on an object was completed</param>
        public static void LogUserActivity(string location, string typeOfUser, string nameOfUser, string timeTaken, DateTime dateTime)
        {
            using (StreamWriter sw = File.AppendText(location))
            {
                sw.WriteLine(typeOfUser + nameOfUser + timeTaken + dateTime);
            }
        }
    }
}
