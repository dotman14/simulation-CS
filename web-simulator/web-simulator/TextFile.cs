using System;
using System.IO;

namespace web_simulator
{
	class TextFile : ILog
	{
		///public const string FOLDER_LOCATION = "C:/Users/dotun/Source/Repos/website/web-simulator/web-simulator/TextFiles/";
		public const string FOLDER_LOCATION = "/Users/dotun/RiderProjects/Web-Simulator/web-simulator/web-simulator/TextFiles/";

	    public static void LogUserDequeue(string location, string typeOfUser, string nameOfUser, int threadCount, DateTime dateTime)
		{
			using (var sw = File.AppendText(location))
			{
				sw.WriteLine(typeOfUser + nameOfUser + threadCount + dateTime);
			}
		}

		public static void LogUserEnqueue(string location, string typeOfUser, string nameOfUser, DateTime dateTime)
		{
			using (var sw = File.AppendText(location))
			{
				sw.WriteLine(typeOfUser + nameOfUser + dateTime);
			}
		}

		public static void LogEachMethod(string location, string typeOfUser, string nameOfUser, string method, DateTime start, DateTime end)
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

		void ILog.LogDequeue(string location, string typeOfUser, string nameOfUser, int threadCount, DateTime dateTime)
		{
			LogUserDequeue(location, typeOfUser, nameOfUser, threadCount, dateTime);
		}

		void ILog.LogEnqueue(string location, string typeOfUser, string nameOfUser, DateTime dateTime)
		{
			LogUserEnqueue(location, typeOfUser, nameOfUser, dateTime);
		}
	}
}
