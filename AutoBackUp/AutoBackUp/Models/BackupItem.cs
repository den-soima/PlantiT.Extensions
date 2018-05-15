using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBackUp.Models
{
    public class BackupItem
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
        public bool Archiving { get; set; }
        public bool Backup { get; set; }
    }
}
