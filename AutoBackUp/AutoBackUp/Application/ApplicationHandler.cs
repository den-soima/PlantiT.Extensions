using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using AutoBackUp.Models;

namespace AutoBackUp.Application
{
    public class ApplicationHandler
    {
        private ApplicationSettings appSettings;
        private List<ServerSettings> listServerSettings;
        Stopwatch proccessMonitor = new Stopwatch();

        public ApplicationHandler(ApplicationSettings _appSettings, List<ServerSettings> _listServerSettings)
        {
            appSettings = _appSettings;
            listServerSettings = _listServerSettings;
       
            LogHandler.ConfigureLog(appSettings.Log);
            //ReportHandler reportHandler = new ReportHandler();
           
            LogHandler.WriteLog("Autobackup",  "started by " + Environment.UserName, 0);
            
            proccessMonitor.Start();

            foreach (ServerSettings server in listServerSettings)
            {
                ServerHandler serverHandler = new ServerHandler(server);
            }

            proccessMonitor.Stop();

            TimeSpan elapsedTime = proccessMonitor.Elapsed;            
            
            LogHandler.WriteLog("Autobackup", "finished in " + $"{elapsedTime:hh\\:mm\\:ss\\.ff}", 0);

            Console.WriteLine("Total passed time   " + $"{elapsedTime:hh\\:mm\\:ss\\.ff}");
        }   
    }
}
