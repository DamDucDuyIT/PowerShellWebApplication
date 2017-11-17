using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerShellWebApplication.Models
{
    public class Process
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string SI { get; set; }
        public string WS { get; set; }
        public string PM { get; set; }
        public string NPM { get; set; }
        public string Handles { get; set; }
    }
}
