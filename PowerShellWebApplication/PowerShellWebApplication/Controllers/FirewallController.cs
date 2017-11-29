using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Management.Automation;
using PowerShellWebApplication.Models;
using System.Collections.ObjectModel;

namespace PowerShellWebApplication.Controllers
{
    public class FirewallController : Controller
    {
        public ActionResult Index()
        {

            var firewalls = new Collection<Firewall>();

            string text = "netsh advfirewall show allprofiles";
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                PowerShellInstance.AddScript(text);

                var PSOutput = PowerShellInstance.Invoke();

                firewalls.Add(new Firewall
                {
                    Name = PSOutput[1].BaseObject.ToString(),
                    State = PSOutput[3].BaseObject.ToString(),
                });
                firewalls.Add(new Firewall
                {
                    Name = PSOutput[18].BaseObject.ToString(),
                    State = PSOutput[20].BaseObject.ToString(),
                });
                firewalls.Add(new Firewall
                {
                    Name = PSOutput[35].BaseObject.ToString(),
                    State = PSOutput[37].BaseObject.ToString(),
                });
                return View(firewalls);
            }
        }

        public ActionResult TurnOn()
        {
            string text = "netsh advfirewall set allprofiles state on";
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                PowerShellInstance.AddScript(text);
                var PSOutput = PowerShellInstance.Invoke("Set-ExecutionPolicy Unrestricted");
            }
            return RedirectToAction("Index");
        }

        public ActionResult TurnOff()
        {
            string text = "netsh advfirewall set allprofiles state off";
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                PowerShellInstance.AddScript(text);
                var PSOutput = PowerShellInstance.Invoke("Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy Unrestricted");
            }
            return RedirectToAction("Index");
        }
    }
}