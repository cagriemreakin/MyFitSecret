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
    public partial class burned : Form
    {

        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        public burned()
        {
            InitializeComponent();
            Fillcombo();
        }
        void Fillcombo()
        {
            string cnn = "datasource=localhost;port=3306;username=root;password=963369";
            string query = "select workoutType from myfitsecret.workout;";
            MySqlConnection con = new MySqlConnection(cnn);
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader rd;
            try
            {
                con.Open();
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string s = rd.GetString("workoutType");
                    comboBox1.Items.Add(s);
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void burned_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myfitsecretDataSet.workout' table. You can move, or remove it, as needed.
            this.workoutTableAdapter.Fill(this.myfitsecretDataSet.workout);

        }

        private void button1_Click(object sender, EventArgs e)
        {


            
            string time = DateTime.Now.ToString("yyyy-MM-dd");
           
            
            string s = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            MessageBox.Show(s);
            string sex="0" ;
            string height="0";
            cnn.Open();
            string weight =" 0";
            string cmdText = @"SELECT sex 
                   FROM myfitsecret.sportsman 
                   WHERE userid=@userid;
                   SELECT daily_burned
                   FROM myfitsecret.calorie_tracker 
                   WHERE sportsman_id=@sportsman_id";
            using (MySqlCommand cmd = new MySqlCommand(cmdText, cnn))
            {
                // Add both parameters to the same command
                cmd.Parameters.Add("@userid", MySqlDbType.String).Value = Login.userID;
                cmd.Parameters.Add("@sportsman_id", MySqlDbType.String).Value = Login.userID;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // get sum from the first result
                    if (reader.Read()) sex = ((reader[0]).ToString());

                    // if there is a second resultset, go there
                    if (reader.NextResult())
                        if (reader.Read() && !(reader[0] is DBNull))
                            Sportsman.burned += Convert.ToInt32(reader[0]);

                }
                cmd.Connection.Close();

               

                 cmdText = @"SELECT sportsman.height
                   FROM myfitsecret.sportsman 
                   WHERE userid=@userid;
                   SELECT body_progress.last_weight
                   FROM myfitsecret.body_progress 
                   WHERE sportsmanID=@sportsmanID";

                using (MySqlCommand cmd2 = new MySqlCommand(cmdText, cnn))
                {
                    cmd2.Connection.Open();

                    // Add both parameters to the same command
                    cmd2.Parameters.Add("@userid", MySqlDbType.String).Value = Login.userID;
                    cmd2.Parameters.Add("@sportsmanID", MySqlDbType.String).Value = Login.userID;
                    
                    using (MySqlDataReader reader2 = cmd2.ExecuteReader())
                    {
                        // get sum from the first result
                        if (reader2.Read()) height = (reader2[0]).ToString();

                        // if there is a second resultset, go there
                        if (reader2.NextResult())
                            if (reader2.Read())
                                weight = (reader2[0]).ToString();

                    }
                    cmd2.Connection.Close();
                    if (Sportsman.count1 == 0)
                    {
                            if (sex.Equals("male") && s.Equals("weightTraining"))
                            {
                                Sportsman.burned1 += 700 + (15 * int.Parse(weight)) + (5 * int.Parse(height)) - (7 * 30) + (int.Parse(textBox1.Text) * 14);
                                MessageBox.Show("Burned calories are updated");
                            }
                            else if (sex.Equals("male") && s.Equals("cardio"))
                            {
                                Sportsman.burned1 += 700 + (15 * int.Parse(weight)) + (5 * int.Parse(height)) - (7 * 30) + (int.Parse(textBox1.Text) * 10);
                                MessageBox.Show("Burned calories are updated");
                            }
                            else if (sex.Equals("female") && s.Equals("weightTraining"))
                            {
                                Sportsman.burned1 += 900 + (9 * int.Parse(weight)) + (2 * int.Parse(height)) - (5 * 30) + (int.Parse(textBox1.Text) * 10);
                                MessageBox.Show("Burned calories are updated");
                            }
                            else
                            {
                                Sportsman.burned1 += 900 + (9 * int.Parse(weight)) + (2 * int.Parse(height)) - (5 * 30) + (int.Parse(textBox1.Text) * 6);
                                MessageBox.Show("Burned calories are updated");
                            }
                   
                            MySqlCommand cmd5 = new MySqlCommand("UPDATE myfitsecret.calorie_tracker set daily_burned=@daily_burned where sportsman_id=@sportsman_id and Date=@Date", cnn);
                            cmd5.CommandType = CommandType.Text;
                            cmd5.Connection.Open();

                            cmd5.Parameters.AddWithValue("@daily_burned", Sportsman.burned1);
                            cmd5.Parameters.AddWithValue("@Date", time);
                            cmd5.Parameters.Add("@sportsman_id", MySqlDbType.String).Value = Login.userID;
                            cmd5.ExecuteNonQuery();
                            cmd5.Connection.Close();
                            Sportsman.count1++;

                    }
                    else {
                        if (sex.Equals("male"))
                            Sportsman.burned1 += (int.Parse(textBox1.Text) * 10);

                        else
                            Sportsman.burned1 += (int.Parse(textBox1.Text) * 6);

                        MySqlCommand cmd3 = new MySqlCommand("update myfitsecret.calorie_tracker set daily_burned=@daily_burned where sportsman_id=@sportsman_id and Date=@Date", cnn);
                        cmd3.CommandType = CommandType.Text;
                        cmd3.Connection.Open();

                        cmd3.Parameters.AddWithValue("@daily_burned", Sportsman.burned1);
                        cmd3.Parameters.AddWithValue("@Date", time);
                        cmd3.Parameters.Add("@sportsman_id", MySqlDbType.String).Value = Login.userID;
                        cmd3.ExecuteNonQuery();
                        
                    }
                    DataTable tablo = new DataTable();

                    string showTable = "SELECT daily_gained,daily_burned,Date from myfitsecret.calorie_tracker where sportsman_id=@sportsman_id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    MySqlCommand showCommand = new MySqlCommand();

                    showCommand.Connection = cnn;
                    showCommand.CommandText = showTable;
                    showCommand.CommandType = CommandType.Text;
                    showCommand.Parameters.AddWithValue("@sportsman_id", Login.userID);
                    adapter.SelectCommand = showCommand;
                    adapter.Fill(tablo);

                    dataGridView1.DataSource = tablo;
                    cmd.Connection.Close();
                    cnn.Close();
                }
            }
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            Sportsman frm = new Sportsman();
            frm.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}