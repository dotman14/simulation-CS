﻿using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;

namespace web_simulator
{
    class UserContainer
    {
        private static readonly List<Student> StudentList = new List<Student>();
        private static readonly List<Faculty> FacultyList = new List<Faculty>();
        private static readonly List<Admin>   AdminList   = new List<Admin>();

        public void GenerateUsers()
        {
            var studentThread = new Thread(GenerateStudent);
            var facultyThread = new Thread(GenerateFaculty);
            var adminThread   = new Thread(GenerateAdmin);

            studentThread.Start();
            facultyThread.Start();
            adminThread.Start();
        }

        private static void GenerateStudent()
        {
            var timeIncreament = 0;
            while (true)
            {
                timeIncreament += 3;
                var student = new Student
                {
                    InterArrivalTime = timeIncreament,
                    Name = "student " + timeIncreament
                };
                StudentList.Add(student);
                Console.WriteLine(student);
                Thread.Sleep(3000);
            }
        }

        private static void GenerateFaculty()
        {
            var timeIncreament = 0;
            while (true)
            {
                timeIncreament += 6;
                var faculty = new Faculty
                {
                    InterArrivalTime = timeIncreament,
                    Name = "faculty " + timeIncreament
                };
                FacultyList.Add(faculty);
                Console.WriteLine(faculty);
                Thread.Sleep(6000);
            }
        }

        private static void GenerateAdmin()
        {
            var timeIncreament = 0;
            while (true)
            {
                timeIncreament += 10;
                var admin = new Admin
                {
                    InterArrivalTime = timeIncreament,
                    Name = "admin " + timeIncreament
                };
                AdminList.Add(admin);
                Console.WriteLine(admin);
                Thread.Sleep(10000);
            }
        }
    }
}
