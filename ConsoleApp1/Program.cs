using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;

namespace TimeToSleep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the amount of time before going to sleep. \nie: <1.5> for 1 and half hours");
            string input = Console.ReadLine();
            double price;

            if(input != null && Double.TryParse(input, out price))
            {
                Timer aTimer = new Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = input;
                aTimer.Enabled = true;

                SetSuspendState(false, true, true);
            }
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello World!");
        }

        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
    }
}
