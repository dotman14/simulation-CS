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
                    StudentConsumer(UserContainer.StudentQueue);
                }
            }).Start();

            new Thread(() =>
            {
                while (true)
                {
                    FacultyConsumer(UserContainer.FacultyQueue);
                }
            }).Start();

            new Thread(() =>
            {
                while (true)
                {
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
                if(ThreadCount >= MaxNoOfThreads ||
                   studentQueue.Count <= 0)
                    return;
                Interlocked.Increment(ref ThreadCount);
                var student = studentQueue.Dequeue();
                Sql.LogUserCreation("UserConsume", student.GetType().Name, student.Name, ThreadCount, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
                new Thread(() => Randomize.RunClassMethods(student, Randomize.RandomNumber(1, 4))).Start();
            }
        }

        private static void FacultyConsumer(Queue<Faculty> facultyQueue)
        {
            lock (SyncLock)
            {
                if(ThreadCount >= MaxNoOfThreads ||
                   facultyQueue.Count == 0)
                    return;
                Interlocked.Increment(ref ThreadCount);
                var faculty = facultyQueue.Dequeue();
                Sql.LogUserCreation("UserConsume", faculty.GetType().Name, faculty.Name, ThreadCount, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
                new Thread(() => Randomize.RunClassMethods(faculty, Randomize.RandomNumber(1, 4))).Start();
            }
        }

        private static void AdminConsumer(Queue<Admin> adminQueue)
        {
            lock (SyncLock)
            {
                if(ThreadCount >= MaxNoOfThreads ||
                   adminQueue.Count == 0)
                    return;
                Interlocked.Increment(ref ThreadCount);
                var admin = adminQueue.Dequeue();
                Sql.LogUserCreation("UserConsume", admin.GetType().Name, admin.Name, ThreadCount, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
                new Thread(() => Randomize.RunClassMethods(admin, Randomize.RandomNumber(1, 4))).Start();
            }
        }
    }
}