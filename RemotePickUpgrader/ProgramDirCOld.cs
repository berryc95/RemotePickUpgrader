using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Output a folder contents to file DirC.txt 
// Requires adaptation to Copy commands
// C.BERRY 18/08/23
// Arguments FromFolder, ToFolder
//
namespace RemotePickUpgrader
{
    class Program
    {
 
        static void Main(string[] args)

        {
            // Output a folder contents to file.
            /* dir C:\Pick > \\gbdvsfm1\TabletAuto$\Software\Pick\VB\Live\Script\Output\OutputDir.txt
                timeout 1 > nul
            */

            //Output initiation message
            Console.WriteLine("**DIR/FOLDER OUTPUT**");
            Console.WriteLine("PARAMETERS=" + args[0]);
            Console.WriteLine("PARAMETERS2=" + args[1]);

            //string[] array1 = Directory.GetFiles(@"C:\Pick", "*.*");
            string[] array1 = Directory.GetFiles(args[0], "*.*");
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Output";

            if (args.Length > 0) 
            {
                path = args[1];
            }

            //create file/folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            TextWriter tw1 = new StreamWriter(path +"\\DirC.txt");
            tw1.WriteLine(System.Environment.MachineName);

            // Display all files.
            foreach (string name in array1)
            {
                // Get object last write time
                DateTime dt = File.GetLastWriteTime(name);
                //Console.WriteLine("File last write time: {0}", dt.ToString());
                tw1.WriteLine(name + " " + dt.ToString());

            }
            tw1.Close();





        }


    }
}
