namespace Domenici.App.GuidosLauncher
{
    partial class FormLauncher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new Domenici.App.GuidosLauncher.PanelDoubleBuffered();
            this.selectionHighlight1 = new Domenici.App.GuidosLauncher.SelectionHighlight();
            this.linkLabelExit = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Ravie", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(107, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Guido\'s Launcher";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Domenici.App.GuidosLauncher.Properties.Resources.GuidosLauncherLogo1;
            this.pictureBox1.Location = new System.Drawing.Point(6, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.selectionHighlight1);
            this.panel1.Controls.Add(this.linkLabelExit);
            this.panel1.Location = new System.Drawing.Point(6, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 680);
            this.panel1.TabIndex = 3;
            // 
            // selectionHighlight1
            // 
            this.selectionHighlight1.BackColor = System.Drawing.SystemColors.Control;
            this.selectionHighlight1.Location = new System.Drawing.Point(632, 403);
            this.selectionHighlight1.Name = "selectionHighlight1";
            this.selectionHighlight1.Size = new System.Drawing.Size(290, 42);
            this.selectionHighlight1.TabIndex = 0;
            // 
            // linkLabelExit
            // 
            this.linkLabelExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelExit.AutoSize = true;
            this.linkLabelExit.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelExit.Font = new System.Drawing.Font("Lucida Sans Unicode", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelExit.LinkColor = System.Drawing.Color.White;
            this.linkLabelExit.Location = new System.Drawing.Point(884, 621);
            this.linkLabelExit.Name = "linkLabelExit";
            this.linkLabelExit.Size = new System.Drawing.Size(197, 59);
            this.linkLabelExit.TabIndex = 2;
            this.linkLabelExit.TabStop = true;
            this.linkLabelExit.Text = "0 ↑ Exit";
            this.linkLabelExit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelClicked);
            this.linkLabelExit.MouseEnter += new System.EventHandler(this.newLabel_MouseEnter);
            // 
            // FormLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1094, 782);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLauncher";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormLauncher_Load);
            this.Shown += new System.EventHandler(this.FormLauncher_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormLauncher_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private PanelDoubleBuffered panel1;
        private SelectionHighlight selectionHighlight1;





    }
}

