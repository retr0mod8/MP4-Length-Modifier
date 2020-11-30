namespace VideoLengthChanger
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
            this.Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.LocationText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Hours = new System.Windows.Forms.NumericUpDown();
            this.Minutes = new System.Windows.Forms.NumericUpDown();
            this.Seconds = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Seconds)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Enabled = false;
            this.Start.Location = new System.Drawing.Point(35, 64);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Video Length Changer";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(35, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Choose File...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Browse);
            // 
            // LocationText
            // 
            this.LocationText.Location = new System.Drawing.Point(141, 14);
            this.LocationText.Name = "LocationText";
            this.LocationText.ReadOnly = true;
            this.LocationText.Size = new System.Drawing.Size(303, 20);
            this.LocationText.TabIndex = 6;
            this.LocationText.TextChanged += new System.EventHandler(this.LocationText_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "New Custom Length (Hour:Minutes:Seconds):";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(348, 80);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(69, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "By retr0mod8";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Hours
            // 
            this.Hours.Location = new System.Drawing.Point(261, 36);
            this.Hours.Name = "Hours";
            this.Hours.Size = new System.Drawing.Size(32, 20);
            this.Hours.TabIndex = 12;
            // 
            // Minutes
            // 
            this.Minutes.Location = new System.Drawing.Point(299, 36);
            this.Minutes.Name = "Minutes";
            this.Minutes.Size = new System.Drawing.Size(32, 20);
            this.Minutes.TabIndex = 13;
            // 
            // Seconds
            // 
            this.Seconds.Location = new System.Drawing.Point(337, 36);
            this.Seconds.Name = "Seconds";
            this.Seconds.Size = new System.Drawing.Size(32, 20);
            this.Seconds.TabIndex = 14;
            // 
            // Form1
            // 
            this.AcceptButton = this.Start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 97);
            this.Controls.Add(this.Seconds);
            this.Controls.Add(this.Minutes);
            this.Controls.Add(this.Hours);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LocationText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Video Length Changer";
            ((System.ComponentModel.ISupportInitialize)(this.Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Seconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox LocationText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.NumericUpDown Hours;
        private System.Windows.Forms.NumericUpDown Minutes;
        private System.Windows.Forms.NumericUpDown Seconds;
    }
}

