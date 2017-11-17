using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using PowerShellWebApplication.Models;
using System.Management.Automation;


namespace PowerShellWebApplication.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        public ActionResult Index()
        {
            var processes = new Collection<Process>();

            string text = "get-process";
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                PowerShellInstance.AddScript(text);

                var PSOutput = PowerShellInstance.Invoke();
                foreach (var outputItem in PSOutput)
                {
                    // if null object was dumped to the pipeline during the script then a null
                    // object may be present here. check for null to prevent potential NRE.
                    if (outputItem != null)
                    {
                        processes.Add(new Process
                        {
                            Handles = outputItem.Members["Handles"].Value.ToString(),
                            Id = outputItem.Members["Id"].Value.ToString(),
                            Name = outputItem.Members["Name"].Value.ToString(),
                            NPM = outputItem.Members["NPM"].Value.ToString(),
                            PM = outputItem.Members["PM"].Value.ToString(),
                            SI = outputItem.Members["SI"].Value.ToString(),
                            WS = outputItem.Members["WS"].Value.ToString()
                        });
                    }
                }
            }
            return View(processes);
        }

        // GET: Process/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Process/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Process/Create
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

        // GET: Process/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Process/Edit/5
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

        // GET: Process/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Process/Delete/5
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