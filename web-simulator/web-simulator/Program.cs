using System;
using System.Collections.Generic;
using web_simulator.Users;

namespace web_simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            UserContainer uc = new UserContainer();
            uc.GenerateUsers();

            Scheduler sch = new Scheduler(10);

            //foreach(var v in Scheduler.OpenWindows)
            //    Console.WriteLine(v);
        }
    }
}
