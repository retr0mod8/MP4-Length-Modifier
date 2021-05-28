using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MP4_Length_Modifier
{
    public class PublicFunctions
    {
        public static void CleanupVariables() //Tares the variables so that all variables are reset to their base values. better safe than sorry!
        {
            Console.WriteLine("CleanupVariables got called!");
            PublicVariables.status = 0;
            PublicVariables.InputVideoLength = 0;
            PublicVariables.OutputFileFullPath = "";
        }

        public static bool VerifyInputFile() //returns true if file is good / returns false if the file is not good
        {
            Console.WriteLine("VerifyInputFile Got Called!");
            UInt32 counter = 0;
            try { 
            using (var stream = new System.IO.FileStream(PublicVariables.FileFullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                bool loop = true;
                stream.Position = 0; //Better safe than sorry
                while (loop)
                {
                        Console.WriteLine("Loop "+counter);
                        counter++;
                    if (stream.ReadByte() == -1) //Checks to see if the stream has reached the end. This is used to prevent getting stuck in an infinite loop
                    {
                        Console.WriteLine("Reached end of file!");
                        stream.Close();
                        loop = false;
                        return false;
                    }
                    else
                    {
                        stream.Position -= 1;
                    }


                    if (stream.ReadByte() == 109) //This scans the file for the 'MOOV   LMVHD' text. / M = 109
                    {
                        if (stream.ReadByte() == 111) // O = 111
                        {
                            if (stream.ReadByte() == 111) // O = 111
                            {
                                if (stream.ReadByte() == 118) // V = 118
                                {
                                    if (stream.ReadByte() == 0) // *nothing* = 0
                                    {
                                        if (stream.ReadByte() == 0) // *nothing* = 0
                                        {
                                            if (stream.ReadByte() == 0) // *nothing* = 0
                                            {
                                                if (stream.ReadByte() == 108) // L = 108
                                                {
                                                    if (stream.ReadByte() == 109) // M = 109
                                                    {
                                                        if (stream.ReadByte() == 118) // V = 118
                                                        {
                                                            if (stream.ReadByte() == 104) // H = 104
                                                            {
                                                                if (stream.ReadByte() == 100) // D = 100
                                                                {
                                                                    PublicVariables.IncrementPosition = (Convert.ToUInt32(stream.Position) + 12);
                                                                        Console.WriteLine("Increment at " + Convert.ToString(stream.Position));
                                                                    stream.Close();
                                                                    loop = false;
                                                                    return true;
                                                                }
                                                                else
                                                                {
                                                                    stream.Position -= 1;
                                                                }// D
                                                            }
                                                            else
                                                            {
                                                                stream.Position -= 1;
                                                            }// H
                                                        }
                                                        else
                                                        {
                                                            stream.Position -= 1;
                                                        }// V
                                                    }
                                                    else
                                                    {
                                                        stream.Position -= 1;
                                                    }// M
                                                }
                                                else
                                                {
                                                    stream.Position -= 1;
                                                }// L
                                            }
                                            else
                                            {
                                                stream.Position -= 1;
                                            }// 0
                                        }
                                        else
                                        {
                                            stream.Position -= 1;
                                        }// 0
                                    }
                                    else
                                    {
                                        stream.Position -= 1;
                                    }// 0

                                }
                                else
                                {
                                    stream.Position -= 1;
                                }//v

                            }
                            else
                            {
                                stream.Position -= 1;
                            }//o
                        }
                        else
                        {
                            stream.Position -= 1;
                        }// o
                    }// M
                }
                return false;
            }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ReadInputFileIncrement() // reads the increment and limit data. if this fails, it returns false
        {
            Console.WriteLine("ReadInputFileIncrement Got Called!");
            try
            {
                using (var stream = new System.IO.FileStream(PublicVariables.FileFullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    stream.Position = PublicVariables.IncrementPosition;
                    Console.WriteLine("Increment " + Convert.ToString(PublicVariables.IncrementPosition));
                    string IncrementHex = "";
                    string LimitHex = "";
                    for (int i =0; i < 4; i++)
                    {
                        IncrementHex += stream.ReadByte().ToString("X2");
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        LimitHex += stream.ReadByte().ToString("X2");
                    }
                    Console.WriteLine(IncrementHex);
                    Console.WriteLine(LimitHex);
                    PublicVariables.InputVideoLength = (Convert.ToUInt32(LimitHex, 16) / Convert.ToUInt32(IncrementHex, 16));
                    Console.WriteLine(PublicVariables.InputVideoLength);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool WriteInputSeconds(UInt32 Hours, UInt32 Minutes, UInt32 Seconds) //Writes input seconds to video file / returns false if it encounters error.
        {
            if (!PublicFunctions.MakeFileOutput())
            {
                return false; //Returns if the output file copy fails
            }
            Console.WriteLine(Hours);
            Console.WriteLine(Minutes);
            Console.WriteLine(Seconds);
            UInt32 InputSeconds = 0;
            string InputSecondsHex = "";
            try
            {
                InputSeconds += (Hours * 3600) + (Minutes * 60) + Seconds; //Adds the input hours, minutes, and seconds to the InputSeconds variable. it also converts hours and minutes to seconds
                InputSecondsHex = InputSeconds.ToString("X"); //Converts InputSeconds to the hex version
                Console.WriteLine("Fixing hex values to proper formatting");
                InputSecondsHex = "00000000".Substring(0, 8 - InputSecondsHex.Length) + InputSecondsHex; //This is done so hex values which do not fill up the 8 spaces are fixed to do so. (E2 would convert to 000000E2)
                Console.WriteLine(InputSecondsHex);
                //The code beyond this point actually writes the data

                using (var stream = new System.IO.FileStream(PublicVariables.OutputFileFullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    Console.WriteLine("Now writing data!");
                    stream.Position = PublicVariables.IncrementPosition; //Gets the position of the video increment and video limit from earlier.
                    stream.WriteByte(0); //This writes the increment
                    stream.WriteByte(0);
                    stream.WriteByte(0);
                    stream.WriteByte(1);
                    Console.WriteLine("Writing limit byte 1"); //Code beyond this point writes the limit
                    stream.WriteByte(Convert.ToByte(InputSecondsHex.Substring(0, 2), 16)); //Converts 2 hex values to bytes.
                    Console.WriteLine(InputSecondsHex.Substring(0, 2));
                    Console.WriteLine("Writing limit byte 2");
                    stream.WriteByte(Convert.ToByte(InputSecondsHex.Substring(2, 2), 16));
                    Console.WriteLine(InputSecondsHex.Substring(2, 2));
                    Console.WriteLine("Writing limit byte 3");
                    stream.WriteByte(Convert.ToByte(InputSecondsHex.Substring(4, 2), 16));
                    Console.WriteLine(InputSecondsHex.Substring(4, 2));
                    Console.WriteLine("Writing limit byte 4");
                    stream.WriteByte(Convert.ToByte(InputSecondsHex.Substring(6, 2), 16));
                    Console.WriteLine(InputSecondsHex.Substring(6, 2));
                    stream.Close();
                    return true;
                }
            }
            catch (Exception i)
            {
                Console.WriteLine(i);
                return false;
            }
        }

        public static bool MakeFileOutput() //This makes the output copy of the video file. 
        {
            try //In future, i might inplement a "Are you sure message" if the file already exists, or a random number on the copy file to ensure it doesnt right over any files.
            {
                PublicVariables.OutputFileFullPath = (PublicVariables.FileFullPath.Substring(0, PublicVariables.FileFullPath.Length - 4) + "_OUTPUT_" + DateTime.Now.ToString("dd_MM_yyy") + ".mp4");
                Console.WriteLine(PublicVariables.OutputFileFullPath);
                File.Copy(PublicVariables.FileFullPath, PublicVariables.OutputFileFullPath, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
