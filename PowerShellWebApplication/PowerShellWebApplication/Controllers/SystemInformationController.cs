using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerShellWebApplication.Models;
using System.Management.Automation;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;

namespace PowerShellWebApplication.Controllers
{
    public class SystemInformationController : Controller
    {
        private IHostingEnvironment host;

        public SystemInformationController(IHostingEnvironment host)
        {
            this.host = host;
        }
        // GET: SystemInformation
        public ActionResult Index()
        {
            var uploadFolderPath = Path.Combine(host.WebRootPath, "powershellscript/getSystemInformation.ps1");
            //string text = System.IO.File.ReadAllText(uploadFolderPath);
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                Command myCommand = new Command(uploadFolderPath);
                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                PowerShellInstance.Commands.AddCommand(myCommand);

                var PSOutput = PowerShellInstance.Invoke();
                var systemInformation = new SystemInformation
                {
                    Computer_Name = PSOutput[0].BaseObject.ToString(),
                    Manufacturer = PSOutput[1].BaseObject.ToString(),
                    Model = PSOutput[2].BaseObject.ToString(),
                    Serial_Number = PSOutput[3].BaseObject.ToString(),
                    CPU = PSOutput[4].BaseObject.ToString(),
                    HDD_Capacity = PSOutput[5].BaseObject.ToString(),
                    HDD_Space = PSOutput[6].BaseObject.ToString(),
                    RAM = PSOutput[7].BaseObject.ToString(),
                    Operating_System = PSOutput[8].BaseObject.ToString(),
                    User_logged_In = PSOutput[9].BaseObject.ToString(),
                    Last_Reboot = PSOutput[10].BaseObject.ToString()
                };


                //    Runspace runspace = RunspaceFactory.CreateRunspace();
                //runspace.Open();

                //Pipeline pipeline = runspace.CreatePipeline();
                //Command myCommand = new Command(uploadFolderPath);
                //pipeline.Commands.Add(myCommand);
                //Collection<PSObject> results = pipeline.Invoke();

                return View(systemInformation);
            }
        }


        // GET: SystemInformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemInformation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemInformation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SystemInformation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemInformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemInformation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}