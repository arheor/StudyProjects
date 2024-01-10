namespace kursovaya_tictoe
{
    partial class Menu
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
            this.two_players = new System.Windows.Forms.Button();
            this.one_player = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // two_players
            // 
            this.two_players.BackColor = System.Drawing.SystemColors.Window;
            this.two_players.Location = new System.Drawing.Point(66, 49);
            this.two_players.Name = "two_players";
            this.two_players.Size = new System.Drawing.Size(150, 100);
            this.two_players.TabIndex = 0;
            this.two_players.Text = "Два игрока";
            this.two_players.UseVisualStyleBackColor = false;
            this.two_players.Click += new System.EventHandler(this.two_players_Click);
            // 
            // one_player
            // 
            this.one_player.BackColor = System.Drawing.SystemColors.Window;
            this.one_player.Location = new System.Drawing.Point(66, 175);
            this.one_player.Name = "one_player";
            this.one_player.Size = new System.Drawing.Size(150, 100);
            this.one_player.TabIndex = 1;
            this.one_player.Text = "Один игрок";
            this.one_player.UseVisualStyleBackColor = false;
            this.one_player.Click += new System.EventHandler(this.one_player_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(66, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 100);
            this.button1.TabIndex = 2;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(278, 444);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.one_player);
            this.Controls.Add(this.two_players);
            this.Name = "Menu";
            this.Text = "TicToe";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button two_players;
        private System.Windows.Forms.Button one_player;
        private System.Windows.Forms.Button button1;
    }
}

