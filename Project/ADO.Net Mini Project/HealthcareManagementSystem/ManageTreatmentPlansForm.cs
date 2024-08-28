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
    public partial class ManageTreatmentPlansForm : Form
    {
        public ManageTreatmentPlansForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int tid = Convert.ToInt32(txtTId.Text);
            int pid = Convert.ToInt32(txtPId.Text);
            int did = Convert.ToInt32(txtDId.Text);
            DateTime dStart = start.Value;
            DateTime dEnd = end.Value;
            string details = txtTDetails.Text;
            SqlCommand cmd = new SqlCommand("insert into TreatmentPlans values(@tid,@pid,@details,@dStart,@dEnd,@did)", con);
            cmd.Parameters.AddWithValue("@tid", tid);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Parameters.AddWithValue("@dStart", dStart);
            cmd.Parameters.AddWithValue("@dEnd", dEnd);
            cmd.Parameters.AddWithValue("@details", details);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert Successfully");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from TreatmentPlans", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int tid = Convert.ToInt32(txtTId.Text);
            SqlCommand cmd = new SqlCommand("delete from TreatmentPlans where TreatmentPlanID =@tid", con);
            cmd.Parameters.AddWithValue("@tid", tid);
            SqlDataReader sdr = cmd.ExecuteReader();
            MessageBox.Show("Record deleted successfully");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int tid = Convert.ToInt32(txtTId.Text);
            SqlCommand cmd = new SqlCommand("select * from TreatmentPlans where TreatmentPlanID =@tid", con);
            cmd.Parameters.AddWithValue("@tid", tid);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                txtTId.Text = sdr["TreatmentPlanID"].ToString();
                txtPId.Text = sdr["PatientID"].ToString();
                txtTDetails.Text = sdr["TreatmentDetails"].ToString();
                start.Value = Convert.ToDateTime(sdr["StartDate"].ToString());
                end.Value = Convert.ToDateTime(sdr["EndDate"].ToString());
                txtDId.Text = sdr["DoctorID"].ToString();

            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=HealthcareManagementSystem;integrated security=true;");
            con.Open();
            int tid = Convert.ToInt32(txtTId.Text);
            string details = txtTDetails.Text.ToString();
            SqlCommand cmd = new SqlCommand("update TreatmentPlans set TreatmentDetails=@details where TreatmentPlanID =@tid", con);
            cmd.Parameters.AddWithValue("@tid", tid);
            cmd.Parameters.AddWithValue("@details", details);
            SqlDataReader sdr = cmd.ExecuteReader();
            MessageBox.Show("Record updated successfully");
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
