using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckAppVersion.Models
{
    public class UpdateInfo
    {
        public string CurrentVersion { get; set; }
        public string UpdateUrl { get; set; }
        public bool IsUpdateAvailable { get; set; }
    }
}
