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
        private enum LinkColumn
        { 
            Middle,
            Right
        }

        private Dictionary<LinkColumn, List<LinkLabel>> linkLabels = new Dictionary<LinkColumn, List<LinkLabel>>();
        private LinkLabel selectedLinkLabel = null;
        private LinkColumn selectedColumn = LinkColumn.Middle;
        
        public FormLauncher()
        {
            InitializeComponent();
            // Important - the below prevents flickering
            this.DoubleBuffered = true;
        }

        private void FormLauncher_Load(object sender, EventArgs e)
        {
            if (!File.Exists("GuidosLauncher.xml"))
            {
                MessageBox.Show("GuidosLauncher.xml not found - exiting");
                Application.Exit();
                return;
            }
            XDocument doc = null;
            using (FileStream fs = File.Open("GuidosLauncher.xml", FileMode.Open, FileAccess.Read))
            {
                doc = XDocument.Load(fs);
            }
            int count = 0;
            int currY = 100;
            this.linkLabels[LinkColumn.Middle] = new List<LinkLabel>();
            foreach (var oneProgram in doc.Element("programs").Elements("program"))
            {
                var labelElem = oneProgram.Element("label");
                string labelText = labelElem.Value;

                var pathElem = oneProgram.Element("path");
                string path = pathElem.Value;

                var argumentsElem = oneProgram.Element("arguments");
                string arguments = argumentsElem.Value;


                LinkLabel newLabel = new LinkLabel();
                SuspendLayout();
                // 
                // newLabel
                // 
                newLabel.AutoSize = true;
                newLabel.Font = new Font("Lucida Sans Unicode", 36F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                newLabel.LinkColor = Color.White;
                newLabel.Name = "newLabel" + count.ToString();
                newLabel.TabIndex = count;
                newLabel.TabStop = true;
                newLabel.Text = string.Format("{0} ↑ {1}", count + 1, labelText);
                newLabel.LinkBehavior = LinkBehavior.HoverUnderline;
                int centerX = (this.Width - newLabel.Width) / 2;
                newLabel.Location = new Point(centerX, currY);
                newLabel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                newLabel.Dock = DockStyle.None;
                newLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(LabelClicked);
                newLabel.MouseEnter += new EventHandler(newLabel_MouseEnter);
                newLabel.BackColor = Color.Transparent;
                newLabel.Tag = new LaunchItem
                {
                    LabelText = labelText,
                    Path = path,
                    Arguments = arguments
                };
                this.panel1.Controls.Add(newLabel);
                this.linkLabels[LinkColumn.Middle].Add(newLabel);
                ResumeLayout(false);

                currY += newLabel.Height * 2;
                count++;
            }
            this.selectedColumn = LinkColumn.Middle;

            this.linkLabels[LinkColumn.Right] = new List<LinkLabel>();
            this.linkLabels[LinkColumn.Right].Add(linkLabelExit);

        }

        void newLabel_MouseEnter(object sender, EventArgs e)
        {
            LinkLabel theLabel = (LinkLabel)sender;
            this.SelectedLinkLabel = theLabel;
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

        private void FormLauncher_KeyPress(object sender, KeyPressEventArgs e)
        {
            char firstKey = (char)Keys.D1;
            char lastKey = (char)(firstKey + this.linkLabels[selectedColumn].Count - 1);
            if (e.KeyChar >= firstKey && e.KeyChar <= lastKey)
            {
                int linkIndex = (int)(e.KeyChar - firstKey);
                LabelClicked(this.linkLabels[selectedColumn][linkIndex], null);
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.D0)
            {
                // zero
                LabelClicked(linkLabelExit, null);
                e.Handled = true;
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



        private void FormLauncher_Shown(object sender, EventArgs e)
        {
            SuspendLayout();
            try
            {
                int widestLabel = linkLabels[LinkColumn.Middle].Max(oneLabel => { return oneLabel.Width; });
                LinkLabel firstLabel = null;
                foreach (LinkLabel oneLabel in linkLabels[LinkColumn.Middle])
                {
                    if (firstLabel == null)
                    {
                        firstLabel = oneLabel;
                    }
                    // Left-aligned; only widest label is screen-centered
                    int centerX = (this.panel1.Width - widestLabel) / 2;
                    oneLabel.Left = centerX;
                }
                this.SelectedLinkLabel = firstLabel;

            }
            finally
            {
                ResumeLayout(false);
            } 
        }

        public LinkLabel SelectedLinkLabel
        {
            get
            {
                return this.selectedLinkLabel;                
            }
            set
            {
                LinkLabel prevSelected = this.selectedLinkLabel;
                if (prevSelected != null)
                {
                    prevSelected.Text = prevSelected.Text.Replace("→", "↑");
                }

                this.selectedLinkLabel = value;
                selectionHighlight1.Location = this.selectedLinkLabel.Location;
                selectionHighlight1.Size = this.selectedLinkLabel.Size;
                this.selectedLinkLabel.Text = this.selectedLinkLabel.Text.Replace("↑", "→");
            }
        
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down)
            {
                if (this.SelectedLinkLabel != null)
                {
                    int selectedLinkLabelIndex = this.linkLabels[selectedColumn].IndexOf(this.SelectedLinkLabel);
                    if (keyData == Keys.Up)
                    {
                        selectedLinkLabelIndex -= 1;
                        if (selectedLinkLabelIndex < 0)
                        {
                            selectedLinkLabelIndex = this.linkLabels[selectedColumn].Count - 1;
                        }
                    }
                    else
                    {
                        selectedLinkLabelIndex += 1;
                        if (selectedLinkLabelIndex >= this.linkLabels[selectedColumn].Count)
                        {
                            selectedLinkLabelIndex = 0;
                        }
                    }
                    this.SelectedLinkLabel = this.linkLabels[selectedColumn][selectedLinkLabelIndex];
                }
                return true;
            }
            else if (keyData == Keys.Left || keyData == Keys.Right)
            {
                this.selectedColumn = (this.selectedColumn == LinkColumn.Middle) ? LinkColumn.Right : LinkColumn.Middle;
                if (this.linkLabels[selectedColumn].Count > 0)
                {
                    SelectedLinkLabel = this.linkLabels[selectedColumn][0];
                }
            }
            else if (keyData == Keys.Enter || keyData == Keys.Return)
            {
                LabelClicked(this.SelectedLinkLabel, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
