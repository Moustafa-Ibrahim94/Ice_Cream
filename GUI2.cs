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
    public partial class GUI2 : Form
    {
        public static int x = 1;
        public GUI2()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            /*this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            */
            this.Hide();
            Maintenance m1 = new Maintenance();
            m1.ShowDialog();


        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            GUI2 f4 = new GUI2();
            f4.ShowDialog();
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            GUI3 f5 = new GUI3();
            f5.ShowDialog();
        }

        public string conn_name = "Data Source=MUSTAFA-ELSAWY\\SS17;Initial Catalog=Ice_Cream_Server;Integrated Security=True";

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conn_name);

            SqlCommand cmd = new SqlCommand("Select * from ice_cream", conn);

            SqlDataAdapter data = new SqlDataAdapter();
            data.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            data.Fill(table1);

            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "station_id";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlcmd = @"select * from ice_cream where station_id = '" + comboBox1.Text.ToString() + "'";
            SqlConnection conn = new SqlConnection(conn_name);
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);

            SqlDataReader myreader;
            conn.Open();
            myreader = cmd.ExecuteReader();
            myreader.Read();

            textBox1.Text = myreader.GetString(0);
            textBox2.Text = myreader["date"].ToString();
            textBox3.Text = myreader["target_value"].ToString();
            conn.Close();
            int Actual;
            try
            {
                Actual = int.Parse(textBox4.Text);
                textBox5.Text = (Actual - int.Parse(textBox3.Text)).ToString();
                if (int.Parse(textBox5.Text) >= int.Parse(textBox3.Text) * 0.05)
                {
                    textBox5.ForeColor = System.Drawing.Color.Green;
                }
                else if (int.Parse(textBox5.Text) <= int.Parse(textBox3.Text) * -0.1)
                {
                    textBox5.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    textBox5.ForeColor = System.Drawing.Color.Black;
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Please Enter Actual Value");
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlcmd = @"select * from ice_cream where station_id = '" + comboBox1.Text.ToString() + "'";
            SqlConnection conn = new SqlConnection(conn_name);
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);

            SqlDataReader myreader;
            conn.Open();
            myreader = cmd.ExecuteReader();
            try
            {
                while (myreader.Read())
                {
                    textBox1.Text = myreader.GetString(0);
                    textBox2.Text = myreader["date"].ToString();
                    textBox3.Text = myreader["target_value"].ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid Operation");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String sqlcmd = @"UPDATE ice_cream SET date = CAST('" + textBox2.Text.ToString() + "' AS DATETIME), target_value = '" + textBox3.Text.ToString() + "' WHERE station_id = '" + textBox1.Text.ToString().Trim() + "'";
                SqlConnection conn = new SqlConnection(conn_name);
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                SqlDataReader myreader;
                conn.Open();
                myreader = cmd.ExecuteReader();
                MessageBox.Show("successfully Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Station ID"); ;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                String sqlcmd = @"DELETE FROM ice_cream WHERE station_id = '" + textBox1.Text.ToString().Trim() + "'";
                SqlConnection conn = new SqlConnection(conn_name);
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                SqlDataReader myreader;
                conn.Open();
                myreader = cmd.ExecuteReader();
                MessageBox.Show("successfully Deleted");
                this.Hide();
                GUI2 f1 = new GUI2();
                f1.ShowDialog();
            }
            catch (Exception)
            {

                MessageBox.Show("Sorry, Erorr 404");
            }
        }
    }
}
