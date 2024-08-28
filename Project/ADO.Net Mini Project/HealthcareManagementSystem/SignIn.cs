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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HealthcareManagementSystem
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            string name=txtName.Text.ToString();
            string pwd=txtPwd.Text.ToString();
            string originalpwd = VerifyPassword(name);
            if (pwd.Equals(originalpwd))
            {
                SqlCommand cmd = new SqlCommand("insert into SignIn values(@name,@pwd)", con);
                cmd.Parameters.AddWithValue("@name", name);
            
                cmd.Parameters.AddWithValue("@pwd", pwd);
                
                cmd.ExecuteNonQuery();
               MainForm mf=new MainForm();
                mf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Password");
            }
        }
        public static string VerifyPassword(string userName)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Password from SignUp where UserName=@name", con);
            cmd.Parameters.AddWithValue("@name", userName);
            SqlDataReader sdr = cmd.ExecuteReader();
            String result="";
            while (sdr.Read())
            {
                result = sdr["Password"].ToString();
            }
            con.Close();
            return result;
        }
    }
}
