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
    public partial class employee : Form
    {
        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        public employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnn.Open();
            DataTable tablo = new DataTable();
            string showTable = "SELECT enterance_time from myfitsecret.user_tracker where sportsman_id=@sportsman_id";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand showCommand = new MySqlCommand();

            showCommand.Connection = cnn;
            showCommand.CommandText = showTable;
            showCommand.CommandType = CommandType.Text;
            showCommand.Parameters.AddWithValue("@sportsman_id", textBox1.Text);
            adapter.SelectCommand = showCommand;
            adapter.Fill(tablo);

            dataGridView1.DataSource = tablo;
            cnn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            cnn.Open();
            DataTable tablo = new DataTable();
            string showTable = "SELECT exit_time from myfitsecret.user_tracker where sportsman_id=@sportsman_id";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand showCommand = new MySqlCommand();

            showCommand.Connection = cnn;
            showCommand.CommandText = showTable;
            showCommand.CommandType = CommandType.Text;
            showCommand.Parameters.AddWithValue("@sportsman_id", textBox1.Text);
            adapter.SelectCommand = showCommand;
            adapter.Fill(tablo);

            dataGridView1.DataSource = tablo;
            cnn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            cnn.Open();
            DataTable tablo = new DataTable();
            string showTable = "SELECT * from myfitsecret.body_progress where sportsmanID=@sportsmanID";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand showCommand = new MySqlCommand();

            showCommand.Connection = cnn;
            showCommand.CommandText = showTable;
            showCommand.CommandType = CommandType.Text;
            showCommand.Parameters.AddWithValue("@sportsmanID", textBox1.Text);
            adapter.SelectCommand = showCommand;
            adapter.Fill(tablo);

            dataGridView1.DataSource = tablo;
            cnn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            cnn.Open();
            DataTable tablo = new DataTable();
            string showTable = "SELECT * from myfitsecret.calorie_tracker where sportsman_id=@sportsman_id";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand showCommand = new MySqlCommand();

            showCommand.Connection = cnn;
            showCommand.CommandText = showTable;
            showCommand.CommandType = CommandType.Text;
            showCommand.Parameters.AddWithValue("@sportsman_id", textBox1.Text);
            adapter.SelectCommand = showCommand;
            adapter.Fill(tablo);

            dataGridView1.DataSource = tablo;
            cnn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
                    }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            cnn.Open();
            DataTable tablo = new DataTable();
            string showTable = "SELECT `type`, Count(`type`) as `occurance` from myfitsecret.videos Group by `type` order by `occurance` desc limit 1";
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

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            cnn.Open();
            DataTable tablo = new DataTable();
            string showTable = "select `type`,count(t.type) as `occurance` from(select sportsman.userid, sportsman_workout.type from myfitsecret.sportsman join myfitsecret.sportsman_workout on sportsman.userid = sportsman_workout.sportsmanId where sex = 'female') as t group by `type` order by `occurance` desc limit 1";

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

        private void button10_Click(object sender, EventArgs e)
        {
            cnn.Open();
            DataTable tablo = new DataTable();
            string showTable = "select `type`,count(t.type) as `occurance` from(select sportsman.userid,sportsman_workout.type from myfitsecret.sportsman join myfitsecret.sportsman_workout on sportsman.userid = sportsman_workout.sportsmanId where(YEAR(CURDATE()) - dob) and sex = 'male')as t group by `type`order by `occurance` desc limit 1 ";

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

        private void button11_Click(object sender, EventArgs e)
        {
            cnn.Open();
            DataTable tablo = new DataTable();
            string showTable = "SELECT name, MAX(body_progress.totDifference) FROM myfitsecret.sportsman JOIN myfitsecret.sportsman_workout ON sportsman.userid = sportsman_workout.sportsmanId JOIN myfitsecret.body_progress ON sportsman_workout.sportsmanId = body_progress.sportsmanID WHERE(sportsman.sex = 'female' and sportsman_workout.type = 'cardio') ";

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

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            addSportsman frm = new addSportsman();
            frm.Show();
            this.Hide();
        }

        private void employee_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            cnn.Open();
            string query = "SELECT * from myfitsecret.sportsman where userid=@userid"; //Based on studentID,get the student informations

            MySqlCommand queryCommand = new MySqlCommand(query, cnn);
            queryCommand.Parameters.AddWithValue("@userid", textBox1.Text);  //send the text box value to studentID


            MySqlDataAdapter da = new MySqlDataAdapter(queryCommand);
            MySqlDataReader dr = queryCommand.ExecuteReader();//student data is sended to memory with datareader.

            if (dr.Read()) //if datareader can read anything
            {

                string name = dr["name"].ToString();
                dr.Close();

                DialogResult answer = MessageBox.Show(" Are you sure to delete the record ?", "Approve Deletion", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == answer) // If the user selects the "Yes", the codes below runs to delete records
                {
                    string deleteQuery = "DELETE from myfitsecret.sportsman where userid=@userid";//sql command to delete student records

                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, cnn);
                    deleteCommand.Parameters.AddWithValue("@userid", textBox1.Text);

                    deleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Record is deleted...");

                }
            }
            else
                MessageBox.Show("No Record Found.");


            cnn.Close();

        }

        private void button14_Click(object sender, EventArgs e)
        {

            updateSportsman frm = new updateSportsman();
            frm.Show();
            this.Hide();
        }
    }
}
