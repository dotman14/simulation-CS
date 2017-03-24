using System;
using System.Collections.Generic;
using web_simulator.Users;

namespace web_simulator
{
    public class UserConsumer
    {
        static readonly Random Random = new Random();
        const int MIN_NO_OF_METHODS = 0;

        public static void StudentConsumer(Queue<Student> student)
        {
            Student localStudent;
            lock (student)
            {
                var stu = student.Dequeue();
                localStudent = stu;
            }
            Randomize.RunClassMethods(localStudent, Random.Next(MIN_NO_OF_METHODS, 4));
        }

        public static void FacultyConsumer(Queue<Faculty> faculty)
        {
            Faculty localFaculty;
            lock (faculty)
            {
                var fac = faculty.Dequeue();
                localFaculty = fac;
            }
            Randomize.RunClassMethods(localFaculty, Random.Next(MIN_NO_OF_METHODS, 4));
        }

        public static void AdminConsumer(Queue<Admin> admin)
        {
            Admin localAdmin;
            lock (admin)
            {
                var adm = admin.Dequeue();
                localAdmin = adm;
            }
            Randomize.RunClassMethods(localAdmin, Random.Next(MIN_NO_OF_METHODS, 4));
        }
    }
}
