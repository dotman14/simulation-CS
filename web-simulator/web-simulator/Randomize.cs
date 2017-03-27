using System;
using System.Collections.Generic;
using System.Reflection;
using web_simulator.Users;

namespace web_simulator
{
    /// <summary>
    ///
    /// </summary>
    static class Randomize
    {
        static Randomize()
        {
            SyncLock = new object();
            Random = new Random();
        }

        private static readonly object SyncLock;
        private static readonly Random Random;

        /// <summary>
        /// A wrapper method that run class methods depending on the object passed to it.
        /// </summary>
        /// <param name="typeOfUser"></param>
        /// <param name="noOfTimesToRunMethod"></param>
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
        /// </summary>
        /// <param name="user"></param>
        /// <param name="noOfTimesToRunMethod"></param>
        private static void RunMethod(User user, int noOfTimesToRunMethod)
        {
            const BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
            var userType = user.GetType();
            var methodsCalled = new List<string>();

            for (var i = 0; i < noOfTimesToRunMethod; i++)
            {
                var methodIndex = RandomNumber(0, user.GetMethods(user).Count);
                var method = userType.GetMethod(user.GetMethods(user)[methodIndex], flags);
                Console.WriteLine(method.Invoke(user, new object[] { }));
            }
        }

        /// <summary>
        ///
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
