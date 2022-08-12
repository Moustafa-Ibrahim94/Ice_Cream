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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            */
            this.Hide();
            GUI2 m1 = new GUI2();
            m1.ShowDialog();
        }
        public string conn_name = "Data Source=MUSTAFA-ELSAWY\\SS17;Initial Catalog=Ice_Cream_Server;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlcmd = "insert into ice_cream values(@station_id,@date,@target_value)";
            SqlConnection conn = new SqlConnection(conn_name);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.Parameters.AddWithValue("@station_id", (textBox1.Text));
            cmd.Parameters.AddWithValue("@date",  DateTime.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@target_value", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();

            MessageBox.Show("Successfully Added");

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "XX123")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "2/14/2008")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "2/14/2008";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "44")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "XX123";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "44";
                textBox3.ForeColor = Color.Silver;
            }
        }
    }
}
