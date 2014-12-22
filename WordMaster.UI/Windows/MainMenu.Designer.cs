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
            this.CreateCharacterBtn = new System.Windows.Forms.Button();
            this.TutorialBTn = new System.Windows.Forms.Button();
            this.OptionBtn = new System.Windows.Forms.Button();
            this.ScoresBtn = new System.Windows.Forms.Button();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.CharacterTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateCharacterBtn
            // 
            this.CreateCharacterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateCharacterBtn.Location = new System.Drawing.Point(574, 12);
            this.CreateCharacterBtn.Name = "CreateCharacterBtn";
            this.CreateCharacterBtn.Size = new System.Drawing.Size(133, 45);
            this.CreateCharacterBtn.TabIndex = 2;
            this.CreateCharacterBtn.Text = "New character";
            this.CreateCharacterBtn.UseVisualStyleBackColor = true;
            this.CreateCharacterBtn.Click += new System.EventHandler(this.CreateCharacterBtn_Click);
            // 
            // TutorialBTn
            // 
            this.TutorialBTn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TutorialBTn.Enabled = false;
            this.TutorialBTn.Location = new System.Drawing.Point(713, 12);
            this.TutorialBTn.Name = "TutorialBTn";
            this.TutorialBTn.Size = new System.Drawing.Size(133, 45);
            this.TutorialBTn.TabIndex = 3;
            this.TutorialBTn.Text = "Tutorial";
            this.TutorialBTn.UseVisualStyleBackColor = true;
            // 
            // OptionBtn
            // 
            this.OptionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionBtn.Enabled = false;
            this.OptionBtn.Location = new System.Drawing.Point(852, 12);
            this.OptionBtn.Name = "OptionBtn";
            this.OptionBtn.Size = new System.Drawing.Size(133, 45);
            this.OptionBtn.TabIndex = 4;
            this.OptionBtn.Text = "Option";
            this.OptionBtn.UseVisualStyleBackColor = true;
            // 
            // ScoresBtn
            // 
            this.ScoresBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoresBtn.Enabled = false;
            this.ScoresBtn.Location = new System.Drawing.Point(574, 63);
            this.ScoresBtn.Name = "ScoresBtn";
            this.ScoresBtn.Size = new System.Drawing.Size(133, 45);
            this.ScoresBtn.TabIndex = 5;
            this.ScoresBtn.Text = "Scores";
            this.ScoresBtn.UseVisualStyleBackColor = true;
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreditsBtn.Enabled = false;
            this.CreditsBtn.Location = new System.Drawing.Point(713, 63);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.Size = new System.Drawing.Size(133, 45);
            this.CreditsBtn.TabIndex = 6;
            this.CreditsBtn.Text = "Credits";
            this.CreditsBtn.UseVisualStyleBackColor = true;
            // 
            // QuitBtn
            // 
            this.QuitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QuitBtn.Location = new System.Drawing.Point(852, 63);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(133, 45);
            this.QuitBtn.TabIndex = 7;
            this.QuitBtn.Text = "Quit";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // CharacterTableLayout
            // 
            this.CharacterTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterTableLayout.AutoScroll = true;
            this.CharacterTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CharacterTableLayout.BackColor = System.Drawing.Color.Gray;
            this.CharacterTableLayout.ColumnCount = 1;
            this.CharacterTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CharacterTableLayout.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CharacterTableLayout.Location = new System.Drawing.Point(12, 120);
            this.CharacterTableLayout.Name = "CharacterTableLayout";
            this.CharacterTableLayout.RowCount = 1;
            this.CharacterTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CharacterTableLayout.Size = new System.Drawing.Size(985, 507);
            this.CharacterTableLayout.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.LogoPictureBox);
            this.panel1.Controls.Add(this.QuitBtn);
            this.panel1.Controls.Add(this.CreditsBtn);
            this.panel1.Controls.Add(this.ScoresBtn);
            this.panel1.Controls.Add(this.OptionBtn);
            this.panel1.Controls.Add(this.CreateCharacterBtn);
            this.panel1.Controls.Add(this.TutorialBTn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 114);
            this.panel1.TabIndex = 10;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Location = new System.Drawing.Point(-17, 7);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(352, 101);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 9;
            this.LogoPictureBox.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1009, 639);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CharacterTableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Word Master";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Button CreateCharacterBtn;
        private System.Windows.Forms.Button TutorialBTn;
        private System.Windows.Forms.Button OptionBtn;
        private System.Windows.Forms.Button ScoresBtn;
        private System.Windows.Forms.Button CreditsBtn;
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.TableLayoutPanel CharacterTableLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox LogoPictureBox;
	}
}

