using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWSv3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            #region ProgressBar
            int counter = 0;
            int rowMax = 10000;
            int colMax = 10000;
            decimal pcdDone;
            groupBox_Loading.Visible = true;
            for (int i = 0; i < rowMax; i++)
            {
                btnStart.Enabled = false;
                for (int j = 0; j < colMax; j++)
                {
                    counter++;
                }
                pcdDone = (decimal)counter / (rowMax * colMax);
                //groupBox1.Text = ((int)(pcdDone * 100)).ToString() + " %";
                groupBox_Loading.Refresh();

                label_Loading.Width = Convert.ToInt32(pcdDone * (groupBox_Loading.Width - 10));
            }
            groupBox_Loading.Visible = false;
            btnStart.Enabled = true;
            #endregion

            await Task.Run(() => 
            {
                var html = @"http://html-agility-pack.net/";

                HtmlWeb web = new HtmlWeb();

                var htmlDoc = web.Load(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

                // Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);
                MessageBox.Show(node.OuterHtml, "Node Name: " + node.Name,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.DefaultDesktopOnly);
            });
        }
    }
}
