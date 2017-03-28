using System;
using System.Reflection;
using web_simulator.Users;

namespace web_simulator
{
	/// <summary>
	/// This class is used to manage random events in the application.
	/// </summary>
	static class Randomize
	{
		static Randomize()
		{
			SyncLock = new object();
			Random = new Random();
			MethodFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
		}

		private static readonly object SyncLock;
		private static readonly Random Random;
		public static readonly BindingFlags MethodFlags;

		/// <summary>
		/// A wrapper method that run class methods depending on the object passed to it.
		/// </summary>
		/// <param name="typeOfUser">Object we want to run their methods</param>
		/// <param name="noOfTimesToRunMethod">Number of times we want to run methods.</param>
		public static void RunClassMethods(User typeOfUser, int noOfTimesToRunMethod)
		{
			if (typeOfUser == null)
				return;
			if (typeOfUser is Student)
			{
				//typeOfUser.Login();
				Console.WriteLine("login for {0}", typeOfUser.Name);
				RunMethod(typeOfUser, noOfTimesToRunMethod);
				//typeOfUser.Logout();
				Console.WriteLine("logout for {0}", typeOfUser.Name);
			}

			if (typeOfUser is Faculty)
			{
				// typeOfUser.Login();
				Console.WriteLine("login for {0}", typeOfUser.Name);
				RunMethod(typeOfUser, noOfTimesToRunMethod);
				//typeOfUser.Logout();
				Console.WriteLine("logout for {0}", typeOfUser.Name);
			}

			if (typeOfUser is Admin)
			{
				//typeOfUser.Login();
				Console.WriteLine("login for {0}", typeOfUser.Name);
				RunMethod(typeOfUser, noOfTimesToRunMethod);
				//typeOfUser.Logout();
				Console.WriteLine("logout for {0}", typeOfUser.Name);
			}
		}

		/// <summary>
		/// A simple static method to dynamically run class methods.
		/// Each method has to run their respective Login and Logout methods first and last respectively. In between these methods,
		/// they can run other methods available to them as many times as possible.
		/// For our implementation, ALL methods do not take any parameter(s), as such, new object[] { } is empty.
		/// </summary>
		/// <param name="user">Object we want to run their methods</param>
		/// <param name="noOfTimesToRunMethod">Number of times we want to run methods.</param>
		private static void RunMethod(User user, int noOfTimesToRunMethod)
		{
			var userType = user.GetType();
			for (var i = 0; i < noOfTimesToRunMethod; i++)
			{
				var methodIndex = RandomNumber(0, user.GetMethods(user).Count);
				var method = userType.GetMethod(user.GetMethods(user)[methodIndex], MethodFlags);
				Console.WriteLine(method.Invoke(user, new object[] { }));
			}
		}

		/// <summary>
		/// A static class to return random number.
		/// In a tight loop, we need to lock our seed such that random does not return same number.
		/// We also use the same instance of Random across this application.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		//http://stackoverflow.com/a/768001/3067055
		public static int RandomNumber(int min, int max)
		{
			lock (SyncLock)
			{
				return Random.Next(min, max);
			}
		}
	}
}
