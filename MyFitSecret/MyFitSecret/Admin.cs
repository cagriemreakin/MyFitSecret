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
    public partial class Admin : Form
    {
        static MySqlConnection cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=963369");
        public Admin()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            addEmployee frm = new addEmployee();
            frm.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            showList();
            cnn.Close();


        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cnn.Open();
            showList();
            string query = "SELECT * from myfitsecret.employee where userID=@userID"; //Based on studentID,get the student informations

            MySqlCommand queryCommand = new MySqlCommand(query, cnn);
            queryCommand.Parameters.AddWithValue("@userID", textBox1.Text);  //send the text box value to studentID


            MySqlDataAdapter da = new MySqlDataAdapter(queryCommand);
            MySqlDataReader dr = queryCommand.ExecuteReader();//student data is sended to memory with datareader.

            if (dr.Read()) //if datareader can read anything
            {

                string name = dr["Name"].ToString();
                dr.Close();

                DialogResult answer = MessageBox.Show(" Are you sure to delete the record ?", "Approve Deletion", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == answer) // If the user selects the "Yes", the codes below runs to delete records
                {
                    string deleteQuery = "DELETE from myfitsecret.employee where userID=@userID";//sql command to delete student records

                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, cnn);
                    deleteCommand.Parameters.AddWithValue("@userID", textBox1.Text);

                    deleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Record is deleted...");

                }
            }
            else
                MessageBox.Show("No Record Found.");
            

            cnn.Close();


        }

        private void showList()
        {

            DataTable table = new DataTable();

            string showTable = "SELECT * from myfitsecret.employee";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand showCommand = new MySqlCommand();

            showCommand.Connection = cnn;
            showCommand.CommandText = showTable;

            adapter.SelectCommand = showCommand;
            adapter.Fill(table);

            dataGridView1.DataSource = table;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateEmployee frm = new updateEmployee();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnn.Open();
            DataTable tablo = new DataTable();
            string showTable = "SELECT * from myfitsecret.employee where userID=@userID";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand showCommand = new MySqlCommand();

            showCommand.Connection = cnn;
            showCommand.CommandText = showTable;
            showCommand.CommandType = CommandType.Text;
            showCommand.Parameters.AddWithValue("@userID", textBox1.Text);
            adapter.SelectCommand = showCommand;
            adapter.Fill(tablo);

            dataGridView1.DataSource = tablo;
            cnn.Close();
           

        }
    }
}
    

