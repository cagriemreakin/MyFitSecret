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
    public partial class addSportsman : Form
    {
        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        public addSportsman()
        {
            InitializeComponent();
        }
        string imageLoc = "";
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

        private void button4_Click(object sender, EventArgs e)
        {
            employee frm = new employee();
            frm.Show();
            this.Hide();
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

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO myfitsecret.sportsman (userid,name,password,address,email,econtact,weight,height,photo,dob,sex) VALUES (@userid,@name,@password,@address,@email,@econtact,@weight,@height,@photo,@dob,@sex)");
                    cmd.CommandType = CommandType.Text;

                    MySqlCommand cmd2 = new MySqlCommand("INSERT INTO myfitsecret.sportsmanpassword (email,password) VALUES (@email,@password)");
                    cmd2.CommandType = CommandType.Text;

                    MySqlCommand cmd3 = new MySqlCommand("INSERT INTO myfitsecret.sportsmanphones (sportsmanID,phone) VALUES (@sportsmanID,@phone)");
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
                    cmd.Parameters.AddWithValue("@weight", textBox9.Text);
                    cmd.Parameters.AddWithValue("@height", textBox10.Text);
                    cmd.Parameters.Add(new MySqlParameter("@photo", img));
                    cmd.Parameters.AddWithValue("@dob", int.Parse(textBox11.Text));
                    cmd.Parameters.AddWithValue("@sex", textBox3.Text);
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
