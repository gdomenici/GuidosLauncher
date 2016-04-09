using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Domenici.App.GuidosLauncher
{
    public partial class SelectionHighlight : UserControl
    {
        public SelectionHighlight()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Don't call base.OnPaintBackground() because we want to
            // leave it transparent
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = (-1);

            if (m.Msg == WM_NCHITTEST)
            {
                // Pass all mouse events to underlying control
                // See http://stackoverflow.com/a/8635626/71791
                m.Result = (IntPtr)HTTRANSPARENT;
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int gradientHeight = Height / 2;

            Rectangle halfRectangle = new Rectangle(0, Height - gradientHeight -1, Width, gradientHeight);
            //Rectangle halfRectangle = this.ClientRectangle;
            LinearGradientBrush brush = new LinearGradientBrush(
                halfRectangle,
                Color.Transparent,
                Color.White,
                LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(brush, halfRectangle);

        }
    }
}
