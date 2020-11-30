using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;



namespace VideoLengthChanger
{

    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
    public class PublicVariables //Variables to be used across the program
    {
        public static string filelocation; //string on the selected file's location and file name e.g 'C:\Folder\video.mp4'
        public static Int32 increment; //Represents the chosen video's increment value (aka the value of the 4 bytes starting at 0x34)
        public static Int32 limit; //Ditto but for the increment limit (hex offset 0x38)
        public static Int32 seconds = -1; //Limit divided by the Incrememnt. Set to -1 for error checking.
        public static Int32 InputTime; //The time in seconds the user wants the video length to be.
    }

    public class PublicFunctions
    {
        public struct FrontendFunctions
        {
            public static void getVideoLength()
            {
                using (var stream = new System.IO.FileStream(PublicVariables.filelocation, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    PublicVariables.increment = 0;
                    PublicVariables.limit = 0;
                    stream.Position = 52; //this is where the video length header data is.
                    for (int i = 0; i != 4; i++)// read the increment 32bit byte
                    {
                        PublicVariables.increment += stream.ReadByte();
                    }
                    for (int i = 0; i != 4; i++)// read the increment limit 32bit byte
                    {
                        PublicVariables.limit += stream.ReadByte();
                    }
                    try
                    {
                        PublicVariables.seconds = (PublicVariables.limit / PublicVariables.increment);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("1 divided by 0?! NOT POSSIBLE *explosion*");
                    }
                }
            }

            public static bool CheckAndCalculateInput(string str)
            {
                foreach (char c in str)
                {
                    if (c < '0' || c > '9')
                        return false; //input contains things over than numbers. bad! >:(
                }
                if (string.IsNullOrEmpty(str))
                {
                    return false; //input contains nothing. bad! >:(
                }
                Int32 x = Int32.Parse(str); //convert input string to local int
                PublicVariables.InputTime = x; // convert local int to hex
                return true; //input contains numbers. good :)
            }

            public static void EditData()
            {
                using (var stream = new System.IO.FileStream(PublicVariables.filelocation, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    PublicVariables.increment = 0;
                    PublicVariables.limit = 0;
                    stream.Position = 52; //this is where the video length header data is.
                    for (int i = 0; i != 3; i++)// read the increment 32bit byte
                    {
                        stream.WriteByte(0);
                    }
                    stream.WriteByte(1);
                    //Video increment written


                    //Insert Limit Writing Code Here

                }
            }
        }
    }
}