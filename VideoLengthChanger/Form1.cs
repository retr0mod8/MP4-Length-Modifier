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
                Start.Enabled = false; //Debounce
                NewCustom.ReadOnly = true; //Ditto
                bool WhileLoop = true;

                PublicFunctions.FrontendFunctions.EditData();
                while (WhileLoop){ //constantly check if the edit data job is done.
                    if (PublicVariables.EditDataFinished == true){
                        WhileLoop = false;
                        Start.Enabled = true;
                        NewCustom.ReadOnly = false;
                    }

                }
                
            }
            else
            {
                MessageBox.Show("Invalid Number!");
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
                PublicVariables.seconds = 0;
                PublicVariables.EditDataFinished = false;
                PublicFunctions.FrontendFunctions.getHeaderOffset();
                /*PublicFunctions.FrontendFunctions.getVideoLength();
                if (PublicVariables.seconds >= 0){
                    IncPerSecond.Text = PublicVariables.seconds.ToString();
                }
                else
                {
                    IncPerSecond.Text = "N/A";
                }
                */
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

        private void NewCustom_TextChanged(object sender, EventArgs e)
        {

        }

        private void LocationText_TextChanged(object sender, EventArgs e)
        {

        }

        private void IncPerSecond_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class VisualFunctions {
        static void ChangeVideoLengthTextBox()
        {

        }
    }

}
