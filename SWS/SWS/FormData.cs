using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace SWS
{
    public partial class FormData : Form
    {
        private Scraper scraper;
        private FormProgress fmpr2;
        private FormSettings fs;
        DataGridViewButtonColumn btn;

        public FormData()
        {
            InitializeComponent();
            dataGridViewData.RowHeadersVisible = false;
            dataGridViewLog.RowHeadersVisible = false;
        }

        private void FormData_Load(object sender, EventArgs e)
        {

        }

        public void DisplayMessage(string message)
        {
            dataGridViewLog.Rows.Add(DateTime.Now, message);
        }

        private void buttonParseData_Click(object sender, EventArgs e)
        {
            scraper = new Scraper();
            fmpr2 = new FormProgress();
            fs = new FormSettings();
            btn = new DataGridViewButtonColumn();

            fmpr2.Show();

            scraper.Notify += DisplayMessage;
            //asyncScrapeData(textBoxURL.Text);
            scraper.ScrapeData(fs.textBoxStartAdress.Text);

            foreach (var entries in scraper.Entries)
            {
                dataGridViewData.Rows.Add(entries.Number, entries.Title, entries.Type, entries.View, entries.Vote, entries.Rating, entries.Release, entries.Poster, entries.DateParse);
            }
            fmpr2.Close();


        }

        private void dataGridViewData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                FormViewPoster fm3 = new FormViewPoster();

                string imagePoster = dataGridViewData.CurrentRow.Cells[7].Value.ToString();
                WebRequest request = WebRequest.Create(imagePoster);

                try
                {
                    using (var responce = request.GetResponse())
                    {
                        using (var str = responce.GetResponseStream())
                        {
                            fm3.pictureBox1.Image = Bitmap.FromStream(str);
                            fm3.Text = dataGridViewData.CurrentRow.Cells[1].Value.ToString();
                        }
                    }
                    fm3.Show();
                }
                catch (Exception)
                {
                    DisplayMessage("Failed to load image.");
                }
                finally
                {
                    DisplayMessage($"{dataGridViewLog.CurrentRow.Cells[1].Value.ToString()}Image loaded successfully.");
                }
            }
        }

        private void dataGridViewData_DoubleClick(object sender, EventArgs e)
        {
            FormViewPoster fm3 = new FormViewPoster();

            string imagePoster = dataGridViewData.CurrentRow.Cells[7].Value.ToString();



            #region WebRequest
            //WebRequest request = WebRequest.Create(imagePoster);

            //try
            //{
            //    using (var responce = request.GetResponse())
            //    {
            //        using (var str = responce.GetResponseStream())
            //        {
            //            fm3.pictureBox1.Image = Bitmap.FromStream(str);
            //            fm3.Text = dataGridViewData.CurrentRow.Cells[1].Value.ToString();
            //        }
            //    }
            //    fm3.Show();
            //}
            //catch (WebException exc)
            //{
            //    DisplayMessage("Err: " + exc.Message);
            //    MessageBox.Show($"{exc.Message}", "Error",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning,
            //        MessageBoxDefaultButton.Button1,
            //        MessageBoxOptions.DefaultDesktopOnly);
            //}
            #endregion
        }

        private void buttonSaveDataTxt_Click(object sender, EventArgs e)
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
                        for (int i = 0; i < dataGridViewData.Rows.Count; i++)
                        {
                            for (int j = 1; j < dataGridViewData.Columns.Count; j++)
                            {
                                sw.Write(dataGridViewData.Rows[i].Cells[j].Value.ToString() + "|");
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

        private void buttonSaveDataExcel_Click(object sender, EventArgs e)
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

                for (int i = 0; i < dataGridViewData.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewData.Columns.Count; j++)
                    {
                        if (cellRowIndex == 1)
                        {
                            ws.Cells[cellRowIndex, cellColumnIndex] = dataGridViewData.Columns[j].HeaderText;
                        }
                        else
                        {
                            ws.Cells[cellRowIndex, cellColumnIndex] = dataGridViewData.Rows[i - 1].Cells[j].Value.ToString();
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
                    DisplayMessage($"Saved {savefile.FileName}");
                }
            }
            catch (Exception)
            {
                DisplayMessage("Error, file was not saved!");
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
