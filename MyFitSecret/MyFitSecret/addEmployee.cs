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
    public partial class addEmployee : Form
    {
        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        public addEmployee()
        {
            InitializeComponent();
        }
        string imageLoc = "";
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            try
            {

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(*.jgp|*.jpg|GIF Files(*.gif)|*.gif|All Files(*.*)|*.*)";
                dlg.Title = "Select Sportsman Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imageLoc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imageLoc;


                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                try
                {

                    cnn.Open();
                    byte[] img = null;
                    FileStream fs = new FileStream(imageLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader bin = new BinaryReader(fs);
                    img = bin.ReadBytes((int)fs.Length);

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO myfitsecret.employee (userID,Name,Password,Address,Phone,Photo,isAdmin) VALUES (@userID,@Name,@Password,@Address,@Phone,@Photo,@isAdmin)");
                    cmd.CommandType = CommandType.Text;

                    MySqlCommand cmd3 = new MySqlCommand("INSERT INTO myfitsecret.employee_phones (employeeID,phone) VALUES (@employeeID,@phone)");
                    cmd3.CommandType = CommandType.Text;

                    MySqlCommand cmd2 = new MySqlCommand("INSERT INTO myfitsecret.entrance (id,password,isAdmin) VALUES (@id,@password,@isAdmin)");
                    cmd3.CommandType = CommandType.Text;
                    cmd.Connection = cnn;
                    cmd2.Connection = cnn;
                    cmd3.Connection = cnn;

                    cmd.Parameters.AddWithValue("@userID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox5.Text);
                    cmd.Parameters.AddWithValue("@isAdmin", textBox6.Text);
                    cmd.Parameters.Add(new MySqlParameter("@Photo", img));


                    cmd2.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@password", textBox3.Text);
                    cmd2.Parameters.AddWithValue("@isAdmin", textBox6.Text);

                    cmd3.Parameters.AddWithValue("@employeeID", textBox1.Text);
                    cmd3.Parameters.AddWithValue("@phone", textBox5.Text);

                    cmd.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();

                }

                catch (Exception ex)
                { MessageBox.Show(ex.Message); }

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
    }
}
