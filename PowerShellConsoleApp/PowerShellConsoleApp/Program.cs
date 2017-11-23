﻿using System;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace PowerShellConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = System.IO.File.ReadAllText(@"D:\ps1.ps1");
            string text = "get-service";
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                PowerShellInstance.AddScript(text);

                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();
                foreach (PSObject outputItem in PSOutput)
                {
                    // if null object was dumped to the pipeline during the script then a null
                    // object may be present here. check for null to prevent potential NRE.
                    if (outputItem != null)
                    {

                        Console.Write(outputItem.Members["Name"].Value + "\t");
                        Console.Write(outputItem.Members["DisplayName"].Value + "\t");
                        Console.Write(outputItem.Members["Status"].Value + "\t");
                        Console.Write("\n");
                    }
                }
                if (PowerShellInstance.Streams.Error.Count > 0)
                {
                    Console.Write("Error");
                }
                Console.ReadKey();
            }
        }
    }
}
