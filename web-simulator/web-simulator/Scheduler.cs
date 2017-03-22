using System;
using System.Collections.Generic;
using System.Threading;

namespace web_simulator
{
    class Scheduler
    {

        public Scheduler(int noOfWindows)
        {
            noOfWindows = (noOfWindows <= 0) ? 10 : noOfWindows;

            OpenWindows = new List<string>();
            for (var i = 0; i < noOfWindows; i++)
                OpenWindows.Add("window-" + i);
        }


        public static void Dispatch()
        {
            var dispatchThread = new Thread(DispatchNextUser);

            dispatchThread.Start();
        }

        private static void DispatchNextUser()
        {
            while (true)
            {
                if (UserContainer.StudentList.Count == 0)
                    Console.WriteLine("There are no Student to dispatch");

                if (UserContainer.FacultyList.Count == 0)
                    Console.WriteLine("There are no Faculty to dispatch");

                if (UserContainer.AdminList.Count == 0)
                    Console.WriteLine("There are no Admin to dispatch");

                Console.WriteLine("Student now has: "  + UserContainer.StudentList.Count);
                Console.WriteLine("Faculty now has: "  + UserContainer.FacultyList.Count);
                Console.WriteLine("Admin now has: "    + UserContainer.AdminList.Count);
                Console.WriteLine("Total Users now : " + UserContainer.AllUsers.Count);

                foreach(var i in UserContainer.AllUsers)
                    Console.Write("{0} ", i.GetType().Name);
                Thread.Sleep(9000);
            }

        }

        public bool CheckArrivalTime(User user)
        {


            return true;
        }
        public static int WaitTime { get; set; }
        private static List<string> OpenWindows { get; set; }
    }
}
