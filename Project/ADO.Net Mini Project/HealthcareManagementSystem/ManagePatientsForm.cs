using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HealthcareManagementSystem
{
    public partial class ManagePatientsForm : Form
    {
        public ManagePatientsForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Patients", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int pid=Convert.ToInt32(txtPId.Text);
            string name = txtName.Text.ToString();
            int age=Convert.ToInt32(txtAge.Text.ToString());
            string gender=txtGender.Text.ToString();
            string address=txtAddress.Text.ToString();
            string contact=txtContact.Text.ToString();
            SqlCommand cmd = new SqlCommand("insert into Patients values(@pid,@name,@age,@gender,@address,@contact)", con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert Successfully");
            con.Close();
        }

        private void ManagePatientsForm_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int pid = Convert.ToInt32(txtPId.Text);
            SqlCommand cmd = new SqlCommand("select * from Patients where PatientID=@pid", con);
            cmd.Parameters.AddWithValue("@pid", pid);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                txtPId.Text = sdr["PatientID"].ToString();
                txtName.Text = sdr["Name"].ToString();
                txtAge.Text = sdr["Age"].ToString();
                txtGender.Text = sdr["Gender"].ToString();
                txtAddress.Text = sdr["Address"].ToString();
                txtContact.Text = sdr["ContactInfo"].ToString();
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int pid = Convert.ToInt32(txtPId.Text);
            SqlCommand cmd = new SqlCommand("delete from Patients where PatientID=@pid", con);
            cmd.Parameters.AddWithValue("@pid", pid);
            SqlDataReader sdr = cmd.ExecuteReader();
            MessageBox.Show("Record deleted successfully");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int pid = Convert.ToInt32(txtPId.Text);
            string address= txtAddress.Text.ToString();
            SqlCommand cmd = new SqlCommand("update Patients set Address=@address where PatientID=@pid", con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@address", address);
            SqlDataReader sdr = cmd.ExecuteReader();
            MessageBox.Show("Record updated successfully");
            con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
