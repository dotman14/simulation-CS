using System;
using web_simulator.Users;

namespace web_simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            var student = new Student();
            var admin = new Admin();
            var faculty = new Faculty();

            UserContainer uc = new UserContainer();
            //uc.GenerateUsers();

            Randomize.RunClassMethods(student, random.Next(0, 15));
            Randomize.RunClassMethods(faculty, random.Next(0, 10));
            Randomize.RunClassMethods(admin, random.Next(0, 6));

            //Scheduler sch = new Scheduler();
            //foreach(var v in Scheduler.OpenWindows)
            //    Console.WriteLine(v);


        }
    }
}
