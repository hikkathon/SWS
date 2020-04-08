using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace SWS
{
    public partial class FormMain : Form
    {
        public static int PageStart = 1;
        public static int PageEnd = 2;

        private FormProgress fmpr2;
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

        //public void DisplayMessage(string message)
        //{
        //    dataGridView2.Rows.Add(DateTime.Now, message);
        //}

        //public async void asyncScrapeData(string page)
        //{
        //    fmpr2.Show();

        //    await Task.Run(() => scraper.ScrapeData(page));

        //    foreach (var entries in scraper.Entries)
        //    {
        //        dataGridView1.Rows.Add(entries.Number, entries.Title, entries.Type, entries.View, entries.Vote, entries.Rating, entries.Release, entries.Poster);
        //    }
        //    fmpr2.Close();
        //}

        public FormMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    label3.Text = "The link can be copied from the address bar of the browser after applying the necessary filters on the site...\nExample: https://yummyanime.club/catalog";
        //    dataGridView1.RowHeadersVisible = false;
        //    dataGridView2.RowHeadersVisible = false;
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            //scraper = new Scraper();
            //fmpr2 = new FormProgress();
            //fmpr2.Show();

            //scraper.Notify += DisplayMessage;
            ////asyncScrapeData(textBoxURL.Text);
            //scraper.ScrapeData(textBoxURL.Text);

            //foreach (var entries in scraper.Entries)
            //{
            //    dataGridView1.Rows.Add(entries.Number, entries.Title, entries.Type, entries.View, entries.Vote, entries.Rating, entries.Release, entries.Poster, entries.DateParse);
            //}

            //fmpr2.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //FormViewPoster fm3 = new FormViewPoster();

            //string imagePoster = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            //WebRequest request = WebRequest.Create(imagePoster);

            //try
            //{
            //    using (var responce = request.GetResponse())
            //    {
            //        using (var str = responce.GetResponseStream())
            //        {
            //            fm3.pictureBox1.Image = Bitmap.FromStream(str);
            //            fm3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //        }
            //    }
            //    fm3.Show();
            //}
            //catch (Exception)
            //{
            //    DisplayMessage("Failed to load image.");
            //}
            //finally
            //{
            //    DisplayMessage($"{dataGridView1.CurrentRow.Cells[1].Value.ToString()}Image loaded successfully.");
            //}
        }

        private void tXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveFileDialog savefile = new SaveFileDialog();
                //savefile.DefaultExt = ".txt";
                //savefile.FileName = $"{DateTime.Now.ToLocalTime().ToString().Replace(":", "-").Replace(".", "-")}";
                //savefile.Filter = "Text files (*.txt)|*.txt";

                //if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK && savefile.FileName.Length > 0)
                //{
                //    using (StreamWriter sw = new StreamWriter(savefile.FileName, true))
                //    {
                //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //        {
                //            for (int j = 1; j < dataGridView1.Columns.Count; j++)
                //            {
                //                sw.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "|");
                //            }
                //            sw.Write("|");
                //        }
                //        sw.Close();
                //        DisplayMessage($"Saved {savefile.FileName}");
                //    }
                //}
            }
            catch (Exception)
            {
                //DisplayMessage("Error, file was not saved!");
            }
        }

        private void csvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                //DisplayMessage("Error, file was not saved!");
            }
        }

        private void xlsxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet ws = null;

            try
            {
                ws = wb.ActiveSheet;
                ws.Name = $"{DateTime.Now.ToShortDateString()}";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                //    {
                //        if (cellRowIndex == 1)
                //        {
                //            ws.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Columns[j].HeaderText;
                //        }
                //        else
                //        {
                //            ws.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Rows[i - 1].Cells[j].Value.ToString();
                //        }
                //        cellColumnIndex++;
                //    }
                //    cellColumnIndex = 1;
                //    cellRowIndex++;
                //}

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.DefaultExt = ".xlsx";
                savefile.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                savefile.FilterIndex = 2;
                savefile.FileName = $"{DateTime.Now.ToLocalTime().ToString().Replace(":", "-").Replace(".", "-")}";

                if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    wb.SaveAs(savefile.FileName);
                    //DisplayMessage($"Saved {savefile.FileName}");
                }
            }
            catch (Exception)
            {
                //DisplayMessage("Error, file was not saved!");
            }
            finally
            {
                excel.Quit();
                wb = null;
                excel = null;
            }
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
    }
}