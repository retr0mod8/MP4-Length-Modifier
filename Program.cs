using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MP4_Length_Modifier
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() //Executes this code when the executable is launched
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DriveInfo CDrive = new DriveInfo("C"); //Create new DriveInfo Instance
            if (!PublicVariables.release){ //Writes data to console if program is not release.
            Console.WriteLine("C Drive Free Space: " + Convert.ToString(CDrive.AvailableFreeSpace) + " | Gigabytes: " + Convert.ToString(((CDrive.AvailableFreeSpace / 1024) / 1024) / 1024));}
            if (CDrive.AvailableFreeSpace <= 100000000) //Checks space on C: drive to inform user about potential issues.
            {
                DialogResult dialogResult = MessageBox.Show("Your computer seems to have less that 100MB of free space.\nAlthough this shouldn't affect this program, it's reccomended you free up disk space on the C: Drive.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Application.Run(new MainWindow());
        }
    }
}
