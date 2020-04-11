using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Linq;
using System.Collections.Generic;

namespace SWS
{
    public partial class FormMain : Form
    {
        public static int PageStart = 1;
        public static int PageEnd = 2;
        public static string StartAdress = "https://yummyanime.club/catalog";

        private FormProgress fmpr2;
        private FormData fdata;
        private FormSettings fs;
        Scraper scraper;

        //public string TextBoxURL
        //{
        //    get
        //    {
        //        return textBoxURL.Text;
        //    }
        //    set
        //    {
        //        textBoxURL.Text = value;
        //    }
        //}

        public void DisplayMessage(string message)
        {
            fdata = new FormData();
            fdata.dataGridViewLog.Rows.Add(DateTime.Now, message);
        }

        public async void asyncScrapeData(string page)
        {
            fdata = new FormData();
            fmpr2.Show();

            await Task.Run(() => scraper.ScrapeData(page));

            foreach (var entries in scraper.Entries)
            {
                fdata.dataGridViewData.Rows.Add(entries.Number, entries.Title, entries.Type, entries.View, entries.Vote, entries.Rating, entries.Release, entries.Poster);
            }
            fmpr2.Close();
        }

        public FormMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void Form1_Load(object sender, EventArgs e)
        {
            //label3.Text = "The link can be copied from the address bar of the browser after applying the necessary filters on the site...\nExample: https://yummyanime.club/catalog";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void tXTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void csvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                DisplayMessage("Error, file was not saved!");
            }
        }

        private void xlsxToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_DoubleClick(object sender, EventArgs e)
        {
            //textBoxURL.Text = "https://yummyanime.club/catalog";
            //pictureBox2.Visible = true;
        }

        private void btnslide_Click(object sender, EventArgs e)
        {
                //MenuVertical.Width = 250;
                //btnslide.Visible = false;
                //btnslideClose.Visible = true;
        }

        private void iconsCloseWindow_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconsMaximizeWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconsRestoreWindow.Visible = true;
            iconsMaximizeWindow.Visible = false;
        }

        private void iconsRestoreWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconsRestoreWindow.Visible = false;
            iconsMaximizeWindow.Visible = true;
        }

        private void iconsMinimizeWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnslideClose_Click(object sender, EventArgs e)
        {
            //MenuVertical.Width = 100;
            //btnslide.Visible = true;
            //btnslideClose.Visible = false;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.PanelContented.Controls.Count > 0)
            {
                this.PanelContented.Controls.RemoveAt(0);
            }
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContented.Controls.Add(fh);
            fh.Show();

        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormSettings());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormData());
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormHelp());
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormAbout());
        }

        private void buttonDonate_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormDonate());
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {

        }
    }
}