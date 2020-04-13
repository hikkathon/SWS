using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWSv2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public string TextBoxVal
        {
            get
            {
               return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        static async Task Start()
        {
            Scraper scraper = new Scraper();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "https://yummyanime.club/users/id13222");

                await scraper.GetContent(httpClient);
                //System.Threading.Thread.Sleep(4000);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() => Start());
        }
    }
}
