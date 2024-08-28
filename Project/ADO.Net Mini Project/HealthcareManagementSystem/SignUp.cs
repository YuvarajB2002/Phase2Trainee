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

namespace HealthcareManagementSystem
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn sin = new SignIn();
            sin.ShowDialog();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            string name = txtName.Text.ToString();
            string email = txtEmail.Text.ToString();
            string pwd = txtPwd.Text.ToString();
            string cpwd = txtCpwd.Text.ToString();
            if (pwd.Equals(cpwd))
            {
                SqlCommand cmd = new SqlCommand("insert into SignUp values(@name,@email,@pwd,@cpwd)", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                cmd.Parameters.AddWithValue("@cpwd", cpwd);
                cmd.ExecuteNonQuery();
                SignIn sin=new SignIn();
                sin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Password and Confirm Password must be same");
            }
            
            con.Close();
        }
    }
}
