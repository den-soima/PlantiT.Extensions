using System;
using System.Collections.Generic;
using System.Timers;

namespace AutoBackUp.Functions
{
    public class ConsoleTimer
    {
        private Timer progressTimer;
        private long elapsedTime;

        public ConsoleTimer(int timerTick)
        {
            progressTimer = new Timer(timerTick);
            progressTimer.Elapsed += ShowTime;
            progressTimer.AutoReset = true;
            progressTimer.Enabled = true;

            elapsedTime = 0;

            Console.Write("\b");
            Console.Write("\b");
        }       

        private void ShowTime(Object source, ElapsedEventArgs e)
        {
            elapsedTime++;
            Console.Write(new String('\b', 8));            
            Console.Write($"{elapsedTime}: hh:mm:ss");
        }

        public void Start()
        {
            progressTimer.Start();
        }

        public void Stop()
        {
            progressTimer.Stop();
        }
    }
}
