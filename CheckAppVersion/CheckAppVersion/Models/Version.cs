using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckAppVersion.Models
{
    public class Version
    {
        
        public int Id { get; set; }
        public string AppName { get; set; }
        public string PlatForm { get; set; }
        public string Ver { get; set; }
    }
}
