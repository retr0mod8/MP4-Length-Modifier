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
    public class PublicVariables
    {
        public static string filelocation;
        public static Int32 increment;
        public static Int32 limit;
        public static Int32 seconds;
        public static Int32 InputTime;
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
                    PublicVariables.seconds = (PublicVariables.limit / PublicVariables.increment);
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