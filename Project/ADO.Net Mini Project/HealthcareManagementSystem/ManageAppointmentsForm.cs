using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace HealthcareManagementSystem
{
    public partial class ManageAppointmentsForm : Form
    {
        public ManageAppointmentsForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int aid = Convert.ToInt32(txtAId.Text);
            SqlCommand cmd = new SqlCommand("select * from Appointments where AppointmentID =@aid", con);
            cmd.Parameters.AddWithValue("@aid", aid);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                txtAId.Text = sdr["AppointmentID"].ToString();
                txtPId.Text = sdr["PatientID"].ToString();
                txtDId.Text = sdr["DoctorID"].ToString();
                AppDate.Value = Convert.ToDateTime(sdr["AppointmentDate"].ToString());
                AppTime.Value = Convert.ToDateTime(sdr["AppointmentTime"].ToString());
                txtStatus.Text = sdr["status"].ToString();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int aid=Convert.ToInt32(txtAId.Text);
            int pid=Convert.ToInt32(txtPId.Text);
            int did=Convert.ToInt32(txtDId.Text);
            DateTime date = AppDate.Value;
            DateTime time=AppTime.Value;
            string status=txtStatus.Text;
            SqlCommand cmd = new SqlCommand("insert into Appointments values(@aid,@pid,@did,@date,@time,@status)", con);
            cmd.Parameters.AddWithValue("@aid", aid);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert Successfully");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Appointments", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int aid = Convert.ToInt32(txtAId.Text);
            SqlCommand cmd = new SqlCommand("delete from Appointments where AppointmentID =@aid", con);
            cmd.Parameters.AddWithValue("@aid", aid);
            SqlDataReader sdr = cmd.ExecuteReader();
            MessageBox.Show("Record deleted successfully");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int aid = Convert.ToInt32(txtAId.Text);
            string status = txtStatus.Text.ToString();
            SqlCommand cmd = new SqlCommand("update Appointments set Status=@status where AppointmentID =@aid", con);
            cmd.Parameters.AddWithValue("@aid", aid);
            cmd.Parameters.AddWithValue("@status", status);
            SqlDataReader sdr = cmd.ExecuteReader();
            MessageBox.Show("Record updated successfully");
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            string s1 = "select count(*) from Appointments";
            SqlCommand cmd = new SqlCommand(s1, con);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            label7.Text = result.ToString();
        }
    }
}
