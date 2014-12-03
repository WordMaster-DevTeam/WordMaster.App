namespace WordMaster.UI
{
	partial class Mainmenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainmenu));
            this.CreateCharacterBtn = new System.Windows.Forms.Button();
            this.TutorialBTn = new System.Windows.Forms.Button();
            this.OptionBtn = new System.Windows.Forms.Button();
            this.ScoresBtn = new System.Windows.Forms.Button();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CharacterTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // CreateCharacterBtn
            // 
            this.CreateCharacterBtn.Location = new System.Drawing.Point(12, 95);
            this.CreateCharacterBtn.Name = "CreateCharacterBtn";
            this.CreateCharacterBtn.Size = new System.Drawing.Size(133, 45);
            this.CreateCharacterBtn.TabIndex = 2;
            this.CreateCharacterBtn.Text = "Create new character";
            this.CreateCharacterBtn.UseVisualStyleBackColor = true;
            this.CreateCharacterBtn.Click += new System.EventHandler(this.CreateCharacterBtn_Click);
            // 
            // TutorialBTn
            // 
            this.TutorialBTn.Location = new System.Drawing.Point(216, 95);
            this.TutorialBTn.Name = "TutorialBTn";
            this.TutorialBTn.Size = new System.Drawing.Size(133, 45);
            this.TutorialBTn.TabIndex = 3;
            this.TutorialBTn.Text = "Tutorial";
            this.TutorialBTn.UseVisualStyleBackColor = true;
            // 
            // OptionBtn
            // 
            this.OptionBtn.Location = new System.Drawing.Point(411, 95);
            this.OptionBtn.Name = "OptionBtn";
            this.OptionBtn.Size = new System.Drawing.Size(133, 45);
            this.OptionBtn.TabIndex = 4;
            this.OptionBtn.Text = "Option";
            this.OptionBtn.UseVisualStyleBackColor = true;
            // 
            // ScoresBtn
            // 
            this.ScoresBtn.Location = new System.Drawing.Point(619, 95);
            this.ScoresBtn.Name = "ScoresBtn";
            this.ScoresBtn.Size = new System.Drawing.Size(133, 45);
            this.ScoresBtn.TabIndex = 5;
            this.ScoresBtn.Text = "Scores";
            this.ScoresBtn.UseVisualStyleBackColor = true;
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.Location = new System.Drawing.Point(847, 95);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.Size = new System.Drawing.Size(133, 45);
            this.CreditsBtn.TabIndex = 6;
            this.CreditsBtn.Text = "Credits";
            this.CreditsBtn.UseVisualStyleBackColor = true;
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(1066, 95);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(133, 45);
            this.QuitBtn.TabIndex = 7;
            this.QuitBtn.Text = "Quit";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(489, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "Word Master";
            // 
            // CharacterTableLayout
            // 
            this.CharacterTableLayout.BackColor = System.Drawing.Color.Gray;
            this.CharacterTableLayout.ColumnCount = 2;
            this.CharacterTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CharacterTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CharacterTableLayout.Location = new System.Drawing.Point(12, 146);
            this.CharacterTableLayout.Name = "CharacterTableLayout";
            this.CharacterTableLayout.RowCount = 2;
            this.CharacterTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CharacterTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CharacterTableLayout.Size = new System.Drawing.Size(1187, 460);
            this.CharacterTableLayout.TabIndex = 9;
            // 
            // Mainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1211, 618);
            this.Controls.Add(this.CharacterTableLayout);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScoresBtn);
            this.Controls.Add(this.OptionBtn);
            this.Controls.Add(this.CreateCharacterBtn);
            this.Controls.Add(this.TutorialBTn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainmenu";
            this.Text = "Word Master";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button CreateCharacterBtn;
        private System.Windows.Forms.Button TutorialBTn;
        private System.Windows.Forms.Button OptionBtn;
        private System.Windows.Forms.Button ScoresBtn;
        private System.Windows.Forms.Button CreditsBtn;
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel CharacterTableLayout;
	}
}

