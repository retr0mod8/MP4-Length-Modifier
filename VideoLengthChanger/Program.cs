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
        public static string inputsecondsinhex;
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
                PublicVariables.inputsecondsinhex = x.ToString("X"); // convert local int to hex
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

                    string[] basedata =  { "0", "0", "0", "0" }; //base data to be written to the data maximum
                    int baselength = 4;
                    int hexlength = PublicVariables.inputsecondsinhex.Length;
                    int hexvariableoffset = 0;
                    string hexdata = PublicVariables.inputsecondsinhex;

                    for (baselength -= hexlength; baselength != 4; baselength++)
                    {
                        basedata[baselength] = hexdata[hexvariableoffset].ToString();
                        hexvariableoffset ++;
                    }

                    for (int i = 0; i != 4; i++)// write the increment 32bit byte
                    {
                        Console.WriteLine("Base Data:");
                        Console.WriteLine(basedata);
                        stream.WriteByte((PublicFunctions.FrontendFunctions.HexTranslation(basedata[i])));
                        Console.WriteLine("Hex:");
                        Console.WriteLine(basedata[i]);
                        Console.WriteLine("Decimal:");
                        Console.WriteLine((PublicFunctions.FrontendFunctions.HexTranslation(basedata[i])));
                    }
                }
            }

            public static Byte HexTranslation(string a)
            {
                switch (a) {
                    case "00":
                        return 0;
                    case "01":
                        return 1;
                    case "02":
                        return 2;
                    case "03":
                        return 3;
                    case "04":
                        return 4;
                    case "05":
                        return 5;
                    case "06":
                        return 6;
                    case "07":
                        return 7;
                    case "08":
                        return 8;
                    case "09":
                        return 9;
                    case "0A":
                        return 10;
                    case "0B":
                        return 11;
                    case "0C":
                        return 12;
                    case "0D":
                        return 13;
                    case "0E":
                        return 14;
                    case "0F":
                        return 15;
                    case "10":
                        return 16;
                    case "11":
                        return 17;
                    case "12":
                        return 18;
                    case "13":
                        return 19;
                    case "14":
                        return 20;
                    case "15":
                        return 21;
                    case "16":
                        return 22;
                    case "17":
                        return 23;
                    case "18":
                        return 24;
                    case "19":
                        return 25;
                    case "1A":
                        return 26;
                    case "1B":
                        return 27;
                    case "1C":
                        return 28;
                    case "1D":
                        return 29;
                    case "1E":
                        return 30;
                    case "1F":
                        return 31;
                    case "20":
                        return 32;
                    case "21":
                        return 33;
                    case "22":
                        return 34;
                    case "23":
                        return 35;
                    case "24":
                        return 36;
                    case "25":
                        return 37;
                    case "26":
                        return 38;
                    case "27":
                        return 39;
                    case "28":
                        return 40;
                    case "29":
                        return 41;
                    case "2A":
                        return 42;
                    case "2B":
                        return 43;
                    case "2C":
                        return 44;
                    case "2D":
                        return 45;
                    case "2E":
                        return 46;
                    case "2F":
                        return 47;
                    case "30":
                        return 48;
                    case "31":
                        return 49;
                    case "32":
                        return 50;
                    case "33":
                        return 51;
                    case "34":
                        return 52;
                    case "35":
                        return 53;
                    case "36":
                        return 54;
                    case "37":
                        return 55;
                    case "38":
                        return 56;
                    case "39":
                        return 57;
                    case "3A":
                        return 58;
                    case "3B":
                        return 59;
                    case "3C":
                        return 60;
                    case "3D":
                        return 61;
                    case "3E":
                        return 62;
                    case "3F":
                        return 63;
                    case "40":
                        return 64;
                    case "41":
                        return 65;
                    case "42":
                        return 66;
                    case "43":
                        return 67;
                    case "44":
                        return 68;
                    case "45":
                        return 69;
                    case "46":
                        return 70;
                    case "47":
                        return 71;
                    case "48":
                        return 8;
                    case "49":
                        return 9;
                    case "4A":
                        return 10;
                    case "4B":
                        return 11;
                    case "4C":
                        return 12;
                    case "4D":
                        return 13;
                    case "4E":
                        return 14;
                    case "4F":
                        return 15;
                    case "50":
                        return 0;
                    case "51":
                        return 1;
                    case "52":
                        return 2;
                    case "53":
                        return 3;
                    case "54":
                        return 4;
                    case "55":
                        return 5;
                    case "56":
                        return 6;
                    case "57":
                        return 7;
                    case "58":
                        return 8;
                    case "59":
                        return 9;
                    case "5A":
                        return 10;
                    case "5B":
                        return 11;
                    case "5C":
                        return 12;
                    case "5D":
                        return 13;
                    case "5E":
                        return 14;
                    case "5F":
                        return 15;


                }
                return 0;
            }

        }
    }
}