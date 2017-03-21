using System;
using System.Reflection;
using web_simulator.Users;

namespace web_simulator
{
    static class Randomize
    {
        /// <summary>
        /// A wrapper method that run class methods depending on the object passed to it.
        /// </summary>
        /// <param name="typeOfUser"></param>
        /// <param name="noOfTimesToRunMethod"></param>
        public static void RunClassMethods(object typeOfUser, int noOfTimesToRunMethod)
        {
            if (typeOfUser is Student)
            {
                var student = (Student)typeOfUser;
                RunMethod(student, noOfTimesToRunMethod);
            }

            if (typeOfUser is Faculty)
            {
                var faculty = (Faculty)typeOfUser;
                RunMethod(faculty, noOfTimesToRunMethod);
            }

            if (typeOfUser is Admin)
            {
                var admin = (Admin)typeOfUser;
                RunMethod(admin, noOfTimesToRunMethod);
            }
        }

        /// <summary>
        /// A simple static method to dynamically run class methods.
        /// Each method has to run their respective Login and Logout methods first and last respectively. In between these methods,
        /// they can run other methods available to them as many times as possible.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="noOfTimesToRunMethod"></param>
        private static void RunMethod(User obj, int noOfTimesToRunMethod)
        {
            var rand = new Random();
            const BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
            var adminType = obj.GetType();

            obj.Login();
            for (var i = 0; i < noOfTimesToRunMethod; i++)
            {
                var methodIndex = rand.Next(0, obj.GetMethods(obj).Count);
                var method = adminType.GetMethod(obj.GetMethods(obj)[methodIndex], flags);
                Console.WriteLine(method.Invoke(obj, new object[] { }));
            }
            obj.Logout();
        }
    }
}
