using System.Collections.Generic;

namespace web_simulator
{
    class Scheduler
    {
        public static int WaitTime { get; set; }
        public static readonly List<string> OpenWindows = new List<string>
        {
            "window-1", "window-2", "window-3", "window-4", "window-5", "window-6", "window-7"
        };
    }
}
