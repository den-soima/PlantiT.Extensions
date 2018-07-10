using System;
using System.Threading;
using System.IO;
using System.IO.Compression;
using AutoBackUp.Models;
using AutoBackUp.Application;

namespace AutoBackUp.Functions
{
    public static class BackupFunction
    {     
        public static void ExecuteBackup(BackupItem backupItem)
        {          

            if (!backupItem.Backup)
            {
                LogHandler.WriteLog("BackUp", "disabled", 3);
                return;
            }
            else
            {
                LogHandler.WriteLog("BackUp", "enabled", 3);
            }

            if (!File.Exists(backupItem.SourcePath) && !Directory.Exists(backupItem.SourcePath))
            {
                LogHandler.WriteLog("Source path", backupItem.SourcePath + " - Directory(File) not found", 3);
                return;
            }
            else
            {
                LogHandler.WriteLog("Source path", backupItem.SourcePath, 3);
            }

            if (!Directory.Exists(Path.GetDirectoryName(backupItem.TargetPath)))
            {
                LogHandler.WriteLog("Target path", Path.GetDirectoryName(backupItem.SourcePath) + " - Directory not found", 3);
                return;
            }
            else
            {
                LogHandler.WriteLog("Target path", Path.GetDirectoryName(backupItem.SourcePath), 3);
            }

            if (backupItem.Archiving)
            {
                LogHandler.WriteLog("Archiving", "Enabled", 3);
                ZipFile.CreateFromDirectory(backupItem.SourcePath, HandleFileName(backupItem.TargetPath));
            }
            else
            {
                LogHandler.WriteLog("Archiving", "Disabled", 3);
                File.Copy(backupItem.SourcePath, HandleFileName(backupItem.TargetPath),true);
            }
        }

        private static string HandleFileName(string fileName)
        {
            DateTime dateTime = DateTime.Now;
            string fileExtension = Path.GetExtension(fileName);
            string directoryPath = Path.GetDirectoryName(fileName) + "\\";
            string fullFileName = Path.GetFileNameWithoutExtension(fileName) + "_" + dateTime.Year.ToString()
                                                              + PartDateToString(dateTime.Month)
                                                              + PartDateToString(dateTime.Day) + "_"
                                                              + PartDateToString(dateTime.Hour)
                                                              + PartDateToString(dateTime.Minute)
                                                              + PartDateToString(dateTime.Second);
            return directoryPath  + fullFileName + fileExtension;
        }

        private static string PartDateToString(int value)
        {
            return value < 10 ? "0" + value.ToString() : value.ToString();
        }

    }
}
