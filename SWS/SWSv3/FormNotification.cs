using SWSv3.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SWSv3
{
    public partial class FormNotification : Form
    {
        DateTime objDateTime = DateTime.Now;
        private void FormNotification_Load(object sender, EventArgs e)
        {
            lblTime.Text = "just now";
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int HeightEllipse
        );

        public FormNotification()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 5, 5));
            TopMost = true;
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Info,
            Warning,
            Success,
            Error
        }

        private FormNotification.enmAction action;

        private int x, y;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 900000;
                    action = enmAction.close;
                    break;

                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;

                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = TimeAgo.GetTimeSince(objDateTime).ToString();
        }

        public void showAlert(string title, string message, string song, enmType type)
        {
            SoundPlayer sp;
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 0; i < 15; i++)
            {
                fname = "alert" + i.ToString();
                FormNotification frm = (FormNotification)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - this.Size.Height;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 1;

            switch (type)
            {
                case enmType.Info:
                    //this.pictureBox1.Image = Resources.success;
                    this.panel2.BackColor = Color.FromArgb(51, 181, 229);
                    this.BackColor = Color.FromArgb(227, 227, 227);
                    sp = new SoundPlayer(song);
                    sp.Play();
                    break;
                case enmType.Warning:
                    //this.pictureBox1.Image = Resources.error;
                    this.panel2.BackColor = Color.FromArgb(255, 187, 51);
                    this.BackColor = Color.FromArgb(227, 227, 227);
                    sp = new SoundPlayer(song);
                    sp.Play();
                    break;
                case enmType.Success:
                    //this.pictureBox1.Image = Resources.info;
                    this.panel2.BackColor = Color.FromArgb(0, 200, 81);
                    this.BackColor = Color.FromArgb(227, 227, 227);
                    sp = new SoundPlayer(song);
                    sp.Play();
                    break;
                case enmType.Error:
                    //this.pictureBox1.Image = Resources.warning;
                    this.panel2.BackColor = Color.FromArgb(255, 53, 71);
                    this.BackColor = Color.FromArgb(227, 227, 227);
                    sp = new SoundPlayer(song);
                    sp.Play();
                    break;
            }

            this.lblMessage.Text = message;
            this.lblTitle.Text = title;

            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }
    }
}
