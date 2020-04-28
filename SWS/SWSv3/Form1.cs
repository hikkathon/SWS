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
            int startPoint = 1;
            int endPoint = 188;

            HtmlWeb web = new HtmlWeb();

            string[] url = { "http://web.archive.org/web/20140207223054/http://animevost.org/",
                             "http://web.archive.org/web/20151004104342/http://animevost.org:80/",
                             "http://web.archive.org/web/20160307084952/http://animevost.org/",
                             "http://web.archive.org/web/20170420165902/http://animevost.org/",
                             "http://web.archive.org/web/20180430213640/http://animevost.org/",
                             "http://web.archive.org/web/20190504202340/http://animevost.org/"};

            Invoke(new AddMessageDelegate(LogAdd), new object[] { "\n>" + DateTime.Now.ToString() + " " + "start" + Environment.NewLine });

                var html = url[4];

            for (int j = startPoint; j <= endPoint; j++)
            {
                Invoke(new AddMessageDelegate(LogAdd), new object[] { "\n>" + DateTime.Now.ToString() + " Scan Page: " + j + Environment.NewLine });
                if (j == 1)
                {
                    try
                    {
                        var htmlDoc = web.Load(html);
                        var posts = htmlDoc.DocumentNode.SelectNodes(".//div[@class='shortstory']");
                        foreach (var post in posts)
                        {
                            var title = post.SelectSingleNode(".//img[@class='imgRadius']")?.GetAttributeValue("alt", "") ?? "{null}";
                            var image = post.SelectSingleNode(".//img[@class='imgRadius']")?.GetAttributeValue("src", "") ?? "{null}";
                            var view = post.SelectSingleNode(".//span[@class='staticInfoRightSmotr']")?.InnerText ?? "0";
                            Invoke(new AddMessageDelegate(ShowTextBox), new object[] { title + Environment.NewLine });
                            Invoke(new ShowDataViewGridDelegate(ShowDataViewGrid), new object[] { title, image, view });
                        }
                    }
                    catch (IOException exc)
                    {
                        Invoke(new AddMessageDelegate(LogAdd), new object[] { "\n>" + DateTime.Now.ToString() + " " + exc + Environment.NewLine });
                    }
                    catch (NullReferenceException exc)
                    {
                        Invoke(new AddMessageDelegate(LogAdd), new object[] { "\n>" + DateTime.Now.ToString() + " " + exc + Environment.NewLine });
                    }
                }
                else
                {
                    try
                    {
                        var htmlDoc = web.Load(html + $"page/{j}/");
                        var posts = htmlDoc.DocumentNode.SelectNodes(".//div[@class='shortstory']");
                        foreach (var post in posts)
                        {
                            var title = post.SelectSingleNode(".//img[@class='imgRadius']")?.GetAttributeValue("alt", "");
                            var image = post.SelectSingleNode(".//img[@class='imgRadius']")?.GetAttributeValue("src", "");
                            var view = post.SelectSingleNode(".//span[@class='staticInfoRightSmotr']")?.InnerText;
                            Invoke(new AddMessageDelegate(ShowTextBox), new object[] { title + Environment.NewLine });
                            Invoke(new ShowDataViewGridDelegate(ShowDataViewGrid), new object[] { title, image, view });
                        }
                    }
                    catch (IOException exc)
                    {
                        Invoke(new AddMessageDelegate(LogAdd), new object[] { "\n>" + DateTime.Now.ToString() + " " + exc + Environment.NewLine });
                    }
                    catch (NullReferenceException exc)
                    {
                        Invoke(new AddMessageDelegate(LogAdd), new object[] { "\n>" + DateTime.Now.ToString() + " " + exc + Environment.NewLine });
                    }
                }
            }
            Invoke(new AddMessageDelegate(LogAdd), new object[] { "\n>" + DateTime.Now.ToString() + " " + "end" + Environment.NewLine });
        }

        private void btnStart_Click(object sender, EventArgs e)
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
    }
}
