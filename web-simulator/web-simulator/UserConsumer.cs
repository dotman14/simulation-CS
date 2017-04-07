using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;
using AppConfig = System.Configuration.ConfigurationManager;

namespace web_simulator
{
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

        private static void StudentConsumer(Queue<Student> studentQueue)
        {
            lock (SyncLock)
            {
                if(ThreadCount >= MaxNoOfThreads || studentQueue.Count <= 0) return;
                Interlocked.Increment(ref ThreadCount);
                var student = studentQueue.Dequeue();
                //TextFile.LogUserDequeue("UserConsume", student.GetType().Name + " | ", student.Name + " | ", ThreadCount, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
                Sql.LogUserDequeue("UserConsume", student.GetType().Name, student.Name, ThreadCount, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
                new Thread(() => Randomize.RunClassMethods(student, Randomize.RandomNumber(1, 4))).Start();
            }
        }

        private static void FacultyConsumer(Queue<Faculty> facultyQueue)
        {
            lock (SyncLock)
            {
                if(ThreadCount >= MaxNoOfThreads || facultyQueue.Count == 0) return;
                Interlocked.Increment(ref ThreadCount);
                var faculty = facultyQueue.Dequeue();
                //TextFile.LogUserDequeue("UserConsume", faculty.GetType().Name + " | ", faculty.Name + " | ", ThreadCount, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
                Sql.LogUserDequeue("UserConsume", faculty.GetType().Name, faculty.Name, ThreadCount, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
                new Thread(() => Randomize.RunClassMethods(faculty, Randomize.RandomNumber(1, 4))).Start();
            }
        }

        private static void AdminConsumer(Queue<Admin> adminQueue)
        {
            lock (SyncLock)
            {
                if(ThreadCount >= MaxNoOfThreads || adminQueue.Count == 0) return;
                Interlocked.Increment(ref ThreadCount);
                var admin = adminQueue.Dequeue();
                //TextFile.LogUserDequeue("UserConsume", admin.GetType().Name + " | ", admin.Name + " | ", ThreadCount, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
                Sql.LogUserDequeue("UserConsume", admin.GetType().Name, admin.Name, ThreadCount, DateTime.Parse(DateTime.Now.ToString("MM/dd/yy HH:mm:ss.ffffff")));
                new Thread(() => Randomize.RunClassMethods(admin, Randomize.RandomNumber(1, 4))).Start();
            }
        }
    }
}