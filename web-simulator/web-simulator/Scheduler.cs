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
            //if(OpenWindows.Count == 0)
            //{
            //    lock (OpenWindows)
            //    {

            //    }
            //}

        }

        public bool CheckArrivalTime(User user)
        {


            return true;
        }
        public static int WaitTime { get; set; }
        private static List<string> OpenWindows { get; set; }
    }
}
