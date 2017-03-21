using System.Collections.Generic;

namespace web_simulator
{
    class Scheduler
    {

        public Scheduler(int noOfWindows)
        {
            noOfWindows = (noOfWindows <= 0) ? 10 : noOfWindows;

            OpenWindows = new List<string>();
            for(var i = 0; i < noOfWindows; i++)
                OpenWindows.Add("window-"+ i);
        }
        public static int WaitTime { get; set; }
        public static List<string> OpenWindows { get; private set; }
    }
}
