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
            this.LaunchBtn = new System.Windows.Forms.Button();
            this.CreateCharacterBtn = new System.Windows.Forms.Button();
            this.TutorialBTn = new System.Windows.Forms.Button();
            this.OptionBtn = new System.Windows.Forms.Button();
            this.ScoresBtn = new System.Windows.Forms.Button();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LaunchBtn
            // 
            this.LaunchBtn.Location = new System.Drawing.Point(22, 15);
            this.LaunchBtn.Name = "LaunchBtn";
            this.LaunchBtn.Size = new System.Drawing.Size(133, 45);
            this.LaunchBtn.TabIndex = 0;
            this.LaunchBtn.Text = "Launch game";
            this.LaunchBtn.UseVisualStyleBackColor = true;
            this.LaunchBtn.Click += new System.EventHandler(this.LaunchBtn_Click);
            // 
            // CreateCharacterBtn
            // 
            this.CreateCharacterBtn.Location = new System.Drawing.Point(22, 66);
            this.CreateCharacterBtn.Name = "CreateCharacterBtn";
            this.CreateCharacterBtn.Size = new System.Drawing.Size(133, 45);
            this.CreateCharacterBtn.TabIndex = 2;
            this.CreateCharacterBtn.Text = "Create new character";
            this.CreateCharacterBtn.UseVisualStyleBackColor = true;
            this.CreateCharacterBtn.Click += new System.EventHandler(this.CreateCharacterBtn_Click);
            // 
            // TutorialBTn
            // 
            this.TutorialBTn.Location = new System.Drawing.Point(22, 117);
            this.TutorialBTn.Name = "TutorialBTn";
            this.TutorialBTn.Size = new System.Drawing.Size(133, 45);
            this.TutorialBTn.TabIndex = 3;
            this.TutorialBTn.Text = "Tutorial";
            this.TutorialBTn.UseVisualStyleBackColor = true;
            // 
            // OptionBtn
            // 
            this.OptionBtn.Location = new System.Drawing.Point(22, 168);
            this.OptionBtn.Name = "OptionBtn";
            this.OptionBtn.Size = new System.Drawing.Size(133, 45);
            this.OptionBtn.TabIndex = 4;
            this.OptionBtn.Text = "Option";
            this.OptionBtn.UseVisualStyleBackColor = true;
            // 
            // ScoresBtn
            // 
            this.ScoresBtn.Location = new System.Drawing.Point(22, 219);
            this.ScoresBtn.Name = "ScoresBtn";
            this.ScoresBtn.Size = new System.Drawing.Size(133, 45);
            this.ScoresBtn.TabIndex = 5;
            this.ScoresBtn.Text = "Scores";
            this.ScoresBtn.UseVisualStyleBackColor = true;
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.Location = new System.Drawing.Point(22, 270);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.Size = new System.Drawing.Size(133, 45);
            this.CreditsBtn.TabIndex = 6;
            this.CreditsBtn.Text = "Credits";
            this.CreditsBtn.UseVisualStyleBackColor = true;
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(22, 321);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(133, 45);
            this.QuitBtn.TabIndex = 7;
            this.QuitBtn.Text = "Quit";
            this.QuitBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "Word Master";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.QuitBtn);
            this.panel1.Controls.Add(this.CreditsBtn);
            this.panel1.Controls.Add(this.ScoresBtn);
            this.panel1.Controls.Add(this.OptionBtn);
            this.panel1.Controls.Add(this.TutorialBTn);
            this.panel1.Controls.Add(this.CreateCharacterBtn);
            this.panel1.Controls.Add(this.LaunchBtn);
            this.panel1.Location = new System.Drawing.Point(12, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 381);
            this.panel1.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.51485F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.48515F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(224, 71);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.46809F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.53191F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 381);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // Mainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 464);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Mainmenu";
            this.Text = "Word Master";
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}

