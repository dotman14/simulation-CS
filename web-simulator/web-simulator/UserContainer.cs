using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;

namespace web_simulator
{
    class UserContainer
    {
        public static readonly List<Student> StudentList = new List<Student>();
        public static readonly List<Faculty> FacultyList = new List<Faculty>();
        public static readonly List<Admin> AdminList = new List<Admin>();

        public void GenerateUsers()
        {
            Thread studentThread = new Thread(GenerateStudent);
            Thread facultyThread = new Thread(GenerateFaculty);
            Thread adminThread   = new Thread(GenerateAdmin);

            studentThread.Start();
            facultyThread.Start();
            adminThread.Start();
        }

        private static void GenerateStudent()
        {
            while (true)
            {
                StudentList.Add(new Student());
                Thread.Sleep(3000);
            }
        }

        private static void GenerateFaculty()
        {
            while (true)
            {
                FacultyList.Add(new Faculty());
                Thread.Sleep(6000);
            }
        }

        private static void GenerateAdmin()
        {
            while (true)
            {
                AdminList.Add(new Admin());
                Thread.Sleep(10000);
            }
        }
    }
}
