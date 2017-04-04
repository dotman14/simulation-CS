using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using web_simulator.Users;

namespace web_simulator
{
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

        public static void RunClassMethods(User typeOfUser, int noOfTimesToRunMethod)
        {
            if (typeOfUser == null)
                return;
            if (typeOfUser is Student)
            {
                Console.WriteLine("login for {0}", typeOfUser.Name);
                RunMethod(typeOfUser, noOfTimesToRunMethod);
                Console.WriteLine("logout for {0}", typeOfUser.Name);
            }

            if (typeOfUser is Faculty)
            {
                Console.WriteLine("login for {0}", typeOfUser.Name);
                RunMethod(typeOfUser, noOfTimesToRunMethod);
                Console.WriteLine("logout for {0}", typeOfUser.Name);
            }

            if (typeOfUser is Admin)
            {
                Console.WriteLine("login for {0}", typeOfUser.Name);
                RunMethod(typeOfUser, noOfTimesToRunMethod);
                Console.WriteLine("logout for {0}", typeOfUser.Name);
            }
        }

        /// <summary>
        /// A simple static method to dynamically run class methods.
        /// Each method has to run their respective Login and Logout methods first and last respectively. In between these methods,
        /// they can run other methods available to them as many times as possible.
        /// We record the time taken to run all methods in the for loop, we assume that login and logout methods take constant time.
        /// After all methods has been executed, we lock and reduce the thread count, to make it available for other users to process jobs.
        /// For our implementation, ALL methods do not take any parameter(s), as such, new object[] { } is empty.
        /// </summary>
        /// <param name="user">Object we want to run their methods</param>
        /// <param name="noOfTimesToRunMethod">Number of times we want to run methods.</param>
        private static void RunMethod(User user, int noOfTimesToRunMethod)
        {
            var userType = user.GetType();
            var listOfMethods = new List<string>();
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < noOfTimesToRunMethod; i++)
            {
                var methodIndex = RandomNumber(0, user.GetMethods(user).Count);
                var method = userType.GetMethod(user.GetMethods(user)[methodIndex], MethodFlags);
                listOfMethods.Add(user.GetMethods(user)[methodIndex]);
                Console.WriteLine(method.Invoke(user, new object[] { }));
            }
            sw.Stop();
            lock (SyncLock)
            {
                UserConsumer.ThreadCount--;
                Logger.LogUserActivity(User.METHODTIME_LOGFILE, user.GetType().Name + " | ", user.Name + " | ", sw.Elapsed + " | ", string.Join(", ", listOfMethods) + " | ", DateTime.Now);
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
