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
    public partial class updateWeights : Form
    {
        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        public updateWeights()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sportsman frm = new Sportsman();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd2 = new MySqlCommand("update myfitsecret.body_progress set last_weight=@last_weight,target_weight=@target_weight where sportsmanID=@sportsmanID", cnn);
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection.Open();
            cmd2.Parameters.AddWithValue("@sportsmanID", Login.userID);
            cmd2.Parameters.AddWithValue("@last_weight", textBox1.Text);
            cmd2.Parameters.AddWithValue("@target_weight", textBox2.Text);

           string showTable = "SELECT first_weight,last_weight,target_weight from myfitsecret.body_progress where sportsmanID=@sportsmanID";
            cmd2.ExecuteNonQuery();
            DataTable tablo = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand showCommand = new MySqlCommand();

            showCommand.Connection = cnn;
            showCommand.CommandText = showTable;
            showCommand.CommandType = CommandType.Text;
            showCommand.Parameters.AddWithValue("@sportsmanID", Login.userID);
            adapter.SelectCommand = showCommand;
            adapter.Fill(tablo);

            dataGridView1.DataSource = tablo;
            dataGridView1.DataSource = tablo;
            cnn.Close();
        }
    }
}
