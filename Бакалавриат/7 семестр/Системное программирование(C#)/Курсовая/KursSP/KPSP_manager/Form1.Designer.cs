namespace KPSP_manager
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
            this.exec_button1 = new System.Windows.Forms.Button();
            this.stop_button2 = new System.Windows.Forms.Button();
            this.log_button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // exec_button1
            // 
            this.exec_button1.Location = new System.Drawing.Point(12, 352);
            this.exec_button1.Name = "exec_button1";
            this.exec_button1.Size = new System.Drawing.Size(146, 51);
            this.exec_button1.TabIndex = 0;
            this.exec_button1.Text = "Запустить";
            this.exec_button1.UseVisualStyleBackColor = true;
            this.exec_button1.Click += new System.EventHandler(this.exec_button1_Click);
            // 
            // stop_button2
            // 
            this.stop_button2.Location = new System.Drawing.Point(164, 352);
            this.stop_button2.Name = "stop_button2";
            this.stop_button2.Size = new System.Drawing.Size(146, 51);
            this.stop_button2.TabIndex = 1;
            this.stop_button2.Text = "Остановить";
            this.stop_button2.UseVisualStyleBackColor = true;
            this.stop_button2.Click += new System.EventHandler(this.stop_button2_Click);
            // 
            // log_button3
            // 
            this.log_button3.Location = new System.Drawing.Point(316, 352);
            this.log_button3.Name = "log_button3";
            this.log_button3.Size = new System.Drawing.Size(146, 51);
            this.log_button3.TabIndex = 2;
            this.log_button3.Text = "Лог";
            this.log_button3.UseVisualStyleBackColor = true;
            this.log_button3.Click += new System.EventHandler(this.log_button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Статус службы:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "статус";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 44);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(450, 302);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 414);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.log_button3);
            this.Controls.Add(this.stop_button2);
            this.Controls.Add(this.exec_button1);
            this.Name = "Form1";
            this.Text = "Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exec_button1;
        private System.Windows.Forms.Button stop_button2;
        private System.Windows.Forms.Button log_button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

