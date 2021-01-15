using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP4_Length_Modifier
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/retr0mod8/MP4-Length-Modifier");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ&get-trolled");
        }
    }
}
