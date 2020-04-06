using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWS
{
    public partial class Form1 : Form
    {
        Form2 fm2 = new Form2();
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
            fm2.Show();

            await Task.Run(() => scraper.ScrapeData(page));

            foreach (var entries in scraper.Entries)
            {
                dataGridView1.Rows.Add(entries.Number, entries.Title, entries.Type, entries.View, entries.Vote, entries.Rating, entries.Release, entries.Poster);                
            }
            fm2.Close();
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

        private  void button2_Click(object sender, EventArgs e)
        {
            scraper = new Scraper();

            //fm2.Show();
            scraper.Notify += DisplayMessage;
            //asyncScrapeData(textBoxURL.Text);
            scraper.ScrapeData(textBoxURL.Text);
            foreach (var entries in scraper.Entries)
            {
                dataGridView1.Rows.Add(entries.Number, entries.Title, entries.Type, entries.View, entries.Vote, entries.Rating, entries.Release, entries.Poster);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //fm2.Close();
        }
    }
}
