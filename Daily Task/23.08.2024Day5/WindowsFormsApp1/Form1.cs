using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(@"C:\Users\yuvaraj.b\source\repos\XmlProject\XmlProject\bin\Debug\net8.0\Courses.xml");
            //linq query
            var elets = from ele in doc.Descendants("Course")
                        where Convert.ToInt32(ele.Element("DurationInMonths").Value) > 1
                        select ele;
            foreach (var el in elets)
            {
                listBox2.Items.Add(el.Name + ":" + el.Value);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlReader xmlread = XmlReader.Create(@"C:\Users\yuvaraj.b\source\repos\XmlProject\XmlProject\bin\Debug\net8.0\Courses.xml");
            while (xmlread.Read())
            {
                switch (xmlread.NodeType)
                {
                    case XmlNodeType.Element:
                        listBox1.Items.Add("<" + xmlread.Name + ">");
                        break;
                    case XmlNodeType.Text:
                        listBox1.Items.Add(xmlread.Value);
                        break;
                    case XmlNodeType.EndElement:
                        listBox1.Items.Add("</Course>");
                        break;
                }
            }
        }
    }
}
