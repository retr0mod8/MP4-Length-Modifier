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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = ".mp4 Files (*.mp4*)|*.mp4*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                PublicVariables.Status = 0;
                Output.Text = "Status: Idle";
                PublicVariables.FileLocation = choofdlog.FileName;
                PublicVariables.FileDirectory = choofdlog.FileName.Substring(0,choofdlog.FileName.Length - choofdlog.SafeFileName.Length);
                PublicVariables.FileName = choofdlog.SafeFileName;
                Console.WriteLine(PublicVariables.FileDirectory);
                Console.WriteLine("Saved '"+choofdlog.FileName+ "' to PublicVariables.FileLocation");
                Console.WriteLine("File Opened, Now to do a verification check");
                PublicVariables.InputSeconds = 0;
                Hour.Value = 0;
                Minute.Value = 0;
                Seconds.Value = 0;
                StartButton.Enabled = false;
                Hour.Enabled = false;
                Minute.Enabled = false;
                Seconds.Enabled = false;
                if (PublicFunctions.FileVerification(choofdlog.FileName))
                {
                    PathText.Text = choofdlog.SafeFileName;
                    StartButton.Enabled = true;
                    Hour.Enabled = true;
                    Minute.Enabled = true;
                    Seconds.Enabled = true;
                    Console.WriteLine("Verification Successful");
                }
                else
                {
                    Console.WriteLine("Verification Failed");
                    PathText.Text = choofdlog.SafeFileName;
                    MessageBox.Show("Invalid MP4 File Selected, try re-encoding the video.");
                };
            }
        }



        private void InfoBox_Click(object sender, EventArgs e)
        {
            var m = new Help();
            m.Show();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Output.Text = "Status: Performing Task";
            Console.WriteLine(PublicVariables.FileLocation);
            StartButton.Enabled = false;
            Hour.Enabled = false;
            Minute.Enabled = false;
            Seconds.Enabled = false;
            BrowseButton.Enabled = false;
            StartButton.Enabled = false;
            PublicFunctions.SaveInputSeconds(Hour.Value, Minute.Value, Seconds.Value);
            PublicFunctions.WriteSeconds(BackupCheckbox.Checked);
            StartButton.Enabled = true;
            Hour.Enabled = true;
            Minute.Enabled = true;
            Seconds.Enabled = true;
            BrowseButton.Enabled = true;
            StartButton.Enabled = true;
            if (PublicVariables.Status == 1){
                Output.Text = "Status: Cancelled by user";
            }
            else if (PublicVariables.Status == 2){
                Output.Text = "Status: Completed";
            }
        }

        private void LicenseBox_Click(object sender, EventArgs e)
        {
            var s = new LicenseForm();
            s.Show();
        }
    }
}