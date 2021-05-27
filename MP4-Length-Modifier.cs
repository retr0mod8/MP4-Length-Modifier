using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP4_Length_Modifier
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog VideoInput = new OpenFileDialog(); //Sets up the file select dialog
            VideoInput.Filter = ".mp4 Files (*.mp4*)|*.mp4*"; // Filter ONLY MP4 Files!
            VideoInput.InitialDirectory = PublicVariables.ExecutableDirectory(); //Sets directory to where the exe is
            VideoInput.FilterIndex = 1; //Sets index to 1, better safe than sorry
            VideoInput.Multiselect = false; //Doesn't allow you to select multiple files

            if (VideoInput.ShowDialog() == DialogResult.OK) //Only executes command if a file is selected
            {
                outputConsole.Text = "Status: Verifying file please wait!";
                buttonBrowse.Enabled = false;
                buttonStart.Enabled = false;
                inputHours.Enabled = false;
                inputMinutes.Enabled = false;
                inputSeconds.Enabled = false;
                PublicVariables.FileFullPath = VideoInput.FileName;
                PublicVariables.FileName = VideoInput.SafeFileName;
                PublicVariables.FileParentDirectory = VideoInput.FileName.Substring(0 , (VideoInput.FileName.Length - VideoInput.SafeFileName.Length));
                Console.WriteLine(PublicVariables.FileFullPath);
                Console.WriteLine(PublicVariables.FileName);
                Console.WriteLine(PublicVariables.FileParentDirectory);
                outputFileName.Text = PublicVariables.FileName;
                if (PublicFunctions.VerifyInputFile())
                {
                    PublicFunctions.ReadInputFileIncrement();
                    UInt32 Seconds = PublicVariables.InputVideoLength;
                    inputHours.Value = Seconds / 3600;
                    Seconds -= (Seconds / 3600) * 3600;
                    inputMinutes.Value = Seconds / 60;
                    Seconds -= (Seconds / 60) * 60;
                    inputSeconds.Value = Seconds;
                    outputConsole.Text = "Status: File verified! Input your desired time and click 'Start...'";
                    buttonBrowse.Enabled = true;
                    buttonStart.Enabled = true;
                    inputHours.Enabled = true;
                    inputMinutes.Enabled = true;
                    inputSeconds.Enabled = true;
                }
                else
                {
                    outputConsole.Text = "Status: File failed verification! The video file might be missing, or in use by another program.";
                    buttonBrowse.Enabled = true;
                    buttonStart.Enabled = false;
                    inputHours.Enabled = false;
                    inputMinutes.Enabled = false;
                    inputSeconds.Enabled = false;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e) //Executes these commands when the 'Start...' button is clicked
        {
            inputHours.Enabled = false; //Disables these quickly to prevent the user from clicking it twice
            inputMinutes.Enabled = false;
            inputSeconds.Enabled = false;
            buttonBrowse.Enabled = false;
            buttonStart.Enabled = false;
            // in the future, i might make 'MakeFileOutput' a part of 'WriteInputSeconds' to ensure an output file is made before trying to write to it.
            if (PublicFunctions.MakeFileOutput() == true & PublicFunctions.WriteInputSeconds(Convert.ToUInt32(inputHours.Value), Convert.ToUInt32(inputMinutes.Value), Convert.ToUInt32(inputSeconds.Value)) == true) //Executes both functions
            {
                progressBar.Value = 100;
                outputConsole.Text = "Status: Processing complete! The output is in the same directory as the input video.";
                PublicFunctions.CleanupVariables();
                buttonStart.Enabled = true;
                inputHours.Enabled = true;
                inputMinutes.Enabled = true;
                inputSeconds.Enabled = true;
                buttonBrowse.Enabled = true;
            }
            else
            {
                progressBar.Value = 0;
                buttonStart.Enabled = true;
                outputConsole.Text = "Status: Video failed to process, is another process using it? Is the video still there?";
            }
        }
    }
}
