using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP4_Length_Modifier
{
    public class PublicVariables
    {
        public static bool release = false; // true = release version / false = debug version
        public static int status = 0; // 0 = idle / 1 = busy / 2 = finished / 3 = error
        public static string FileFullPath = ""; //Full path of the selected file (including extension)
        public static string FileName = ""; //Full name (and extension) of selected video file
        public static string FileParentDirectory = ""; //Path to the directory containing the selected video file
        public static uint IncrementPosition = 0;
        public static uint InputVideoLength = 0;
        public static string OutputFileFullPath = "";



        public static string ExecutableDirectory() //Returns the executable's parent folder
        {
            return (System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, System.Reflection.Assembly.GetExecutingAssembly().Location.Length - System.AppDomain.CurrentDomain.FriendlyName.Length));
        }
    }
}
