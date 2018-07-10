using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBackUp.Models
{
    public class ServerSettings
    {
        public string Name { get; set; }        
        public List<BackupItem> BackupItems { get; set; }
    }
}
