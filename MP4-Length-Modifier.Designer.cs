
namespace MP4_Length_Modifier
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.outputFileName = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputHours = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.inputMinutes = new System.Windows.Forms.NumericUpDown();
            this.inputSeconds = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.outputConsole = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.inputHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // outputFileName
            // 
            this.outputFileName.Location = new System.Drawing.Point(107, 25);
            this.outputFileName.Name = "outputFileName";
            this.outputFileName.ReadOnly = true;
            this.outputFileName.Size = new System.Drawing.Size(354, 20);
            this.outputFileName.TabIndex = 1;
            this.outputFileName.Text = "Please Select a .MP4 Video File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time:";
            // 
            // inputHours
            // 
            this.inputHours.Enabled = false;
            this.inputHours.Location = new System.Drawing.Point(107, 56);
            this.inputHours.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.inputHours.Name = "inputHours";
            this.inputHours.Size = new System.Drawing.Size(80, 20);
            this.inputHours.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hours";
            // 
            // inputMinutes
            // 
            this.inputMinutes.Enabled = false;
            this.inputMinutes.Location = new System.Drawing.Point(202, 56);
            this.inputMinutes.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.inputMinutes.Name = "inputMinutes";
            this.inputMinutes.Size = new System.Drawing.Size(80, 20);
            this.inputMinutes.TabIndex = 5;
            // 
            // inputSeconds
            // 
            this.inputSeconds.Enabled = false;
            this.inputSeconds.Location = new System.Drawing.Point(297, 56);
            this.inputSeconds.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.inputSeconds.Name = "inputSeconds";
            this.inputSeconds.Size = new System.Drawing.Size(80, 20);
            this.inputSeconds.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Minutes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seconds";
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(26, 127);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Start...";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(26, 22);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(107, 127);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(354, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 10;
            // 
            // outputConsole
            // 
            this.outputConsole.Location = new System.Drawing.Point(26, 156);
            this.outputConsole.Name = "outputConsole";
            this.outputConsole.ReadOnly = true;
            this.outputConsole.Size = new System.Drawing.Size(435, 20);
            this.outputConsole.TabIndex = 11;
            this.outputConsole.Text = "Status: Idle";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 192);
            this.Controls.Add(this.outputConsole);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputSeconds);
            this.Controls.Add(this.inputMinutes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputHours);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputFileName);
            this.Controls.Add(this.buttonBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "MP4 Length Modifier";
            ((System.ComponentModel.ISupportInitialize)(this.inputHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox outputFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown inputHours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown inputMinutes;
        private System.Windows.Forms.NumericUpDown inputSeconds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox outputConsole;
    }
}

