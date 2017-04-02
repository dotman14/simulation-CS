using System;
using System.Collections.Generic;
using System.Threading;
using web_simulator.Users;

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
        }

        private static readonly object SyncLock;
        private const int MAX_NO_OF_THREADS = 10;
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
                if (ThreadCount < MAX_NO_OF_THREADS)
                {
                    if (studentQueue.Count != 0)
                    {
                        ThreadCount++;
                        var student = studentQueue.Dequeue();
                        Logger.LogUserCreation(Student.STUDENT_CONSUMER_LOGFILE, student.GetType().Name + " | ", student.Name + " | ", DateTime.Now);
                        new Thread(() => Randomize.RunClassMethods(student, Randomize.RandomNumber(1, 4))).Start();
                    }
                }
            }
        }

        private static void FacultyConsumer(Queue<Faculty> facultyQueue)
        {
            lock (SyncLock)
            {
                if (ThreadCount < MAX_NO_OF_THREADS)
                {
                    if (facultyQueue.Count != 0)
                    {
                        ThreadCount++;
                        var faculty = facultyQueue.Dequeue();
                        Logger.LogUserCreation(Faculty.FACULTY_CONSUMER_LOGFILE, faculty.GetType().Name + " | ", faculty.Name + " | ", DateTime.Now);
                        new Thread(() => Randomize.RunClassMethods(faculty, Randomize.RandomNumber(1, 4))).Start();
                    }
                }
            }
        }

        private static void AdminConsumer(Queue<Admin> adminQueue)
        {
            lock (SyncLock)
            {
                if (ThreadCount < MAX_NO_OF_THREADS)
                {
                    if (adminQueue.Count != 0)
                    {
                        ThreadCount++;
                        var admin = adminQueue.Dequeue();
                        Logger.LogUserCreation(Admin.ADMIN_CONSUMER_LOGFILE, admin.GetType().Name + " | ", admin.Name + " | ", DateTime.Now);
                        new Thread(() => Randomize.RunClassMethods(admin, Randomize.RandomNumber(1, 4))).Start();
                    }
                }
            }
        }
    }
}