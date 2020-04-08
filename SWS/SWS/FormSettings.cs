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

            textBoxPageStart.Text = FormMain.PageStart.ToString();
            textBoxPageEnd.Text = FormMain.PageEnd.ToString();
        }

        private void buttonSettingApply_Click(object sender, EventArgs e)
        {
            FormMain.PageStart = int.Parse(textBoxPageStart.Text);
            FormMain.PageEnd = int.Parse(textBoxPageEnd.Text);

            Close();
        }

        private void buttonSettingCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
