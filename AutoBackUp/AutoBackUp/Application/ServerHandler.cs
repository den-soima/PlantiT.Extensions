using System;
using AutoBackUp.Models;
using AutoBackUp.Functions;

namespace AutoBackUp.Application
{
    public class ServerHandler
    {
        private ServerSettings serverSettings;        

        public ServerHandler(ServerSettings _serverSettings)
        {
            serverSettings = _serverSettings;

            LogHandler.WriteLog(serverSettings.Name, "backuping", 1);

            try
            {
                foreach (BackupItem item in serverSettings.BackupItems)
                {

                    Console.Write((item.Name + new String(' ', 20)).Substring(0, 20) + "..");
                    LogHandler.WriteLog(item.Name, "executing", 2);   

                    BackupFunction.ExecuteBackup(item);

                    Console.Write(new String('\b', 3));
               
                    Console.WriteLine(" - OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                LogHandler.WriteLog("Backuping error", ex.ToString());
            }
        }
    }
}
