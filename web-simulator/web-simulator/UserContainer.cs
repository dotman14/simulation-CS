using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using web_simulator.Users;

namespace web_simulator
{
    class UserContainer
    {
        public static readonly List<Student> StudentList = new List<Student>();
        public static readonly List<Faculty> FacultyList = new List<Faculty>();
        public static readonly List<Admin>   AdminList   = new List<Admin>();
        public static readonly List<User> AllUsers = new List<User>();

        public void GenerateUsers()
        {
            var studentThread = new Thread(GenerateStudent);
            var facultyThread = new Thread( GenerateFaculty);
            var adminThread   = new Thread(GenerateAdmin);

            studentThread.Start();
            facultyThread.Start();
            adminThread.Start();

            Scheduler.Dispatch();
        }

        private static void GenerateStudent()
        {
            var timeIncreament = 0;
            while (true)
            {
                timeIncreament += 5;
                Thread.Sleep(5000);
                var student = new Student
                {
                    InterArrivalTime = timeIncreament,
                    Name = "student " + timeIncreament
                };
                StudentList.Add(student);
                //AllUsers.Add(student);
                Console.WriteLine(student);

            }
        }

        private static void GenerateFaculty()
        {
            var timeIncreament = 0;
            while (true)
            {
                timeIncreament += 13;
                Thread.Sleep(13000);
                var faculty = new Faculty
                {
                    InterArrivalTime = timeIncreament,
                    Name = "faculty " + timeIncreament
                };
                FacultyList.Add(faculty);
                //AllUsers.Add(faculty);
                Console.WriteLine(faculty);
            }
        }

        private static void GenerateAdmin()
        {
            var timeIncreament = 0;
            while (true)
            {
                timeIncreament += 17;
                Thread.Sleep(17000);
                var admin = new Admin
                {
                    InterArrivalTime = timeIncreament,
                    Name = "admin " + timeIncreament
                };
                AdminList.Add(admin);
                //AllUsers.Add(admin);
                Console.WriteLine(admin);
            }
        }
    }
}