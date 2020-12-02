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
        public static uint InputTime; //The time in seconds the user wants the video length to be.
        public static int b1; //byte 1, value is written to hex offset 0x34 when EditData() function is run
        public static int b2; //ditto
        public static int b3; //dito
        public static int b4; //dito
        public static bool EditDataFinished = false;
        public static int StreamPosition;
    }

    public class PublicFunctions
    {
        public struct FrontendFunctions
        {

            public static void getHeaderOffset(){
                using (var stream = new System.IO.FileStream(PublicVariables.filelocation, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    bool loop = true;
                    stream.Position = 0;
                    while (loop){
                        if (stream.ReadByte() == 109){
                            if (stream.ReadByte() == 118){
                                if (stream.ReadByte() == 104){
                                    if (stream.ReadByte() == 100){
                                        loop = false;
                                        PublicVariables.StreamPosition = (Convert.ToInt32(stream.Position)+11);
                                    }    
                                }
                            }    
                        }
                    }
                }
            }
            /*
            public static void getVideoLength()
            {
                using (var stream = new System.IO.FileStream(PublicVariables.filelocation, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    PublicVariables.increment = 0;
                    PublicVariables.limit = 0;
                    stream.Position = PublicVariables.StreamPosition; //this is where the video length header data is.
                    for (int i = 0; i != 4; i++)// read the increment 32bit byte
                    {
                        PublicVariables.increment += stream.ReadByte();
                        stream.Position--;
                        Console.WriteLine(stream.ReadByte());
                    }

                    PublicVariables.b1 = 0;
                    PublicVariables.b2 = 0;
                    PublicVariables.b3 = 0;
                    PublicVariables.b4 = 0;
                    PublicVariables.b1 = stream.ReadByte();
                    PublicVariables.b2 = stream.ReadByte();
                    PublicVariables.b3 = stream.ReadByte();
                    PublicVariables.b4 = stream.ReadByte();
                    PublicVariables.b1 *= 8;
                    PublicVariables.b2 *= 4;
                    PublicVariables.b3 *= 2;
                    PublicVariables.b4 *= 1;
                    PublicVariables.limit = (PublicVariables.b1 + PublicVariables.b2 + PublicVariables.b3 + PublicVariables.b4);
                    Console.WriteLine(PublicVariables.increment);
                    Console.WriteLine(PublicVariables.limit);

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
            */

            public static bool CheckAndCalculateInput(string str1, string str2, string str3)
            {
                foreach (char c in str1)
                {
                    if (c < '0' || c > '9')
                        return false; //input contains things over than numbers. bad! >:(
                }
                if (string.IsNullOrEmpty(str1))
                {
                    return false; //input contains nothing. bad! >:(
                }
                foreach (char c in str2)
                {
                    if (c < '0' || c > '9')
                        return false; //input contains things over than numbers. bad! >:(
                }
                if (string.IsNullOrEmpty(str2))
                {
                    return false; //input contains nothing. bad! >:(
                }
                foreach (char c in str3)
                {
                    if (c < '0' || c > '9')
                        return false; //input contains things over than numbers. bad! >:(
                }
                if (string.IsNullOrEmpty(str3))
                {
                    return false; //input contains nothing. bad! >:(
                }

                return true;
            }

            public static void EditData()
            {
                using (var stream = new System.IO.FileStream(PublicVariables.filelocation, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
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
                    for (uint i = PublicVariables.InputTime; i != 0; i--){
                        PublicVariables.b4 ++;
                        
                        if (PublicVariables.b4 == 256){ //if byte 4 is over 255, make it go back to 255 and carry over the remainder to byte 3
                            PublicVariables.b4 = 0;
                            PublicVariables.b3 ++;
                        }

                        if (PublicVariables.b3 == 256){ //ditto
                            PublicVariables.b3 = 0;
                            PublicVariables.b2 ++;
                        }

                        if (PublicVariables.b2 == 256){ //ditto
                            PublicVariables.b2 = 0;
                            PublicVariables.b1 ++;
                        }

                        if (PublicVariables.b1 == 256){
                            PublicVariables.b1 --;
                        }
                    }
                    Console.WriteLine(PublicVariables.b1);
                    Console.WriteLine(PublicVariables.b2);
                    Console.WriteLine(PublicVariables.b3);
                    Console.WriteLine(PublicVariables.b4);
                    Console.WriteLine(PublicVariables.InputTime);
                    stream.WriteByte(Convert.ToByte(PublicVariables.b1));
                    stream.WriteByte(Convert.ToByte(PublicVariables.b2));
                    stream.WriteByte(Convert.ToByte(PublicVariables.b3));
                    stream.WriteByte(Convert.ToByte(PublicVariables.b4));
                    PublicVariables.EditDataFinished = true;

                }
            }
        }
    }
}