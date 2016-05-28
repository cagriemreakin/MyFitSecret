using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFitSecret
{
    public partial class Weight_Training_Videos : Form
    {
        public Weight_Training_Videos()
        {
            InitializeComponent();
            axShockwaveFlash1.Movie = "https://www.youtube.com/v/zkt6E5MibYE";

            axShockwaveFlash1.BringToFront();
            axShockwaveFlash1.Visible = true;
           
            axShockwaveFlash2.Movie = "https://www.youtube.com/v/JBKej6n_A9I";

            axShockwaveFlash2.BringToFront();
            axShockwaveFlash2.Visible = true;

            axShockwaveFlash3.Movie = "https://www.youtube.com/v/NftbyLKI0So";

            axShockwaveFlash3.BringToFront();
            axShockwaveFlash3.Visible = true;

            axShockwaveFlash4.Movie = "https://www.youtube.com/v/s1CgCndoSYg";

            axShockwaveFlash4.BringToFront();
            axShockwaveFlash4.Visible = true;

            axShockwaveFlash5.Movie = "https://www.youtube.com/v/8yLnrF_Ar-c";

            axShockwaveFlash5.BringToFront();
            axShockwaveFlash5.Visible = true;

            axShockwaveFlash6.Movie = "https://www.youtube.com/v/EX2ofDwCwvo";

            axShockwaveFlash6.BringToFront();
            axShockwaveFlash6.Visible = true;

            axShockwaveFlash7.Movie = "https://www.youtube.com/v/q-uAcL2W-3w";

            axShockwaveFlash7.BringToFront();
            axShockwaveFlash7.Visible = true;

            axShockwaveFlash8.Movie = "https://www.youtube.com/v/uPfwUvnM7AI";

            axShockwaveFlash8.BringToFront();
            axShockwaveFlash8.Visible = true;



        }

        private void Weight_Training_Videos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sportsman frm = new Sportsman();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
