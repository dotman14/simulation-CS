using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using web_simulator.Users;

namespace web_simulator
{
    /// <summary>
    ///
    /// </summary>
    public class UserConsumer
    {
        /// <summary>
        ///
        /// </summary>
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="studentQueue"></param>
        private static void StudentConsumer(Queue<Student> studentQueue)
        {
            var localStudent = new Student();
            Stopwatch stopwatch = new Stopwatch();
            lock (studentQueue)
            {
                if (studentQueue.Count != 0)
                {
                    localStudent = studentQueue.Dequeue();
                    Logger.LogUserCreation(Student.STUDENT_CONSUMER_LOGFILE, localStudent.GetType().Name + " | ", localStudent.Name + " | ", DateTime.Now);
                }
            }
            stopwatch.Start();
            Randomize.RunClassMethods(localStudent, Randomize.RandomNumber(1, 4));
            stopwatch.Stop();
            Logger.LogUserActivity(Student.STUDENT_METHODTIME_LOGFILE, localStudent.GetType().Name + " | ", localStudent.Name + " | ", stopwatch.Elapsed + " | ", DateTime.Now);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="facultyQueue"></param>
        private static void FacultyConsumer(Queue<Faculty> facultyQueue)
        {
            var localFaculty = new Faculty();
            Stopwatch stopwatch = new Stopwatch();
            lock (facultyQueue)
            {
                if (facultyQueue.Count != 0)
                {
                    localFaculty = facultyQueue.Dequeue();
                    Logger.LogUserCreation(Faculty.FACULTY_CONSUMER_LOGFILE, localFaculty.GetType().Name + " | ", localFaculty.Name + " | ", DateTime.Now);
                }
            }
            stopwatch.Start();
            Randomize.RunClassMethods(localFaculty, Randomize.RandomNumber(1, 4));
            stopwatch.Stop();
            Logger.LogUserActivity(Faculty.FACULTY_METHODTIME_LOGFILE, localFaculty.GetType().Name + " | ", localFaculty.Name + " | ", stopwatch.Elapsed + " | ", DateTime.Now);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="adminQueue"></param>
        private static void AdminConsumer(Queue<Admin> adminQueue)
        {
            var localAdmin = new Admin();
            Stopwatch stopwatch = new Stopwatch();
            lock (adminQueue)
            {
                if (adminQueue.Count != 0)
                {
                    localAdmin = adminQueue.Dequeue();
                    Logger.LogUserCreation(Admin.ADMIN_CONSUMER_LOGFILE, localAdmin.GetType().Name + " | ", localAdmin.Name + " | ", DateTime.Now);
                }
            }
            stopwatch.Start();
            Randomize.RunClassMethods(localAdmin, Randomize.RandomNumber(1, 4));
            stopwatch.Stop();
            Logger.LogUserActivity(Admin.ADMIN_METHODTIME_LOGFILE, localAdmin.GetType().Name + " | ", localAdmin.Name + " | ", stopwatch.Elapsed + " | ", DateTime.Now);
        }
    }
}
