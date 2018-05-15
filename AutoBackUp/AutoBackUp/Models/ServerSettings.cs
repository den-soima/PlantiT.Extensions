using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBackUp.Models
{
    public class ServerSettings
    {
        public string Name { get; set; }        
        public BackupItem DailyDMP { get; set; }
        public BackupItem ArchiveBackup { get; set; }
        public BackupItem S7 { get; set; }
        public BackupItem PBServer { get; set; }
        public BackupItem MVA { get; set; }
    }
}
