using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Domenici.App.GuidosLauncher
{
    public partial class PanelDoubleBuffered : Panel
    {
        public PanelDoubleBuffered()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

    }
}
