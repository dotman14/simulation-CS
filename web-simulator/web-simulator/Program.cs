using System;
using System.Collections.Generic;
using System.Reflection;
using web_simulator.Users;

namespace web_simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student();
            var admin = new Admin();
            var faculty = new Faculty();

            UserContainer uc = new UserContainer();
           //uc.GenerateUsers();

            Randomize.RunClassMethods(student, 4);
            Randomize.RunClassMethods(admin, 4);
            Randomize.RunClassMethods(faculty, 4);
        }
    }
}
