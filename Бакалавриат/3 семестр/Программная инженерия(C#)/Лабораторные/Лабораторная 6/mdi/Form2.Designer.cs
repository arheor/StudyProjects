namespace MdiFigures {
	partial class Form2 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.red = new System.Windows.Forms.TrackBar();
            this.green = new System.Windows.Forms.TrackBar();
            this.blue = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.red_value = new System.Windows.Forms.Label();
            this.green_value = new System.Windows.Forms.Label();
            this.blue_value = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // red
            // 
            this.red.AutoSize = false;
            this.red.Location = new System.Drawing.Point(57, 9);
            this.red.Maximum = 255;
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(344, 41);
            this.red.TabIndex = 0;
            this.red.Scroll += new System.EventHandler(this.red_Scroll);
            this.red.ValueChanged += new System.EventHandler(this.red_ValueChanged);
            // 
            // green
            // 
            this.green.AutoSize = false;
            this.green.Location = new System.Drawing.Point(57, 56);
            this.green.Maximum = 255;
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(344, 39);
            this.green.TabIndex = 1;
            this.green.ValueChanged += new System.EventHandler(this.green_ValueChanged);
            // 
            // blue
            // 
            this.blue.AutoSize = false;
            this.blue.Location = new System.Drawing.Point(57, 101);
            this.blue.Maximum = 255;
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(344, 40);
            this.blue.TabIndex = 2;
            this.blue.ValueChanged += new System.EventHandler(this.blue_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Green";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Blue";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(109, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 196);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // red_value
            // 
            this.red_value.AutoSize = true;
            this.red_value.Location = new System.Drawing.Point(407, 9);
            this.red_value.Name = "red_value";
            this.red_value.Size = new System.Drawing.Size(18, 20);
            this.red_value.TabIndex = 5;
            this.red_value.Text = "0";
            // 
            // green_value
            // 
            this.green_value.AutoSize = true;
            this.green_value.Location = new System.Drawing.Point(407, 59);
            this.green_value.Name = "green_value";
            this.green_value.Size = new System.Drawing.Size(18, 20);
            this.green_value.TabIndex = 6;
            this.green_value.Text = "0";
            // 
            // blue_value
            // 
            this.blue_value.AutoSize = true;
            this.blue_value.Location = new System.Drawing.Point(407, 104);
            this.blue_value.Name = "blue_value";
            this.blue_value.Size = new System.Drawing.Size(18, 20);
            this.blue_value.TabIndex = 7;
            this.blue_value.Text = "0";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 360);
            this.Controls.Add(this.blue_value);
            this.Controls.Add(this.green_value);
            this.Controls.Add(this.red_value);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.green);
            this.Controls.Add(this.red);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.TrackBar red;
        private System.Windows.Forms.TrackBar green;
        private System.Windows.Forms.TrackBar blue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label red_value;
        private System.Windows.Forms.Label green_value;
        private System.Windows.Forms.Label blue_value;
    }
}