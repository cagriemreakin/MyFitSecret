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
    public partial class cardio : Form
    {
        public cardio()
        {
            InitializeComponent();
            axShockwaveFlash1.Movie = "https://www.youtube.com/v/-kFIwK71AFw";

            axShockwaveFlash1.BringToFront();
            axShockwaveFlash1.Visible = true;

            axShockwaveFlash2.Movie = "https://www.youtube.com/v/s2XdUFxR6B4";

            axShockwaveFlash2.BringToFront();
            axShockwaveFlash2.Visible = true;
        }

        private void cardio_Load(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            Sportsman frm = new Sportsman();
            frm.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
