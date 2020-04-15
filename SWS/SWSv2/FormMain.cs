using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

        }

        public void SetDataViewGrid(ObservableCollection<EntryModel> entryModel)
        {
            FormMain fm = (FormMain)Application.OpenForms["FormMain"];
            foreach (var item in entryModel)
            {
                foreach (var list in item.titleList)
                {
                    fm.textBox1.Text += list.ToString() + Environment.NewLine;
                }
                fm.textBox1.Text += Environment.NewLine;
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}