namespace WindowsFormsApp1
{
    partial class AulaPb3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AulaPb3));
            this.ptbF1C1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF1C1)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbF1C1
            // 
            this.ptbF1C1.Image = ((System.Drawing.Image)(resources.GetObject("ptbF1C1.Image")));
            this.ptbF1C1.Location = new System.Drawing.Point(197, 252);
            this.ptbF1C1.Name = "ptbF1C1";
            this.ptbF1C1.Size = new System.Drawing.Size(35, 67);
            this.ptbF1C1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbF1C1.TabIndex = 0;
            this.ptbF1C1.TabStop = false;
            this.ptbF1C1.Click += new System.EventHandler(this.ptbF1C1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(135, 222);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // AulaPb3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(934, 604);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ptbF1C1);
            this.Name = "AulaPb3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AulaPb3";
            this.Load += new System.EventHandler(this.AulaPb3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbF1C1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbF1C1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}