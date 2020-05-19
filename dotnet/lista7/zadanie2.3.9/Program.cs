using System;
using System.IO;
using System.Timers;
using System.Diagnostics;
using System.ServiceProcess;
using System.Collections.Generic;

namespace zadanie2._3._9
{
    public class ProcessLogs : ServiceBase
    {
        public ProcessLogs()
        {
            ServiceName = "ProcessLogs";
            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            var timer = new Timer() {Interval = 60 * 1000};
            timer.Elapsed += OnTimer;
            timer.Start();
        }

        private void OnTimer(object sender, ElapsedEventArgs args)
        {
            var path = @"C:\logs.txt";
            var processes = Process.GetProcesses();
            var procNames = new List<string>();
            foreach (var proc in processes)
            {
                procNames.Add(proc.ProcessName);
            }

            File.WriteAllLines(path, procNames);
        }
    }

    internal static class Program
    {
        public static void Main(string[] args)
        {
            ServiceBase.Run(new ProcessLogs());
        }
    }
}