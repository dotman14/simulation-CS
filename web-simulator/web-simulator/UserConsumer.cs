using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;

namespace web_simulator
{
    public class UserConsumer
    {
        //const int MIN_NO_OF_METHODS = 0;
        public static void Consumer()
        {
            var stu = new Thread(() =>
            {
                while (true)
                {
                    if (UserContainer.StudentQueue.Count != 0)
                    {
                        StudentConsumer(UserContainer.StudentQueue);
                    }
                }
            });

            var fac = new Thread(() =>
            {
                while (true)
                {
                    if (UserContainer.FacultyQueue.Count != 0)
                    {
                        FacultyConsumer(UserContainer.FacultyQueue);
                    }
                }
            });

            var adm = new Thread(() =>
            {
                while (true)
                {
                    if (UserContainer.AdminQueue.Count != 0)
                    {
                        AdminConsumer(UserContainer.AdminQueue);
                    }
                }
            });

            stu.Start();
            fac.Start();
            adm.Start();
        }

        private static void StudentConsumer(Queue<Student> studentQueue)
        {
            var localStudent = new Student();
            lock (studentQueue)
            {
                if(studentQueue.Count != 0)
                {
                    localStudent = studentQueue.Dequeue();
                }
            }
            Randomize.RunClassMethods(localStudent, Randomize.RandomNumber(1, 4));
        }

        private static void FacultyConsumer(Queue<Faculty> facultyQueue)
        {
            var localFaculty = new Faculty();
            lock (facultyQueue)
            {
                if (facultyQueue.Count != 0)
                {
                    localFaculty = facultyQueue.Dequeue();
                }
            }
            Randomize.RunClassMethods(localFaculty, Randomize.RandomNumber(1, 4));
        }

        private static void AdminConsumer(Queue<Admin> adminQueue)
        {
            var localAdmin = new Admin();
            lock (adminQueue)
            {
                if (adminQueue.Count != 0)
                {
                    localAdmin = adminQueue.Dequeue();
                }
            }
            Randomize.RunClassMethods(localAdmin, Randomize.RandomNumber(1, 4));
        }
    }
}
