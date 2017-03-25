using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;

namespace web_simulator
{
    public class UserConsumer
    {
        static readonly Random Random = new Random();
        //const int MIN_NO_OF_METHODS = 0;
        public static void Consumer()
        {
            while (true)
            {
                if (UserContainer.StudentQueue.Count != 0)
                {
                    var student = new Thread(() => StudentConsumer(UserContainer.StudentQueue));
                    student.Start();
                }

                if (UserContainer.StudentQueue.Count != 0)
                {
                    var faculty = new Thread(() => FacultyConsumer(UserContainer.FacultyQueue));
                    faculty.Start();
                }

                if (UserContainer.StudentQueue.Count != 0)
                {
                    var admin = new Thread(() => AdminConsumer(UserContainer.AdminQueue));
                    admin.Start();
                }
            }
        }

        private static void StudentConsumer(Queue<Student> studentQueue)
        {
            var localStudent = new Student();
            lock (studentQueue)
            {
                if(studentQueue.Count != 0)
                {
                    var stu = studentQueue.Dequeue();
                    localStudent = stu;
                }
            }
            Randomize.RunClassMethods(localStudent, Random.Next(1, 4));
        }

        private static void FacultyConsumer(Queue<Faculty> facultyQueue)
        {
            var localFaculty = new Faculty();
            lock (facultyQueue)
            {
                if (facultyQueue.Count != 0)
                {
                    var fac = facultyQueue.Dequeue();
                    localFaculty = fac;
                }
            }
            Randomize.RunClassMethods(localFaculty, Random.Next(1, 4));
        }

        private static void AdminConsumer(Queue<Admin> adminQueue)
        {
            var localAdmin = new Admin();
            lock (adminQueue)
            {
                if (adminQueue.Count != 0)
                {
                    var adm = adminQueue.Dequeue();
                    localAdmin = adm;
                }
            }
            Randomize.RunClassMethods(localAdmin, Random.Next(1, 4));
        }
    }
}
