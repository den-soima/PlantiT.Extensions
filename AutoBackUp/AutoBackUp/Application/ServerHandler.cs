using System;
using System.Collections.Generic;
using System.Text;
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
                CreateBackup(serverSettings.DailyDMP, "Daily dump");
                CreateBackup(serverSettings.ArchiveBackup, "Archive backup");
                CreateBackup(serverSettings.S7, "S7");
                CreateBackup(serverSettings.PBServer, "PBServer");
                CreateBackup(serverSettings.MVA, "MVA");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                LogHandler.WriteLog("Backuping error", ex.ToString());
            }

        }

        private void CreateBackup(BackupItem backupItem, string name)
        {
            Console.Write((name + new String(' ', 20)).Substring(0, 20) + "..");
            LogHandler.WriteLog(name, "executing", 2);
            BackupFunction.ExecuteBackup(backupItem);
            Console.Write("\b");
            Console.Write("\b");
            Console.WriteLine("OK");
        }
    }
}
