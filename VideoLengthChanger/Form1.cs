using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoLengthChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void Start_Click(object sender, EventArgs e)
        {   
            if (PublicFunctions.FrontendFunctions.CheckAndCalculateInput(NewCustom.Text))
            {
                PublicFunctions.FrontendFunctions.EditData();
                
            }
            else
            {
                MessageBox.Show("Please only input numbers!");
            }
        }

        public void Browse(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = ".mp4 Files (*.mp4*)|*.mp4*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                PublicVariables.filelocation = choofdlog.FileName;
                LocationText.Text = choofdlog.SafeFileName;
                PublicFunctions.FrontendFunctions.getVideoLength();
                IncPerSecond.Text = PublicVariables.seconds.ToString();
                Start.Enabled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }

    public class VisualFunctions {
        static void ChangeVideoLengthTextBox()
        {

        }
    }

}
