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
            dataGridView2.Visible = false;
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
                    item.alternativeTitle,
                    item.View,
                    item.Status,
                    item.Released,
                    item.Season,
                    item.ageRating,
                    item.Genre,
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
            }
        }

        static async Task Start()
        {
            Scraper scraper = new Scraper();
            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "https://yummyanime.club");
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
                //httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");

                await scraper.GetContent(httpClient);
                //System.Threading.Thread.Sleep(4000);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() => Start());
            dataGridView2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Alert("Просмотров", $"{view}!", FormAlert.enmType.Success);
            fdgv.Show();
        }
    }
}