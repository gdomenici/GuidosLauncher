using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Domenici.App.GuidosLauncher
{
    public partial class FormLauncher : Form
    {
        private int linkCount = 0;
        private List<LinkLabel> linkLabels = new List<LinkLabel>();
        
        public FormLauncher()
        {
            InitializeComponent();
            // Important - the below prevents flickering
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("GuidosLauncher.xml"))
            {
                MessageBox.Show("GuidosLauncher.xml not found - exiting");
                Application.Exit();
                return;
            }
            XDocument doc = null;
            using (FileStream fs = File.Open("GuidosLauncher.xml", FileMode.Open))
            {
                doc = XDocument.Load(fs);
            }
            int count = 0;
            int currY = 100;
            foreach (var oneProgram in doc.Element("programs").Elements("program"))
            {
                var labelElem = oneProgram.Element("label");
                string labelText = labelElem.Value;

                var pathElem = oneProgram.Element("path");
                string path = pathElem.Value;

                var argumentsElem = oneProgram.Element("arguments");
                string arguments = argumentsElem.Value;


                LinkLabel newLabel = new System.Windows.Forms.LinkLabel();
                SuspendLayout();
                // 
                // newLabel
                // 
                newLabel.AutoSize = true;
                newLabel.Font = new Font("Lucida Sans Unicode", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newLabel.LinkColor = Color.White;
                newLabel.Name = "newLabel" + count.ToString();
                newLabel.TabIndex = count;
                newLabel.TabStop = true;
                newLabel.Text = string.Format("{0} ↑ {1}", count + 1, labelText);
                int centerX = (this.Width - newLabel.Width) / 2;
                newLabel.Location = new Point(centerX, currY);
                newLabel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                newLabel.Dock = DockStyle.None;
                newLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(LabelClicked);
                newLabel.MouseEnter += new EventHandler(newLabel_MouseEnter);
                newLabel.MouseLeave += new EventHandler(newLabel_MouseLeave);
                newLabel.BackColor = Color.Transparent;
                newLabel.Tag = new LaunchItem
                {
                    LabelText = labelText,
                    Path = path,
                    Arguments = arguments
                };
                this.panel1.Controls.Add(newLabel);
                this.linkLabels.Add(newLabel);
                ResumeLayout(false);

                currY += newLabel.Height * 2;
                count++;
            }
            this.linkCount = count;
        }

        void newLabel_MouseLeave(object sender, EventArgs e)
        {
            LinkLabel theLabel = (LinkLabel)sender;
            theLabel.Text = theLabel.Text.Replace("→", "↑");
        }

        void newLabel_MouseEnter(object sender, EventArgs e)
        {
            LinkLabel theLabel = (LinkLabel)sender;
            theLabel.Text = theLabel.Text.Replace("↑", "→");
        }

        private void LabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel theLabel = (LinkLabel)sender;

            if (theLabel == linkLabelExit)
            {
                Application.Exit();
                return;
            }

            LaunchItem item = (LaunchItem)((LinkLabel)sender).Tag;
            string actualPath = Environment.ExpandEnvironmentVariables(item.Path);
            Process.Start(actualPath, item.Arguments);
        
        }

        private class LaunchItem
        {
            public string LabelText { get; set; }
            public string Path { get; set; }
            public string Arguments { get; set; }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char firstKey = (char)Keys.D1;
            char lastKey = (char)(firstKey + this.linkCount - 1);
            if (e.KeyChar >= firstKey && e.KeyChar <= lastKey)
            {
                int linkIndex = (int)(e.KeyChar - firstKey);
                LabelClicked(this.linkLabels[linkIndex], null);
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.D0)
            {
                LabelClicked(linkLabelExit, null);
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.Black,
                Color.Violet, LinearGradientMode.ForwardDiagonal);

            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }

        private void FormLauncher_Resize(object sender, EventArgs e)
        {
        }


        private void FormLauncher_Shown(object sender, EventArgs e)
        {
            SuspendLayout();

            var linkLabels = (
                from Control oneControl in panel1.Controls
                where oneControl is LinkLabel
                where oneControl != linkLabelExit // leave out the exceptional control
                select oneControl);

            int widestLabel = linkLabels.Max(oneLabel => { return oneLabel.Width; });
            LinkLabel firstLabel = null;
            foreach (LinkLabel oneLabel in linkLabels)
            {
                if (firstLabel == null)
                {
                    firstLabel = oneLabel;
                }
                // Left-aligned; only widest label is screen-centered
                int centerX = (this.panel1.Width - widestLabel) / 2;
                oneLabel.Left = centerX;
            }

            selectionHighlight1.Location = firstLabel.Location;
            selectionHighlight1.Size = firstLabel.Size;
            ResumeLayout(false);
        }


    }
}
