using System;
using System.Runtime.InteropServices;
using System.Timers;

namespace TimeToSleep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the amount of time before going to sleep. \nie: <1.5> for 1 and a half hours");
            string input = Console.ReadLine();
            double time;
            bool flag = false;

            while (!flag)
            {
                if (input != null && Double.TryParse(input, out time))
                {
                    flag = true;
                    double hours = time * 3600000; //hours to ms

                    Console.WriteLine("Understood. Going to sleep in " + input + " hours.");

                    Timer aTimer = new Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    aTimer.Interval = hours;
                    aTimer.Enabled = true;

                }
                else
                {
                    Console.WriteLine("I don't understand. Please try again.");
                }
            }
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Going to sleep now... Good night.");
            SetSuspendState(false, true, true);
        }

        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
    }
}
