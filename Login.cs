using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ice_Cream
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "Data Source=MUSTAFA-ELSAWY\\SS17;Initial Catalog=Ice_Cream_Server;Integrated Security=True";
                SqlConnection myConn = new SqlConnection(myConnection);
                SqlCommand SelectCommand = new SqlCommand("select * from login where userName = '" + textBox1.Text + "' and passWord = " + int.Parse(textBox2.Text) + ";", myConn);
                SqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;

                while (myReader.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    /*this.Hide();
                    Form1 f1 = new Form1();
                    f1.ShowDialog();
                    */
                    this.Hide();
                    GUI2 m1 = new GUI2();
                    m1.ShowDialog();
                }
                else if (count > 1)
                {
                    MessageBox.Show("deplicate username and password");
                }
                else
                {
                    MessageBox.Show("username and password aren't correct.. please try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
