using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ADOWindowApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=Sports_yuva;integrated security=true;");
            con.Open();
            string s1 = "select * from Product1";
            SqlCommand cmd = new SqlCommand(s1, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=Sports_yuva;integrated security=true;");
            con.Open();
            int id=Convert.ToInt32(txtId.Text);
            string name = txtName.Text.ToString();
            int price = Convert.ToInt32(txtPrice.Text);
            SqlCommand cmd = new SqlCommand("insert into Product1 values(@id,@name,@price)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert Successfully");
            con.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=Sports_yuva;integrated security=true;");
            con.Open();
            int id= Convert.ToInt32(txtId.Text);
            int price= Convert.ToInt32(txtPrice.Text);
            string s1 = "update Product1 set Price=@price where ProId=@id";
            SqlCommand cmd = new SqlCommand(s1, con);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Price Updated successfully");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=Sports_yuva;integrated security=true;");
            con.Open();
            int id = Convert.ToInt32(txtId.Text);
            string s1 = "select * from Product1 where ProId=@id";
            SqlCommand cmd = new SqlCommand(s1, con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                txtId.Text = sdr["ProId"].ToString();
                txtName.Text = sdr["ProName"].ToString();
                txtPrice.Text = sdr["Price"].ToString();
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=Sports_yuva;integrated security=true;");
            con.Open();
            int id = Convert.ToInt32(txtId.Text);
            string s = "delete from Product1 where ProId=@id";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("One records deleted successfully");
            con.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=Sports_yuva;integrated security=true;");
            con.Open();
            string s1 = "select count(*) from Product1";
            SqlCommand cmd = new SqlCommand(s1, con);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            label4.Text = result.ToString();
        }
    }
}
