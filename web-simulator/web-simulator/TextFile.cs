using System;
using System.IO;

namespace web_simulator
{
	class TextFile : ILog
	{
		///public const string FOLDER_LOCATION = "C:/Users/dotun/Source/Repos/website/web-simulator/web-simulator/TextFiles/";
		public const string FOLDER_LOCATION = "/Users/dotun/RiderProjects/Web-Simulator/web-simulator/web-simulator/TextFiles/";

		public static void LogUserCreation(string location, string typeOfUser, string nameOfUser, int threadCount, DateTime dateTime)
		{
			using (var sw = File.AppendText(location))
			{
				sw.WriteLine(typeOfUser + nameOfUser + dateTime);
			}
		}

	    public static void LogUserActivity(string location, string typeOfUser, string nameOfUser, string timeTaken, string methods, string dateTime)
		{
			using (var sw = File.AppendText(location))
			{
				sw.WriteLine(typeOfUser + nameOfUser + timeTaken + methods + dateTime);
			}
		}



	    public static void LogEachMethod(string location, string typeOfUser, string nameOfUser, string method,
	        DateTime start, DateTime end)
	    {
	        using (var sw = File.AppendText(location))
	        {
	            sw.WriteLine(typeOfUser + nameOfUser + method + start + end);
	        }
	    }

	    void ILog.LogEachMethod(string location, string typeOfUser, string nameOfUser, string methods, DateTime start, DateTime end)
	    {
	        LogEachMethod(location, typeOfUser, nameOfUser, methods, start, end);
	    }

	    void ILog.LogUserCreation(string location, string typeOfUser, string nameOfUser, int threadCount, DateTime dateTime)
	    {
	        LogUserCreation(location, typeOfUser, nameOfUser, threadCount, dateTime);
	    }

//	    void ILog.LogUserActivity(string location, string typeOfUser, string nameOfUser, string timeTaken, string methods,
//	        string dateTime)
//	    {
//	        LogUserActivity(location, typeOfUser, nameOfUser, timeTaken, methods, dateTime);
//	    }
	}
}
