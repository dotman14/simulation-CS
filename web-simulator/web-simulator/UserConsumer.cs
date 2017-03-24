using System;
using System.Collections.Generic;
using web_simulator.Users;

namespace web_simulator
{
    public class UserConsumer
    {
        static readonly Random Random = new Random();
        const int MIN_NO_OF_METHODS = 0;

		public static void StudentConsumer(Queue<Student> studentQueue)
        {
            Student localStudent;
            lock (studentQueue)
            {
                var stu = studentQueue.Dequeue();
                localStudent = stu;
            }
            Randomize.RunClassMethods(localStudent, Random.Next(0, 4));
        }

		public static void FacultyConsumer(Queue<Faculty> facultyQueue)
        {
            Faculty localFaculty;
            lock (facultyQueue)
            {
                var fac = facultyQueue.Dequeue();
                localFaculty = fac;
            }
            Randomize.RunClassMethods(localFaculty, Random.Next(0, 4));
        }

		public static void AdminConsumer(Queue<Admin> adminQueue)
        {
            Admin localAdmin;
            lock (adminQueue)
            {
                var adm = adminQueue.Dequeue();
                localAdmin = adm;
            }
            Randomize.RunClassMethods(localAdmin, Random.Next(0, 4));
        }
    }
}
