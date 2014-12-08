namespace WordMaster.UI
{
	partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.LaunchBtn = new System.Windows.Forms.Button();
            this.CreateCharacterBtn = new System.Windows.Forms.Button();
            this.TutorialBTn = new System.Windows.Forms.Button();
            this.OptionBtn = new System.Windows.Forms.Button();
            this.ScoresBtn = new System.Windows.Forms.Button();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CharacterDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LaunchBtn
            // 
            this.LaunchBtn.Location = new System.Drawing.Point(12, 166);
            this.LaunchBtn.Name = "LaunchBtn";
            this.LaunchBtn.Size = new System.Drawing.Size(133, 45);
            this.LaunchBtn.TabIndex = 0;
            this.LaunchBtn.Text = "Launch game";
            this.LaunchBtn.UseVisualStyleBackColor = true;
            this.LaunchBtn.Click += new System.EventHandler(this.LaunchBtn_Click);
            // 
            // CreateCharacterBtn
            // 
            this.CreateCharacterBtn.Location = new System.Drawing.Point(12, 217);
            this.CreateCharacterBtn.Name = "CreateCharacterBtn";
            this.CreateCharacterBtn.Size = new System.Drawing.Size(133, 45);
            this.CreateCharacterBtn.TabIndex = 2;
            this.CreateCharacterBtn.Text = "Create new character";
            this.CreateCharacterBtn.UseVisualStyleBackColor = true;
            this.CreateCharacterBtn.Click += new System.EventHandler(this.CreateCharacterBtn_Click);
            // 
            // TutorialBTn
            // 
            this.TutorialBTn.Location = new System.Drawing.Point(12, 268);
            this.TutorialBTn.Name = "TutorialBTn";
            this.TutorialBTn.Size = new System.Drawing.Size(133, 45);
            this.TutorialBTn.TabIndex = 3;
            this.TutorialBTn.Text = "Tutorial";
            this.TutorialBTn.UseVisualStyleBackColor = true;
            // 
            // OptionBtn
            // 
            this.OptionBtn.Location = new System.Drawing.Point(12, 319);
            this.OptionBtn.Name = "OptionBtn";
            this.OptionBtn.Size = new System.Drawing.Size(133, 45);
            this.OptionBtn.TabIndex = 4;
            this.OptionBtn.Text = "Option";
            this.OptionBtn.UseVisualStyleBackColor = true;
            // 
            // ScoresBtn
            // 
            this.ScoresBtn.Location = new System.Drawing.Point(12, 370);
            this.ScoresBtn.Name = "ScoresBtn";
            this.ScoresBtn.Size = new System.Drawing.Size(133, 45);
            this.ScoresBtn.TabIndex = 5;
            this.ScoresBtn.Text = "Scores";
            this.ScoresBtn.UseVisualStyleBackColor = true;
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.Location = new System.Drawing.Point(12, 421);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.Size = new System.Drawing.Size(133, 45);
            this.CreditsBtn.TabIndex = 6;
            this.CreditsBtn.Text = "Credits";
            this.CreditsBtn.UseVisualStyleBackColor = true;
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(12, 472);
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
            this.label1.Location = new System.Drawing.Point(391, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "Word Master";
            // 
            // CharacterDataGridView
            // 
            this.CharacterDataGridView.AllowUserToAddRows = false;
            this.CharacterDataGridView.AllowUserToDeleteRows = false;
            this.CharacterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CharacterDataGridView.Location = new System.Drawing.Point(151, 166);
            this.CharacterDataGridView.Name = "CharacterDataGridView";
            this.CharacterDataGridView.ReadOnly = true;
            this.CharacterDataGridView.Size = new System.Drawing.Size(846, 351);
            this.CharacterDataGridView.TabIndex = 9;
            // 
            // Mainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 529);
            this.Controls.Add(this.CharacterDataGridView);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScoresBtn);
            this.Controls.Add(this.LaunchBtn);
            this.Controls.Add(this.OptionBtn);
            this.Controls.Add(this.CreateCharacterBtn);
            this.Controls.Add(this.TutorialBTn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainmenu";
            this.Text = "Word Master";
            ((System.ComponentModel.ISupportInitialize)(this.CharacterDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button LaunchBtn;
        private System.Windows.Forms.Button CreateCharacterBtn;
        private System.Windows.Forms.Button TutorialBTn;
        private System.Windows.Forms.Button OptionBtn;
        private System.Windows.Forms.Button ScoresBtn;
        private System.Windows.Forms.Button CreditsBtn;
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView CharacterDataGridView;
	}
}

