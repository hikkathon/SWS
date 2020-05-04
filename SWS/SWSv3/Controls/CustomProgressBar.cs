using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SWSv3.Controls
{
    public class CustomProgressBar : Control
    {
        #region Variables

        #endregion

        #region Properties
        public Color BorderColor { get; set; } = FlatColors.GrayDark;
        public Color BackColorProgress { get; set; } = FlatColors.Green;

        private int _value = 0;
        public int Value
        {
            get => _value;
            set
            {
                if (value >= ValueMinimum && value <= ValueMinimum)
                {
                    _value = value;
                    Invalidate();
                }
                else
                {
                    value = _value;
                }
            }
        }

        private int _valueMinimum = 0;
        public int ValueMinimum 
        {
            get => _valueMinimum;
            set
            {
                if (value < ValueMaximum)
                {
                    _valueMinimum = value;

                    if (_valueMinimum > Value)
                    {
                        Value = _valueMinimum;
                        Invalidate();
                    }
                }
                else
                {
                    value = _valueMinimum;
                }
            }
        }

        private int _valueMaximum = 100;
        public int ValueMaximum
        {
            get => _valueMaximum;
            set
            {
                if (value > ValueMinimum)
                {
                    _valueMaximum = value;
                    Invalidate();
                }
                else
                {
                    value = _valueMaximum;
                }
            }
        }

        public int Step { get; set; }
        #endregion

        public CustomProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(200, 20);

            BackColor = FlatColors.Blue;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;

            graph.Clear(Parent.BackColor);

            Rectangle rectBase = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle rectProgress = new Rectangle(rectBase.X + 1, rectBase.Y + 1, CalculateProgressRectSize(rectBase), rectBase.Height - 2);

            // Draw base
            DrawBase(graph, rectBase);
            // Draw progress
            DrawProgress(graph, rectProgress);
        }

        private int CalculateProgressRectSize(Rectangle rect)
        {
            int margin = ValueMaximum - ValueMinimum;
            return rect.Width * Value / margin;
        }

        #region Draw object
        private void DrawBase(Graphics graph, Rectangle rect)
        {
            graph.DrawRectangle(new Pen(BorderColor), rect);
            graph.FillRectangle(new SolidBrush(BackColor), rect);
        }
        private void DrawProgress(Graphics graph, Rectangle rect)
        {
            graph.DrawRectangle(new Pen(BackColorProgress), rect);
            graph.FillRectangle(new SolidBrush(BackColorProgress), rect);
        }
        #endregion

        #region Public Method
        public bool PerformStep()
        {
            if (Value < ValueMaximum)
            {
                if (Value + Step >= ValueMaximum)
                {
                    Value = ValueMaximum;
                    return false;
                }
                else
                {
                    Value += Step;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public void ResetProgress()
        {
            Value = ValueMinimum;
        }
        #endregion
    }
}