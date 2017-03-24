using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;

namespace web_simulator
{
    class UserContainer
    {
		public static readonly Queue<Student> StudentQueue = new Queue<Student>();
		public static readonly Queue<Faculty> FacultyQueue = new Queue<Faculty>();
		public static readonly Queue<Admin> AdminQueue = new Queue<Admin>();

        public void GenerateUsers()
        {
            var studentThread = new Thread(GenerateStudent);
            var facultyThread = new Thread(GenerateFaculty);
            var adminThread = new Thread(GenerateAdmin);

            studentThread.Start();
            facultyThread.Start();
            adminThread.Start();
        }

        private static void GenerateStudent()
        {
            var timeIncreament = 0;
            Random random = new Random();
            while (true)
            {
                //var average = Enumerable.Range(3, 5).ToList().Average();
                //(3 + 4 + 5 + 6 + 7) / 5 = 5
                int interArrivalTime = random.Next(3, 7);
                timeIncreament += interArrivalTime;

                Thread.Sleep(interArrivalTime * 1000);

                var student = new Student
                {
                    InterArrivalTime = timeIncreament,
                    Name = "student " + timeIncreament
                };
                StudentQueue.Enqueue(student);
                Console.WriteLine(student);

            }
        }

        private static void GenerateFaculty()
        {
            var timeIncreament = 0;
            Random random = new Random();
            while (true)
            {
                //var average = Enumerable.Range(7, 9).ToList().Average();
                //(7 + 8 + 9 + 10 + 11 + 12 + 13 + 14 + 15) / 9 = 11
                int interArrivalTime = random.Next(7, 15);
                timeIncreament += interArrivalTime;

                Thread.Sleep(interArrivalTime * 1000);

                var faculty = new Faculty
                {
                    InterArrivalTime = timeIncreament,
                    Name = "faculty " + timeIncreament
                };
                FacultyQueue.Enqueue(faculty);
                Console.WriteLine(faculty);
            }
        }

        private static void GenerateAdmin()
        {
            var timeIncreament = 0;
            Random random = new Random();
            while (true)
            {
                //var average = Enumerable.Range(13, 13).ToList().Average();
                //(13 + 14 + 15 + 16 + 17 + 18 + 19 + 20 + 21 + 22 + 23 + 24 + 25) / 13 = 19
                int interArrivalTime = random.Next(13, 25);
                timeIncreament += interArrivalTime;

                Thread.Sleep(interArrivalTime * 1000);

                var admin = new Admin
                {
                    InterArrivalTime = timeIncreament,
                    Name = "admin " + timeIncreament
                };
                AdminQueue.Enqueue(admin);
                Console.WriteLine(admin);
            }
        }
    }
}