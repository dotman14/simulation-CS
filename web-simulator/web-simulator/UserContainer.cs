using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;

namespace web_simulator
{
    class UserContainer
    {
        public static readonly Queue<Student> StudentList = new Queue<Student>();
        public static readonly Queue<Faculty> FacultyList = new Queue<Faculty>();
        public static readonly Queue<Admin>     AdminList = new Queue<Admin>();
        public static readonly Queue<User>       AllUsers = new Queue<User>();

        public void GenerateUsers()
        {
            var studentThread = new Thread(GenerateStudent);
            var facultyThread = new Thread(GenerateFaculty);
            var adminThread   = new Thread(GenerateAdmin);

            studentThread.Start();
            facultyThread.Start();
            adminThread.Start();

            //Scheduler.Dispatch(AllUsers.Dequeue());
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
                //StudentList.Enqueue(student);
                //AllUsers.Add(student);
                lock (AllUsers)
                {
                    AllUsers.Enqueue(student);
                }
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
                //FacultyList.Enqueue(faculty);
                //AllUsers.Add(faculty);
                lock (AllUsers)
                {
                    AllUsers.Enqueue(faculty);
                }
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
                //AdminList.Enqueue(admin);
                //AllUsers.Add(admin);
                lock (AllUsers)
                {
                    AllUsers.Enqueue(admin);
                }
                Console.WriteLine(admin);
            }
        }
    }
}