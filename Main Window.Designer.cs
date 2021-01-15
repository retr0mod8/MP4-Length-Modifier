namespace MP4_Length_Modifier
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BrowseButton = new System.Windows.Forms.Button();
            this.Hour = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.PathText = new System.Windows.Forms.TextBox();
            this.Minute = new System.Windows.Forms.NumericUpDown();
            this.Seconds = new System.Windows.Forms.NumericUpDown();
            this.StartButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.InfoBox = new System.Windows.Forms.ToolStripButton();
            this.BackupCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Seconds)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(12, 29);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // Hour
            // 
            this.Hour.Enabled = false;
            this.Hour.Location = new System.Drawing.Point(134, 57);
            this.Hour.Maximum = new decimal(new int[] {
            3840,
            0,
            0,
            0});
            this.Hour.Name = "Hour";
            this.Hour.Size = new System.Drawing.Size(73, 20);
            this.Hour.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "New Custom Length:";
            // 
            // PathText
            // 
            this.PathText.Location = new System.Drawing.Point(98, 31);
            this.PathText.Name = "PathText";
            this.PathText.ReadOnly = true;
            this.PathText.Size = new System.Drawing.Size(305, 20);
            this.PathText.TabIndex = 4;
            // 
            // Minute
            // 
            this.Minute.Enabled = false;
            this.Minute.Location = new System.Drawing.Point(233, 57);
            this.Minute.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.Minute.Name = "Minute";
            this.Minute.Size = new System.Drawing.Size(73, 20);
            this.Minute.TabIndex = 5;
            // 
            // Seconds
            // 
            this.Seconds.Enabled = false;
            this.Seconds.Location = new System.Drawing.Point(330, 57);
            this.Seconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.Seconds.Name = "Seconds";
            this.Seconds.Size = new System.Drawing.Size(73, 20);
            this.Seconds.TabIndex = 6;
            // 
            // StartButton
            // 
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(12, 110);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(391, 23);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(418, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // InfoBox
            // 
            this.InfoBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.InfoBox.Image = ((System.Drawing.Image)(resources.GetObject("InfoBox.Image")));
            this.InfoBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(32, 22);
            this.InfoBox.Text = "Info";
            this.InfoBox.Click += new System.EventHandler(this.InfoBox_Click);
            // 
            // BackupCheckbox
            // 
            this.BackupCheckbox.AutoSize = true;
            this.BackupCheckbox.Checked = true;
            this.BackupCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BackupCheckbox.Location = new System.Drawing.Point(12, 87);
            this.BackupCheckbox.Name = "BackupCheckbox";
            this.BackupCheckbox.Size = new System.Drawing.Size(82, 17);
            this.BackupCheckbox.TabIndex = 9;
            this.BackupCheckbox.Text = "Backup File";
            this.BackupCheckbox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Hours";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Minutes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(418, 145);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BackupCheckbox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Seconds);
            this.Controls.Add(this.Minute);
            this.Controls.Add(this.PathText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hour);
            this.Controls.Add(this.BrowseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MP4 Length Modifier";
            ((System.ComponentModel.ISupportInitialize)(this.Hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Seconds)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.NumericUpDown Hour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PathText;
        private System.Windows.Forms.NumericUpDown Minute;
        private System.Windows.Forms.NumericUpDown Seconds;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton InfoBox;
        private System.Windows.Forms.CheckBox BackupCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

