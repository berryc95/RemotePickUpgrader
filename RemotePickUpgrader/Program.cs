using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace RemotePickUpgrader
{
    // RemotePickUpgrader
    // Kill Pick.exe and copy folder contents
    // Requires adaptation to Copy commands
    // C.BERRY 18/08/23
    // Arguments FromFolder, ToFolder

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" *REMOTE UPGRADER* ");
            Console.WriteLine("Job terminating...Copying files.");

            string sourceFolder = args[0];

            string destinationFolder = args[1];
            //string destinationFolder = @"c:\Test";
            Console.WriteLine(args[0]);

            // Kill the process if it's running
            //KillProcess("Pick");
            string jobToKill = args[2];
            KillProcess(jobToKill);

            // Copy folder contents

            CopyFolder(sourceFolder, destinationFolder);

            Console.WriteLine(".....");
            Console.WriteLine("...");
            Console.WriteLine("Upgrade complete.");

            Thread.Sleep(5000); //5 secs
        }

        static void KillProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
                process.WaitForExit();
            }
        }

        static void CopyFolder(string sourceFolder, string destinationFolder)
        {
                        
            DirectoryInfo dir = new DirectoryInfo(sourceFolder); DirectoryInfo[] dirs = dir.GetDirectories();

            
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                //Overwrite true
                string temppath = Path.Combine(destinationFolder, file.Name); file.CopyTo(temppath, true);
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destinationFolder, subdir.Name); CopyFolder(subdir.FullName, temppath);
            }
        }
    }
}


