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
            //base.OnPaintBackground(e);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            double halfHeight = (double)Height / (float)2;
            Console.WriteLine("halfHeight-2={0}", (int)halfHeight - 2);

            Rectangle halfRectangle = new Rectangle(0, (int)halfHeight, Width, (int)halfHeight-2);
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
