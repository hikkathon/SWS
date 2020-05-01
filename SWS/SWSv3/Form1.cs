using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SWSv3
{
    public partial class Form1 : Form
    {
        FormLog fl = new FormLog();

        public Form1()
        {
            InitializeComponent();
        }

        public delegate void AddMessageDelegate(string message);
        public delegate void ShowDataViewGridDelegate(string title,string image,string view);

        public void LogAdd(string message)
        {
            fl.textBoxLog.AppendText(message);
        }
        public void ShowTextBox(string message)
        {
            //textBox1.AppendText(message);
        }
        public void ShowDataViewGrid(string title, string image,string view)
        {
            dataGridView1.Rows.Add(title, image,view);
        }

        public void StartParse()
        {
            int startPoint = Convert.ToInt32(toolStripTextBoxPointStart.Text);
            int endPoint = Convert.ToInt32(toolStripTextBoxPointEnd.Text);

            int counter = 0;

            HtmlWeb web = new HtmlWeb();

            Invoke(new AddMessageDelegate(LogAdd), new object[] { "[" + DateTime.Now.ToString() + "]" + " " + "start" + Environment.NewLine });

                var html = toolStripTextBoxURL.Text;

            for (int j = startPoint; j <= endPoint; j++)
            {
                Invoke(new AddMessageDelegate(LogAdd), new object[] { "[" + DateTime.Now.ToString() + "]" + " Scan Page: " + j});
                if (j == 1)
                {
                    try
                    {
                        var htmlDoc = web.Load(html);
                        var posts = htmlDoc.DocumentNode.SelectNodes(".//div[@class='shortstory']");
                        foreach (var post in posts)
                        {
                            counter++;
                            var title = post.SelectSingleNode(".//img[@class='imgRadius']")?.GetAttributeValue("alt", "") ?? "{null}";
                            var image = post.SelectSingleNode(".//img[@class='imgRadius']")?.GetAttributeValue("src", "") ?? "{null}";
                            var view = post.SelectSingleNode(".//span[@class='staticInfoRightSmotr']")?.InnerText ?? "0";
                            Invoke(new AddMessageDelegate(ShowTextBox), new object[] { title + Environment.NewLine });
                            Invoke(new ShowDataViewGridDelegate(ShowDataViewGrid), new object[] { title, image, view });
                        }
                    }
                    catch (IOException exc)
                    {
                        Invoke(new AddMessageDelegate(LogAdd), new object[] { Environment.NewLine+"[" + DateTime.Now.ToString() + "]" + " " + exc + Environment.NewLine });
                    }
                    catch (NullReferenceException exc)
                    {
                        Invoke(new AddMessageDelegate(LogAdd), new object[] { Environment.NewLine+"[" + DateTime.Now.ToString() + "]" + " " + exc + Environment.NewLine });
                    }
                }
                else
                {
                    try
                    {
                        Thread.Sleep(5000);
                        var htmlDoc = web.Load(html + $"page/{j}/");
                        var posts = htmlDoc.DocumentNode.SelectNodes(".//div[@class='shortstory']");
                        foreach (var post in posts)
                        {
                            counter++;
                            var title = post.SelectSingleNode(".//img[@class='imgRadius']")?.GetAttributeValue("alt", "");
                            var image = post.SelectSingleNode(".//img[@class='imgRadius']")?.GetAttributeValue("src", "");
                            var view = post.SelectSingleNode(".//span[@class='staticInfoRightSmotr']")?.InnerText;
                            Invoke(new AddMessageDelegate(ShowTextBox), new object[] { title + Environment.NewLine });
                            Invoke(new ShowDataViewGridDelegate(ShowDataViewGrid), new object[] { title, image, view });
                        }
                    }
                    catch (IOException exc)
                    {
                        Invoke(new AddMessageDelegate(LogAdd), new object[] { Environment.NewLine+"[" + DateTime.Now.ToString() + "]" + " " + exc + Environment.NewLine });
                    }
                    catch (NullReferenceException exc)
                    {
                        Invoke(new AddMessageDelegate(LogAdd), new object[] { Environment.NewLine+"[" + DateTime.Now.ToString() + "]" + " " + exc + Environment.NewLine });
                    }
                }
                Invoke(new AddMessageDelegate(LogAdd), new object[] { "\tDONE!" + Environment.NewLine });
            }
            Invoke(new AddMessageDelegate(LogAdd), new object[] { "[" + DateTime.Now.ToString() + "]"+ " " + "end" + Environment.NewLine });
            Invoke(new AddMessageDelegate(LogAdd), new object[] { "["+DateTime.Now.ToString()+"]" + " " + $"Найдено {counter} аниме" + Environment.NewLine });
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            #region ProgressBar
            //int counter = 0;
            //int rowMax = 10000;
            //int colMax = 10000;
            //decimal pcdDone;
            //groupBox_Loading.Visible = true;
            //for (int i = 0; i < rowMax; i++)
            //{
            //    btnStart.Enabled = false;
            //    for (int j = 0; j < colMax; j++)
            //    {
            //        counter++;
            //    }
            //    pcdDone = (decimal)counter / (rowMax * colMax);
            //    groupBox1.Text = ((int)(pcdDone * 100)).ToString() + " %";
            //    groupBox_Loading.Refresh();

            //    label_Loading.Width = Convert.ToInt32(pcdDone * (groupBox_Loading.Width - 10));
            //}
            //groupBox_Loading.Visible = false;
            //btnStart.Enabled = true;
            #endregion
            fl.Show();
            Task task = new Task(() => StartParse());
            task.Start();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
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

                for (int i = 0; i < dataGridView1.Rows.Count + 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (cellRowIndex == 1)
                        {
                            ws.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Columns[j].HeaderText;
                        }
                        else
                        {
                            ws.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Rows[i - 1].Cells[j].Value.ToString();
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
                    Invoke(new AddMessageDelegate(LogAdd), new object[] { "[" + DateTime.Now.ToString() + "]" + " " + "Файл сохранен в формате Excel (.xlsx)" + Environment.NewLine });
                }
            }
            catch (Exception)
            {
                Invoke(new AddMessageDelegate(LogAdd), new object[] { "[" + DateTime.Now.ToString() + "]" + " " + "При сохранении файла что то пошло не так." + Environment.NewLine });
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
