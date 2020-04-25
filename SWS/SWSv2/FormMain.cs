using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            btnSaveXLSX.Visible = false;
            btnSaveTXT.Visible = false;
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
                    item.License,
                    item.linkAnime);
            }
        }

        static async Task Start()
        {
            Scraper scraper = new Scraper();
            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "https://yummyanime.club");
                //httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");

                await scraper.GetContent(httpClient);
                //System.Threading.Thread.Sleep(4000);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            await Task.Run(() => Start());
            dataGridView2.Visible = true;
            btnSaveXLSX.Visible = true;
            btnSaveTXT.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Alert("Просмотров", $"{view}!", FormAlert.enmType.Success);
            fdgv.Show();
        }

        private void btnSaveTXT_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.DefaultExt = ".txt";
                savefile.FileName = $"{DateTime.Now.ToLocalTime().ToString().Replace(":", "-").Replace(".", "-")}";
                savefile.Filter = "Text files (*.txt)|*.txt";

                if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK && savefile.FileName.Length > 0)
                {
                    using (StreamWriter sw = new StreamWriter(savefile.FileName, true))
                    {
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            for (int j = 1; j < dataGridView2.Columns.Count; j++)
                            {
                                sw.Write(dataGridView2.Rows[i].Cells[j].Value.ToString() + "|");
                            }
                            sw.Write("|");
                        }
                        sw.Close();
                        MessageBox.Show($"Успех", "Сохранение успешно",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning,
                                   MessageBoxDefaultButton.Button1,
                                   MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Облом", "Сохранение не успешно",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnSaveXLSX_Click(object sender, EventArgs e)
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

                for (int i = 0; i < dataGridView2.Rows.Count+1; i++)
                {
                    for (int j = 0; j < dataGridView2.Columns.Count; j++)
                    {
                        if (cellRowIndex == 1)
                        {
                            ws.Cells[cellRowIndex, cellColumnIndex] = dataGridView2.Columns[j].HeaderText;
                        }
                        else
                        {
                            ws.Cells[cellRowIndex, cellColumnIndex] = dataGridView2.Rows[i - 1].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.DefaultExt = ".xlsx";
                savefile.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                savefile.FilterIndex = 2;
                savefile.FileName = $"{DateTime.Now.ToLocalTime().ToString().Replace(":", "-").Replace(".", "-")}";

                if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    wb.SaveAs(savefile.FileName);
                    MessageBox.Show($"Успех!", $"Сохранение успешно\n путь: {savefile.FileName}",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Облом!", $"Сохранение не успешно",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
            finally
            {
                excel.Quit();
                wb = null;
                excel = null;
            }
        }
    }
}