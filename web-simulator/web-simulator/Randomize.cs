using System;
using System.Reflection;
using web_simulator.Users;

namespace web_simulator
{
    static class Randomize
    {
        public static void RunClassMethods(object typeOfUser, int runMethods)
        {
            var rand = new Random();

            if (typeOfUser is Student)
            {
                var student = (Student)typeOfUser;
                student.Login();
                for (var i = 0; i < runMethods; i++)
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
                for (var i = 0; i < runMethods; i++)
                {
                    var methodIndex = rand.Next(0, faculty.GetMethods(faculty).Count);
                    var studentType = faculty.GetType();
                    var method = studentType.GetMethod(faculty.GetMethods(faculty)[methodIndex], BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                    Console.WriteLine(method.Invoke(faculty, new object[] { }));
                }
                faculty.Logout();
            }

            if (typeOfUser is Admin)
            {
                var admin = (Admin)typeOfUser;
                admin.Login();
                for (var i = 0; i < runMethods; i++)
                {
                    var methodIndex = rand.Next(0, admin.GetMethods(admin).Count);
                    var studentType = admin.GetType();
                    var method = studentType.GetMethod(admin.GetMethods(admin)[methodIndex], BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                    Console.WriteLine(method.Invoke(admin, new object[] { }));
                }
                admin.Logout();
            }
        }
    }
}
