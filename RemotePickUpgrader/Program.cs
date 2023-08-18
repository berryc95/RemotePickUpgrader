using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace RemotePickUpgrader
{
    // Kill Pick.exe and copy folder contents
    // Requires adaptation to Copy commands
    // C.BERRY 18/08/23
    // Arguments FromFolder, ToFolder

    class Program
    {
        static void Main(string[] args)
        {
            // Kill the process pick.exe if it's running KillProcess("pick.exe");

            // Copy folder contents
            string sourceFolder = @"x:\folder";
            //string destinationFolder = @"c:\pick";
            string destinationFolder = @"c:\pick";

            // CopyFolder(sourceFolder, destinationFolder);

            Console.WriteLine("Upgrade complete.");

            Thread.Sleep(3000); //3 secs
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
                string temppath = Path.Combine(destinationFolder, file.Name); file.CopyTo(temppath, false);
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destinationFolder, subdir.Name); CopyFolder(subdir.FullName, temppath);
            }
        }
    }
}


