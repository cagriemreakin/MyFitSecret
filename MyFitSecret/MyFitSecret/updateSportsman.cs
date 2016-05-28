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
    public partial class updateSportsman : Form
    {
        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        public updateSportsman()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string record = "SELECT * from myfitsecret.sportsman where userid=@userid";

            MySqlCommand command = new MySqlCommand(record, cnn);
            command.Parameters.AddWithValue("@userid", textBox12.Text);

            MySqlDataAdapter da = new MySqlDataAdapter(command);
            MySqlDataReader dr = command.ExecuteReader();

            if (dr.Read()) //just one record
            {


                textBox1.Text = dr["userid"].ToString();
                textBox2.Text = dr["name"].ToString();
      
                textBox5.Text = dr["email"].ToString();
                textBox6.Text = dr["address"].ToString();
                textBox7.Text = dr["econtact"].ToString();
                textBox8.Text = dr["password"].ToString();
             

                //imported to form values
            }

            else
            {
                MessageBox.Show("Record is not found.");
                textBox1.Clear();
                textBox2.Clear();
           
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();

            }

            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {


                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("update myfitsecret.sportsman set name=@name,password=@password,address=@address,email=@email,econtact=@econtact where userid=@userid  ");
                cmd.CommandType = CommandType.Text;

                MySqlCommand cmd2 = new MySqlCommand("update myfitsecret.sportsmanpassword set password=@password where email=@email");
                cmd2.CommandType = CommandType.Text;

                MySqlCommand cmd3 = new MySqlCommand("update myfitsecret.sportsmanphones set phone=@phone where sportsmanID=@sportsmanID");
                cmd3.CommandType = CommandType.Text;

                cmd.Connection = cnn;
                cmd2.Connection = cnn;
                cmd3.Connection = cnn;

                cmd.Parameters.AddWithValue("@userid", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@password", textBox8.Text);
                cmd.Parameters.AddWithValue("@address", textBox6.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);
                cmd.Parameters.AddWithValue("@econtact", textBox7.Text);
    
                cmd2.Parameters.AddWithValue("@email", textBox5.Text);
                cmd2.Parameters.AddWithValue("@password", textBox8.Text);

                cmd3.Parameters.AddWithValue("@sportsmanID", textBox1.Text);
                cmd3.Parameters.AddWithValue("@phone", textBox4.Text);

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();



            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            MessageBox.Show("Sportsman records are updated!");
            DataTable tablo = new DataTable();

            string showTable = "SELECT * from myfitsecret.sportsman";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand showCommand = new MySqlCommand();

            showCommand.Connection = cnn;
            showCommand.CommandText = showTable;

            adapter.SelectCommand = showCommand;
            adapter.Fill(tablo);

            dataGridView1.DataSource = tablo;
            cnn.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            employee frm = new employee();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
