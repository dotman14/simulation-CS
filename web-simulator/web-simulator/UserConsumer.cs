using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;
using AppConfig = System.Configuration.ConfigurationManager;

namespace web_simulator
{
    /// <summary>
    /// Class to manage how objects are dequeued from the queue.
    /// </summary>
    public static class UserConsumer
    {
        static UserConsumer()
        {
            SyncLock = new object();
            MaxNoOfThreads = Convert.ToInt32(AppConfig.AppSettings["noOfThreads"]);
        }

        private static readonly object SyncLock;
        private static readonly int MaxNoOfThreads;
        public static int ThreadCount;

        /// <summary>
        /// This method is used to put each method that generates it's respective objects into threads.
        /// First we create new Thread() with the method we want to run, then we start the thread.
        /// </summary>
        public static void Consumer()
        {
            new Thread(() =>
            {
                while (true)
                {
                    if(UserContainer.StudentCounter >= Convert.ToInt32(AppConfig.AppSettings["noOfStudent"])) break;
                    StudentConsumer(UserContainer.StudentQueue);
                }
            }).Start();

            new Thread(() =>
            {
                while (true)
                {
                    if(UserContainer.FacultyCounter >= Convert.ToInt32(AppConfig.AppSettings["noOfFaculty"])) break;
                    FacultyConsumer(UserContainer.FacultyQueue);
                }
            }).Start();

            new Thread(() =>
            {
                while (true)
                {
                    if(UserContainer.AdminCounter >= Convert.ToInt32(AppConfig.AppSettings["noOfAdmin"])) break;
                    AdminConsumer(UserContainer.AdminQueue);
                }
            }).Start();
        }

        /// <summary>
        /// This method is used to Dequeue elements at the top of the queue. We make sure to lock the queue to make sure, we are not enqueuing and dequeuing to the same queue at the same time.
        /// This method records the time of dequeuing and also time after which all random methods has been executed on the dequeued object.
        ///
        /// Same as FacultyConsumer() and FacultyAdmin()
        /// </summary>
        /// <param name="studentQueue">student queue</param>
        private static void StudentConsumer(Queue<Student> studentQueue)
        {
            lock (SyncLock)
            {
                if (ThreadCount >= MaxNoOfThreads || studentQueue.Count == 0) return;
                ThreadCount++;
                var student = studentQueue.Dequeue();
				TextFile.LogUserCreation(Student.STUDENT_CONSUMER_LOGFILE, student.GetType().Name + " | ", student.Name + " | ", DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff"));
				//Sql.LogUserCreation("UserConsume", student.GetType().Name + " | ", student.Name + " | ", DateTime.Now);
                new Thread(() => Randomize.RunClassMethods(student, Randomize.RandomNumber(1, 4))).Start();
            }
        }

        private static void FacultyConsumer(Queue<Faculty> facultyQueue)
        {
            lock (SyncLock)
            {
                if (ThreadCount >= MaxNoOfThreads || facultyQueue.Count == 0) return;
                ThreadCount++;
                var faculty = facultyQueue.Dequeue();
				TextFile.LogUserCreation(Faculty.FACULTY_CONSUMER_LOGFILE, faculty.GetType().Name + " | ", faculty.Name + " | ", DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff"));
				//Sql.LogUserCreation("UserConsume", faculty.GetType().Name + " | ", faculty.Name + " | ", DateTime.Now);
                new Thread(() => Randomize.RunClassMethods(faculty, Randomize.RandomNumber(1, 4))).Start();
            }
        }

        private static void AdminConsumer(Queue<Admin> adminQueue)
        {
            lock (SyncLock)
            {
                if (ThreadCount >= MaxNoOfThreads || adminQueue.Count == 0) return;
                ThreadCount++;
                var admin = adminQueue.Dequeue();
				TextFile.LogUserCreation(Admin.ADMIN_CONSUMER_LOGFILE, admin.GetType().Name + " | ", admin.Name + " | ", DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff"));
				//Sql.LogUserCreation("UserConsume", admin.GetType().Name + " | ", admin.Name + " | ", DateTime.Now);
                new Thread(() => Randomize.RunClassMethods(admin, Randomize.RandomNumber(1, 4))).Start();
            }
        }
    }
}