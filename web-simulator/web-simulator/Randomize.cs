using System;
using System.Reflection;
using System.Threading;
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

        private static void RunMethod(User user, int noOfTimesToRunMethod)
        {
            var userType = user.GetType();
            for (var i = 0; i < noOfTimesToRunMethod; i++)
            {
                var start = DateTime.Now.ToString("HH:mm:ss.ffffff");
                var methodIndex = RandomNumber(0, user.GetMethods(user).Count);
                var method = userType.GetMethod(user.GetMethods(user)[methodIndex], MethodFlags);
                Console.Write(method.Invoke(user, new object[] { }));
                //TextFile.LogEachMethod(User.METHODTIME_LOGFILE, user.GetType().Name + " | ", user.Name + " | ", user.GetMethods(user)[methodIndex] + " | ", DateTime.Parse(start), DateTime.Parse(DateTime.Now.ToString("HH:mm:ss.ffffff")));
                Sql.LogEachMethod("UserMethods", user.GetType().Name, user.Name, user.GetMethods(user)[methodIndex], DateTime.Parse(start), DateTime.Parse(DateTime.Now.ToString("HH:mm:ss.ffffff")));
            }
            Interlocked.Decrement(ref UserConsumer.ThreadCount);
            Console.WriteLine("Thread Count is: {0}", UserConsumer.ThreadCount);

        }

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
