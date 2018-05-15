using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AutoBackUp.Application
{
    public static class LogHandler
    {
        private static string logFilePath;       

        public static void WriteLog(string methodName, string logText, int logRank = 0)
        {
            if (!File.Exists(logFilePath))
            {
                string header = "           AutoBackUp LOG: " + "Created - " + DateTime.Now.ToString() + " (DSO - ProLeiT)" + Environment.NewLine;
                File.WriteAllText(logFilePath, header);
            }

            string body = new String(' ', 5*logRank) + (logRank==0? DateTime.Now.ToString():"") + " - " + methodName + " : " + logText + Environment.NewLine;
            File.AppendAllText(logFilePath, body);
        }            

        private static string GetFileName()
        {
            return "LOG_AutoBackUp_" + DateTime.Now.Year.ToString() + "_" + (DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) + ".txt";
        }

        public static void ConfigureLog(string _logFilePath)
        {
            logFilePath = (Directory.Exists(_logFilePath) ? _logFilePath : Directory.GetCurrentDirectory()) + @"\" + GetFileName();
        }
    }
}
