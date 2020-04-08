using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWS
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            textBoxPageStart.Text = Form1.PageStart.ToString();
            textBoxPageEnd.Text = Form1.PageEnd.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.PageStart = int.Parse(textBoxPageStart.Text);
            Form1.PageEnd = int.Parse(textBoxPageEnd.Text);

            Close();
        }
    }
}
