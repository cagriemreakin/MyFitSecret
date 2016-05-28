using MySql.Data.MySqlClient;
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
    public partial class Sportsman : Form
    {
        public static int count = 0;
        public static int burned = 0;
        public static int count1 = 0;
        public static int burned1 = 0;
        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        public Sportsman()
        {
            InitializeComponent();
        }

        private void Sportsman_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myfitsecretDataSet1.food' table. You can move, or remove it, as needed.
          
            // TODO: This line of code loads data into the 'myfitsecretDataSet.workout' table. You can move, or remove it, as needed.
          

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.workoutTableAdapter.FillBy(this.myfitsecretDataSet.workout);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Weight_Training_Videos frm = new Weight_Training_Videos();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cardio frm = new cardio();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bodyProgress frm = new bodyProgress();
            cnn.Open();
            DataTable tablo = new DataTable();
            string showTable = "SELECT * from myfitsecret.body_progress where sportsmanID=@sportsmanID";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand showCommand = new MySqlCommand();

            showCommand.Connection = cnn;
            showCommand.CommandText = showTable;
            showCommand.CommandType = CommandType.Text;
            showCommand.Parameters.AddWithValue("@sportsmanID", Login.userID);
            adapter.SelectCommand = showCommand;
            adapter.Fill(tablo);

            frm.dataGridView1.DataSource = tablo;
            cnn.Close();
            
            frm.Show();
            this.Hide();
        }

     
        private void button6_Click(object sender, EventArgs e)
        {
            burned frm = new burned();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            updateBody frm = new updateBody();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            insertConsumed frm = new insertConsumed();
            frm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            updateWeights frm = new updateWeights();
            frm.Show();
            this.Hide();
        }
    }
}
