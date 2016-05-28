using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFitSecret
{
    public partial class updateEmployee : Form
    {
        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        public updateEmployee()
        {
            InitializeComponent();
        }
        string imageLoc = "";
        private void button5_Click(object sender, EventArgs e)
        {


            cnn.Open();
            string record = "SELECT * from myfitsecret.employee where userID=@userID";

            MySqlCommand command = new MySqlCommand(record, cnn);
            command.Parameters.AddWithValue("@userID", textBox7.Text);

            MySqlDataAdapter da = new MySqlDataAdapter(command);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read()) //just one record
            {
                

                textBox1.Text = dr["userID"].ToString();
                textBox2.Text = dr["Name"].ToString();
                textBox3.Text = dr["Password"].ToString();
                textBox4.Text = dr["Address"].ToString();
                textBox5.Text = dr["Phone"].ToString();
                textBox6.Text = dr["isAdmin"].ToString();        
       
  

                //imported to form values
            }

            else
            {
                MessageBox.Show("Record is not found.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                
             
            }

            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                try
                {


                    cnn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE myfitsecret.employee SET userID=@userID,Name=@Name,Password=@Password,Address=@Address,Phone=@Phone,isAdmin=@isAdmin where userID=@userID");
                    cmd.CommandType = CommandType.Text;

                   

                    cmd.Connection = cnn;
          
                    cmd.Parameters.AddWithValue("@userID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox5.Text);
                    cmd.Parameters.AddWithValue("@isAdmin", textBox6.Text);
   
                    cmd.ExecuteNonQuery();

                    
                }

                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                MessageBox.Show("Student records are updated!");
                DataTable tablo = new DataTable();

                string showTable = "SELECT * from myfitsecret.employee";
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand showCommand = new MySqlCommand();

                showCommand.Connection = cnn;
                showCommand.CommandText = showTable;

                adapter.SelectCommand = showCommand;
                adapter.Fill(tablo);

                dataGridView1.DataSource = tablo;
                cnn.Close();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin frm = new Admin();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Admin frm = new Admin();
            frm.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
    

