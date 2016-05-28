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
    public partial class updateBody : Form
    {
        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        public updateBody()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlCommand cmd2 = new MySqlCommand("update myfitsecret.body_measurements set bodyPart=@bodyPart,measurement=@measurement,DOP=@DOP where sportsmanID=@sportsmanID and bodyPart=@bodyPart", cnn);
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection.Open();

            cmd2.Parameters.AddWithValue("@sportsmanID", Login.userID);
            cmd2.Parameters.AddWithValue("@bodyPart",textBox1.Text);
            cmd2.Parameters.AddWithValue("@measurement", textBox2.Text);
            cmd2.Parameters.AddWithValue("@DOP", textBox3.Text);
            cmd2.ExecuteNonQuery();
            DataTable tablo = new DataTable();
            string showTable = "SELECT sportsmanID,bodyPart,measurement,DOP from myfitsecret.body_measurements";

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand showCommand = new MySqlCommand();

            showCommand.Connection = cnn;
            showCommand.CommandText = showTable;
            showCommand.CommandType = CommandType.Text;
            adapter.SelectCommand = showCommand;
            adapter.Fill(tablo);

            dataGridView1.DataSource = tablo;
            cnn.Close();
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
    }
}
