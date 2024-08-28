using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthcareManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagePatientsForm mpf=new ManagePatientsForm();

           mpf.ShowDialog();
           //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageTreatmentPlansForm mtf=new ManageTreatmentPlansForm();
            mtf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageAppointmentsForm maf = new ManageAppointmentsForm();
            maf.ShowDialog();
            //this.Hide();
        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
