using System;
using System.Reflection;
using web_simulator.Users;

namespace web_simulator
{
    static class Randomize
    {
        /// <summary>
        /// This static method is used to dynamically run methods of a class
        /// </summary>
        /// <param name="typeOfUser"></param>
        /// <param name="noOfTimesToRunMethod"></param>
        public static void RunClassMethods(object typeOfUser, int noOfTimesToRunMethod)
        {
            var rand = new Random();

            if (typeOfUser is Student)
            {
                var student = (Student)typeOfUser;
                student.Login();
                for (var i = 0; i < noOfTimesToRunMethod; i++)
                {
                    var methodIndex = rand.Next(0, student.GetMethods(student).Count);
                    var studentType = student.GetType();
                    var method = studentType.GetMethod(student.GetMethods(student)[methodIndex], BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                    Console.WriteLine(method.Invoke(student, new object[] { }));
                }
                student.Logout();
            }

            if (typeOfUser is Faculty)
            {
                var faculty = (Faculty)typeOfUser;
                faculty.Login();
                for (var i = 0; i < noOfTimesToRunMethod; i++)
                {
                    var methodIndex = rand.Next(0, faculty.GetMethods(faculty).Count);
                    var facultyType = faculty.GetType();
                    var method = facultyType.GetMethod(faculty.GetMethods(faculty)[methodIndex], BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                    Console.WriteLine(method.Invoke(faculty, new object[] { }));
                }
                faculty.Logout();
            }

            if (typeOfUser is Admin)
            {
                var admin = (Admin)typeOfUser;
                admin.Login();
                for (var i = 0; i < noOfTimesToRunMethod; i++)
                {
                    var methodIndex = rand.Next(0, admin.GetMethods(admin).Count);
                    var adminType = admin.GetType();
                    var method = adminType.GetMethod(admin.GetMethods(admin)[methodIndex], BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                    Console.WriteLine(method.Invoke(admin, new object[] { }));
                }
                admin.Logout();
            }
        }
    }
}
