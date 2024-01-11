namespace WindowsFormsApp4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.arclistTextBox1 = new System.Windows.Forms.RichTextBox();
            this.adjmatrixTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adjlistTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(628, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Загрузить список дуг";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.arcmatrix_Click);
            // 
            // arclistTextBox1
            // 
            this.arclistTextBox1.Location = new System.Drawing.Point(12, 24);
            this.arclistTextBox1.Name = "arclistTextBox1";
            this.arclistTextBox1.ReadOnly = true;
            this.arclistTextBox1.Size = new System.Drawing.Size(205, 224);
            this.arclistTextBox1.TabIndex = 1;
            this.arclistTextBox1.Text = "";
            // 
            // adjmatrixTextBox2
            // 
            this.adjmatrixTextBox2.Location = new System.Drawing.Point(224, 24);
            this.adjmatrixTextBox2.Name = "adjmatrixTextBox2";
            this.adjmatrixTextBox2.ReadOnly = true;
            this.adjmatrixTextBox2.Size = new System.Drawing.Size(205, 224);
            this.adjmatrixTextBox2.TabIndex = 1;
            this.adjmatrixTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Матрица смежности";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Список дуг";
            // 
            // adjlistTextBox1
            // 
            this.adjlistTextBox1.Location = new System.Drawing.Point(435, 24);
            this.adjlistTextBox1.Name = "adjlistTextBox1";
            this.adjlistTextBox1.ReadOnly = true;
            this.adjlistTextBox1.Size = new System.Drawing.Size(205, 224);
            this.adjlistTextBox1.TabIndex = 1;
            this.adjlistTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Список смежности";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 313);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.adjlistTextBox1);
            this.Controls.Add(this.adjmatrixTextBox2);
            this.Controls.Add(this.arclistTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox arclistTextBox1;
        private System.Windows.Forms.RichTextBox adjmatrixTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox adjlistTextBox1;
        private System.Windows.Forms.Label label3;
    }
}

