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

        public void Dispatch(User user)
        {
            var dispatchThread = new Thread(() => DispatchNextUser(user));

            dispatchThread.Start();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="user"></param>
        private void DispatchNextUser(User user)
        {
            Random random = new Random();
            lock (OpenWindows)
            {
                if (OpenWindows.Count > 0)
                {
                    var openWindowAtIndex = random.Next(0, OpenWindows.Count);
                    var takeWindow = OpenWindows[openWindowAtIndex];

                    OpenWindows.RemoveAt(openWindowAtIndex);

                    Randomize.RunClassMethods(user, random.Next(0, 4));
                }
                else
                {
                    Console.WriteLine("Delay....");
                }
            }
        }

        public static int WaitTime { get; set; }
        private static List<string> OpenWindows { get; set; }
    }
}
