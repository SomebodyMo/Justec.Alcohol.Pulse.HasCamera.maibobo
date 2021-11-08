using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Justec.Alcohol.Pulse
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            appVersion.Text = "V" + Application.ProductVersion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
