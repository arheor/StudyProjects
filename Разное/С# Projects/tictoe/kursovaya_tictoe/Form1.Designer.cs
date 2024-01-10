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
            this.SuspendLayout();
            // 
            // two_players
            // 
            this.two_players.Location = new System.Drawing.Point(66, 79);
            this.two_players.Name = "two_players";
            this.two_players.Size = new System.Drawing.Size(150, 100);
            this.two_players.TabIndex = 0;
            this.two_players.Text = "Два игрока";
            this.two_players.UseVisualStyleBackColor = true;
            this.two_players.Click += new System.EventHandler(this.two_players_Click);
            // 
            // one_player
            // 
            this.one_player.Location = new System.Drawing.Point(66, 235);
            this.one_player.Name = "one_player";
            this.one_player.Size = new System.Drawing.Size(150, 100);
            this.one_player.TabIndex = 1;
            this.one_player.Text = "Один игрок";
            this.one_player.UseVisualStyleBackColor = true;
            this.one_player.Click += new System.EventHandler(this.one_player_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 444);
            this.Controls.Add(this.one_player);
            this.Controls.Add(this.two_players);
            this.Name = "Menu";
            this.Text = "TicToe";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button two_players;
        private System.Windows.Forms.Button one_player;
    }
}

