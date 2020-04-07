using CsvHelper;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWS
{
    public partial class Form1 : Form
    {
        private FormProgress fmpr2;
        Scraper scraper;

        public string TextBoxURL
        {
            get
            {
                return textBoxURL.Text;
            }
            set
            {
                textBoxURL.Text = value;
            }
        }

        public void DisplayMessage(string message)
        {
            dataGridView2.Rows.Add(DateTime.Now, message);
        }

        public async void asyncScrapeData(string page)
        {
            fmpr2.Show();

            await Task.Run(() => scraper.ScrapeData(page));

            foreach (var entries in scraper.Entries)
            {
                dataGridView1.Rows.Add(entries.Number, entries.Title, entries.Type, entries.View, entries.Vote, entries.Rating, entries.Release, entries.Poster);
            }
            fmpr2.Close();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "The link can be copied from the address bar of the browser after applying the necessary filters on the site...\nExample: https://yummyanime.club/catalog";
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scraper = new Scraper();
            fmpr2 = new FormProgress();
            fmpr2.Show();

            scraper.Notify += DisplayMessage;
            //asyncScrapeData(textBoxURL.Text);
            scraper.ScrapeData(textBoxURL.Text);

            foreach (var entries in scraper.Entries)
            {
                dataGridView1.Rows.Add(entries.Number, entries.Title, entries.Type, entries.View, entries.Vote, entries.Rating, entries.Release, entries.Poster);
            }
            fmpr2.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FormViewPoster fm3 = new FormViewPoster();

            string imagePoster = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            WebRequest request = WebRequest.Create(imagePoster);

            using (var responce = request.GetResponse())
            {
                using (var str = responce.GetResponseStream())
                {
                    fm3.pictureBox1.Image = Bitmap.FromStream(str);
                    fm3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                }
            }
            fm3.Show();
        }

        private void tXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.DefaultExt = ".txt";
                savefile.Filter = "SWS|*.txt";

                if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK && savefile.FileName.Length > 0)
                {
                    using (StreamWriter sw = new StreamWriter(savefile.FileName, true))
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 1; j < dataGridView1.Columns.Count; j++)
                            {
                                sw.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "|");
                            }
                            sw.Write("|");
                        }
                        sw.Close();
                        DisplayMessage($"Saved {savefile.FileName}");
                    }
                }
            }
            catch (Exception)
            {
                DisplayMessage("Error, file was not saved!");
            }
        }

        private void csvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.DefaultExt = ".csv";
                savefile.Filter = "SWS|*.csv";

                if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK && savefile.FileName.Length > 0)
                {
                    using (StreamWriter sw = new StreamWriter(savefile.FileName, true))
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 1; j < dataGridView1.Columns.Count; j++)
                            {
                                sw.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "|");
                            }
                            sw.Write(";");
                        }
                        sw.Close();
                        DisplayMessage($"Saved {savefile.FileName}");
                    }
                }
            }
            catch (Exception)
            {

                DisplayMessage("Error, file was not saved!");
            }
        }
    }
}