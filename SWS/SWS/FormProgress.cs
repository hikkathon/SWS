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
    public partial class FormProgress : Form
    {
        #region Property progressBar1
        public  int ProgressBarMin
        {
            get
            {
               return progressBar1.Minimum;
            }
            set
            {
                progressBar1.Minimum = value;
            }
        }

        public int ProgressBarMax
        {
            get
            {
                return progressBar1.Maximum;
            }
            set
            {
                progressBar1.Maximum = value;
            }
        }

        public int ProgressBarValue
        {
            get
            {
                return progressBar1.Value;
            }
            set
            {
                progressBar1.Value = value;
            }
        }
        #endregion

        public FormProgress()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
