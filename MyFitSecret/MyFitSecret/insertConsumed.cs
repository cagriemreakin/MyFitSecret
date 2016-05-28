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
    public partial class insertConsumed : Form
    {
        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        
        public insertConsumed()
        {
            InitializeComponent();
            Fillcombo();
        }
        void Fillcombo()
        {
            string cnn = "datasource=localhost;port=3306;username=root;password=963369";
            string query = "select name from myfitsecret.food;";
            MySqlConnection con = new MySqlConnection(cnn);
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader rd;
            try
            {
                con.Open();
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string s = rd.GetString("name");
                    comboBox1.Items.Add(s);
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            string time = DateTime.Now.ToString("yyyy-MM-dd");
          
            string s = (comboBox1.SelectedItem).ToString();
          
            if (Sportsman.count == 0)
            {

                string cmdText = @"SELECT calorificValue 
                       FROM myfitsecret.food 
                       WHERE name=@name;
                       SELECT daily_gained
                       FROM myfitsecret.calorie_tracker 
                       WHERE sportsman_id=@sportsman_id";
                using (MySqlCommand cmd = new MySqlCommand(cmdText, cnn))
                {
                    cmd.Connection.Open();
                    // Add both parameters to the same command
                    cmd.Parameters.Add("@name", MySqlDbType.String).Value = s;
                    cmd.Parameters.Add("@sportsman_id", MySqlDbType.String).Value = Login.userID;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // get sum from the first result
                        if (reader.Read()) Sportsman.burned += (Convert.ToInt32(reader[0]) * int.Parse(textBox1.Text));

                        // if there is a second resultset, go there
                        if (reader.NextResult())
                            if (reader.Read())
                                Sportsman.burned = Sportsman.burned;

                    }
                    cmd.Connection.Close();

                    MySqlCommand cmd2 = new MySqlCommand("insert into myfitsecret.calorie_tracker  (daily_gained,sportsman_id,Date) values (@daily_gained,@sportsman_id,@Date) ", cnn);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Connection.Open();

                    cmd2.Parameters.AddWithValue("@daily_gained", Sportsman.burned);
                    cmd2.Parameters.AddWithValue("@Date", time);
                    cmd2.Parameters.Add("@sportsman_id", MySqlDbType.String).Value = Login.userID;
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show(Sportsman.burned + "");
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
                    Sportsman.count++;
                    cmd.Connection.Close();
                }
            }

            else {  //update

                string cmdText = @"SELECT calorificValue 
                   FROM myfitsecret.food 
                   WHERE name=@name;
                   SELECT daily_gained
                   FROM myfitsecret.calorie_tracker 
                   WHERE sportsman_id=@sportsman_id";
                using (MySqlCommand cmd = new MySqlCommand(cmdText, cnn))
                {
                    cmd.Connection.Open();
                    // Add both parameters to the same command
                    cmd.Parameters.Add("@name", MySqlDbType.String).Value = s;
                    cmd.Parameters.Add("@sportsman_id", MySqlDbType.String).Value = Login.userID;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // get sum from the first result
                        if (reader.Read()) Sportsman.burned += (Convert.ToInt32(reader[0]) * int.Parse(textBox1.Text));

                        // if there is a second resultset, go there
                        if (reader.NextResult())
                            if (reader.Read()) { }
                               // burned += Convert.ToInt32(reader[0]);

                    }
                    cmd.Connection.Close();

                    MySqlCommand cmd2 = new MySqlCommand("update myfitsecret.calorie_tracker set daily_gained=@daily_gained where sportsman_id=@sportsman_id and Date=@Date", cnn);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Connection.Open();

                    cmd2.Parameters.AddWithValue("@daily_gained", Sportsman.burned);
                    cmd2.Parameters.AddWithValue("@Date", time);
                    cmd2.Parameters.Add("@sportsman_id", MySqlDbType.String).Value = Login.userID;
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show(Sportsman.burned + "");
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
    }
}