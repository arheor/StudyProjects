namespace iis4
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
            this.components = new System.ComponentModel.Container();
            this.iISDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iISDataSet = new iis4.IISDataSet();
            this.type_comboBox1 = new System.Windows.Forms.ComboBox();
            this.family_comboBox2 = new System.Windows.Forms.ComboBox();
            this.vid_comboBox3 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.iISDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iISDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // iISDataSetBindingSource
            // 
            this.iISDataSetBindingSource.DataSource = this.iISDataSet;
            this.iISDataSetBindingSource.Position = 0;
            // 
            // iISDataSet
            // 
            this.iISDataSet.DataSetName = "IISDataSet";
            this.iISDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // type_comboBox1
            // 
            this.type_comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type_comboBox1.FormattingEnabled = true;
            this.type_comboBox1.Items.AddRange(new object[] {
            "",
            "Птицы"});
            this.type_comboBox1.Location = new System.Drawing.Point(12, 44);
            this.type_comboBox1.Name = "type_comboBox1";
            this.type_comboBox1.Size = new System.Drawing.Size(216, 21);
            this.type_comboBox1.TabIndex = 1;
            this.type_comboBox1.SelectedIndexChanged += new System.EventHandler(this.type_comboBox1_SelectedIndexChanged);
            this.type_comboBox1.SelectedValueChanged += new System.EventHandler(this.type_comboBox1_SelectedValueChanged);
            // 
            // family_comboBox2
            // 
            this.family_comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.family_comboBox2.Enabled = false;
            this.family_comboBox2.FormattingEnabled = true;
            this.family_comboBox2.Location = new System.Drawing.Point(298, 44);
            this.family_comboBox2.Name = "family_comboBox2";
            this.family_comboBox2.Size = new System.Drawing.Size(216, 21);
            this.family_comboBox2.TabIndex = 1;
            this.family_comboBox2.SelectedIndexChanged += new System.EventHandler(this.family_comboBox2_SelectedIndexChanged);
            // 
            // vid_comboBox3
            // 
            this.vid_comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vid_comboBox3.Enabled = false;
            this.vid_comboBox3.FormattingEnabled = true;
            this.vid_comboBox3.Location = new System.Drawing.Point(584, 44);
            this.vid_comboBox3.Name = "vid_comboBox3";
            this.vid_comboBox3.Size = new System.Drawing.Size(216, 21);
            this.vid_comboBox3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::iis4.Properties.Resources.Без_названия;
            this.pictureBox1.Location = new System.Drawing.Point(243, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::iis4.Properties.Resources.Без_названия;
            this.pictureBox2.Location = new System.Drawing.Point(530, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вывести информацию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Тип";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(295, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Семейство";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(581, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Вид";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 195);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(988, 473);
            this.dataGridView1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 700);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.vid_comboBox3);
            this.Controls.Add(this.family_comboBox2);
            this.Controls.Add(this.type_comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iISDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iISDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox type_comboBox1;
        private System.Windows.Forms.ComboBox family_comboBox2;
        private System.Windows.Forms.ComboBox vid_comboBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource iISDataSetBindingSource;
        private IISDataSet iISDataSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

