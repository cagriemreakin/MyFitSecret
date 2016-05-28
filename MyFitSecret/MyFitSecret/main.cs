using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace MyFitSecret
{
    public partial class Login : Form
    {
        public static string userID = "";
        public static string userPassword = "";
        public static  MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");

        public Login()
        {
            InitializeComponent();
            password.PasswordChar = '*';
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                userID = id.Text;
                userPassword = password.Text;


                MySqlCommand cmd = new MySqlCommand("select id,isAdmin  from myfitsecret.entrance where id = @ID and password = @Password", con);

                cmd.Parameters.AddWithValue("@ID", id.Text);
                cmd.Parameters.AddWithValue("@Password", password.Text);
               
                cmd.Connection.Open();
                
                MySqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
                if (rd.HasRows) // if entered username and password have  data
                {
                    while (rd.Read()) // if reader can read 
                    {
                        int id = int.Parse(rd["id"].ToString());
                        if (rd["isAdmin"].ToString() == "1") // Truee for admin
                        {
                            // if it is true open form 2
                            Admin admin = new Admin();
                            string time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            admin.label1.Text = "WELCOME  a" + userID + " \n\nLogin Time:" + time + "";
                            admin.Show();
                            this.Hide();
                        }
                        else if (rd["isAdmin"].ToString() == "0" && id < 1000)
                        {
                            // Open student page
                            employee employee = new employee();
                            string time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            employee.label1.Text = "WELCOME  e" + userID + " \n\nLogin Time:" + time + "";

                            employee.Show();
                            this.Hide();
                        }
                        else {
                            Sportsman sportsman = new Sportsman();
                            string time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            sportsman.label1.Text = "WELCOME  s" + userID + " \n\nLogin Time:" + time + "";

                            sportsman.Show();
                            this.Hide();
                        }

                    }
                    
                }
          
                else // If reader cannot read
                {
                    rd.Close();
                    MessageBox.Show("Username or Password is not available", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    id.Clear();
                    password.Clear();

                }

                con.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Cannot reach database", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
