using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace MP4_Length_Modifier
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult dialogResult = MessageBox.Show("Warning!\nThis Program Makes Changes to Files!\nBy pressing yes, you take full responsability for changes made to files", "Warning!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Run(new Form1());
            }
            else if (dialogResult == DialogResult.No)
            {
                Application.Exit();
            }
            
        }
    }

    public class PublicVariables
    {
        public static UInt32 StreamPosition = 0; //Stores beggining offset of the position of the increment values in the MP4 File
        public static string FileLocation;
        public static string FileDirectory;
        public static string FileName;
        public static UInt32 InputSeconds;
        public static UInt32 b1 = 0;
        public static UInt32 b2 = 0;
        public static UInt32 b3 = 0;
        public static UInt32 b4 = 0;
    }

    static public class PublicFunctions
    {
        public static bool FileVerification(string a)
        {
            using (var stream = new System.IO.FileStream(a, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                bool loop = true;
                stream.Position = 0;
                while (loop)
                {
                    if (stream.ReadByte() == 108)
                    {
                        //Console.WriteLine("Found L");
                        if (stream.ReadByte() == 109)
                        {
                            //Console.WriteLine("Found M");
                            if (stream.ReadByte() == 118)
                            {
                                //Console.WriteLine("Found V");
                                if (stream.ReadByte() == 104)
                                {
                                    //Console.WriteLine("Found H");
                                    if (stream.ReadByte() == 100)
                                    {
                                        //Console.WriteLine("Found D");
                                        loop = false;
                                        PublicVariables.StreamPosition = (Convert.ToUInt32(stream.Position) + 11);
                                        return true;
                                    }
                                    else
                                    {
                                        stream.Position -= 4;
                                    }
                                }
                                else
                                {
                                    stream.Position -= 3;
                                }
                            }
                            else
                            {
                                stream.Position -= 2;
                            }
                        }

                    }
                    else
                    {
                        stream.Position -= 1;
                    }

                    if (stream.ReadByte() == -1)
                    {
                        return false;
                    }
                }
                return false;
            }
        } //Checks the selected MP4 file to see if it can be edited. It also finds the offset for the increment counter.
        public static void SaveInputSeconds(decimal a, decimal b, decimal c) //Converts and saves the input values to the variable 'InputSeconds'
        {
            //A = Hours
            //B = Minutes
            //C = Seconds
            PublicVariables.InputSeconds = Convert.ToUInt32(c) + (Convert.ToUInt32(b) * 60) + (Convert.ToUInt32(a) * 3600);
            Console.WriteLine(PublicVariables.InputSeconds);
        }

        public static void WriteSeconds(bool a)
        {

            if (a)
            {
                Console.WriteLine("Beginning backup of:", PublicVariables.FileLocation);
                try
                {
                    File.Copy(PublicVariables.FileLocation, PublicVariables.FileDirectory + PublicVariables.FileName.Substring(0, PublicVariables.FileName.Length - 4) + "_BACKUP_" + DateTime.Now.ToString("dd_MM_yyy") + ".mp4", false);
                }
                catch (Exception iox)
                {
                    DialogResult dialogResult = MessageBox.Show("BACKUP FAILED!\n" + iox.Message + "\nDo you want to continue without a backup?", "Error!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("The Backup has failed and you've chosen to not continue. The program will now exit.");
                        Application.Exit();
                    }
                }
            }
            using (var stream = new System.IO.FileStream(PublicVariables.FileLocation, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                stream.Position = PublicVariables.StreamPosition; //this is where the video length header data is.
                for (int i = 0; i != 3; i++)// read the increment 32bit byte
                {
                    stream.WriteByte(0);
                }
                stream.WriteByte(1);
                //Video increment written

                    PublicVariables.b1 = 0;
                    PublicVariables.b2 = 0;
                    PublicVariables.b3 = 0;
                    PublicVariables.b4 = 0;

                //Insert Limit Writing Code Here
                for (uint i = PublicVariables.InputSeconds; i != 0; i--)
                {
                    PublicVariables.b4++;

                    if (PublicVariables.b4 == 256)
                    { //if byte 4 is over 255, make it go back to 255 and carry over the remainder to byte 3
                        PublicVariables.b4 = 0;
                        PublicVariables.b3++;
                    }

                    if (PublicVariables.b3 == 256)
                    { //ditto
                        PublicVariables.b3 = 0;
                        PublicVariables.b2++;
                    }

                    if (PublicVariables.b2 == 256)
                    { //ditto
                        PublicVariables.b2 = 0;
                        PublicVariables.b1++;
                    }

                    if (PublicVariables.b1 == 256)
                    {
                        PublicVariables.b1--;
                    }
                }

                if (PublicVariables.b1 > 255)
                {
                    PublicVariables.b1 = 255;
                }
                Console.WriteLine(PublicVariables.b1);
                Console.WriteLine(PublicVariables.b2);
                Console.WriteLine(PublicVariables.b3);
                Console.WriteLine(PublicVariables.b4);
                stream.WriteByte(Convert.ToByte(PublicVariables.b1));
                stream.WriteByte(Convert.ToByte(PublicVariables.b2));
                stream.WriteByte(Convert.ToByte(PublicVariables.b3));
                stream.WriteByte(Convert.ToByte(PublicVariables.b4));
            }
        }
    }
}
