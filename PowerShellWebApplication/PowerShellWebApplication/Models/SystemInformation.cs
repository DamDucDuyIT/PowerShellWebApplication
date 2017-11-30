using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerShellWebApplication.Models
{
    public class SystemInformation
    {
        public string Computer_Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Serial_Number { get; set; }
        public string CPU { get; set; }
        public string HDD_Capacity { get; set; }
        public string HDD_Space { get; set; }
        public string RAM { get; set; }
        public string Operating_System { get; set; }
        public string User_logged_In { get; set; }
        public string Last_Reboot { get; set; }
    }
}
