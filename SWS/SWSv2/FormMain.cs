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

        //public void Alert(string title, string message, FormAlert.enmType type)
        //{
        //    FormAlert frm = new FormAlert();
        //    frm.showAlert(title, message, type);
        //}

        FormMain fm = (FormMain)Application.OpenForms["FormMain"];
        FormDataGridView fdgv = new FormDataGridView();
        public void SetDataViewGrid(ObservableCollection<EntryModel> entryModel)
        {
            foreach (var item in entryModel)
            {
                fm.dataGridView2.Rows.Add(
                    item.Number,
                    item.Title,
                    item.Rating,
                    item.Vote,
                    item.titleList,
                    item.View,
                    item.Status,
                    item.Released,
                    item.Season,
                    item.ageRating,
                    item.genreList,
                    item.primarySource,
                    item.Studio,
                    item.Producer,
                    item.Type,
                    item.Series,
                    item.transfer,
                    item.voiceActing,
                    item.Description,
                    item.urlImage,
                    item.License);
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
            //Alert("Просмотров", $"{view}!", FormAlert.enmType.Success);
            fdgv.Show();
        }
    }
}