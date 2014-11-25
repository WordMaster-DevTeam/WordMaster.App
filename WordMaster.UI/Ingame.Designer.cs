namespace WordMaster.UI
{
    partial class Ingame
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
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ingame));
            this.GameView = new System.Windows.Forms.PictureBox();
            this.UserControls = new System.Windows.Forms.Panel();
            this.NumVerLabel = new System.Windows.Forms.Label();
            this.GoToUpButton = new System.Windows.Forms.Button();
            this.QuitTheGame = new System.Windows.Forms.Button();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.GoToRightButton = new System.Windows.Forms.Button();
            this.GoToDownButton = new System.Windows.Forms.Button();
            this.LeveLabel = new System.Windows.Forms.Label();
            this.GoToLeftButton = new System.Windows.Forms.Button();
            this.LifeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameView)).BeginInit();
            this.UserControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameView
            // 
            this.GameView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameView.Location = new System.Drawing.Point(12, 12);
            this.GameView.Name = "GameView";
            this.GameView.Size = new System.Drawing.Size(560, 542);
            this.GameView.TabIndex = 0;
            this.GameView.TabStop = false;
            // 
            // UserControls
            // 
            this.UserControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserControls.Controls.Add(this.NumVerLabel);
            this.UserControls.Controls.Add(this.GoToUpButton);
            this.UserControls.Controls.Add(this.QuitTheGame);
            this.UserControls.Controls.Add(this.DescriptionLabel);
            this.UserControls.Controls.Add(this.GoToRightButton);
            this.UserControls.Controls.Add(this.GoToDownButton);
            this.UserControls.Controls.Add(this.LeveLabel);
            this.UserControls.Controls.Add(this.GoToLeftButton);
            this.UserControls.Controls.Add(this.LifeLabel);
            this.UserControls.Controls.Add(this.NameLabel);
            this.UserControls.Location = new System.Drawing.Point(578, 12);
            this.UserControls.Name = "UserControls";
            this.UserControls.Size = new System.Drawing.Size(315, 542);
            this.UserControls.TabIndex = 1;
            this.UserControls.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // NumVerLabel
            // 
            this.NumVerLabel.AutoSize = true;
            this.NumVerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumVerLabel.Location = new System.Drawing.Point(229, 526);
            this.NumVerLabel.Name = "NumVerLabel";
            this.NumVerLabel.Size = new System.Drawing.Size(83, 13);
            this.NumVerLabel.TabIndex = 5;
            this.NumVerLabel.Text = "Word Master v1";
            this.NumVerLabel.Click += new System.EventHandler(this.WDversionlbl_Click);
            // 
            // GoToUpButton
            // 
            this.GoToUpButton.Location = new System.Drawing.Point(112, 363);
            this.GoToUpButton.Name = "GoToUpButton";
            this.GoToUpButton.Size = new System.Drawing.Size(87, 34);
            this.GoToUpButton.TabIndex = 13;
            this.GoToUpButton.Text = "Up";
            this.GoToUpButton.UseVisualStyleBackColor = true;
            // 
            // QuitTheGame
            // 
            this.QuitTheGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuitTheGame.Location = new System.Drawing.Point(10, 508);
            this.QuitTheGame.Name = "QuitTheGame";
            this.QuitTheGame.Size = new System.Drawing.Size(98, 31);
            this.QuitTheGame.TabIndex = 7;
            this.QuitTheGame.Text = "Quit the game";
            this.QuitTheGame.UseVisualStyleBackColor = true;
            this.QuitTheGame.Click += new System.EventHandler(this.QuitTheGame_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(11, 83);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(71, 13);
            this.DescriptionLabel.TabIndex = 4;
            this.DescriptionLabel.Text = "Description";
            // 
            // GoToRightButton
            // 
            this.GoToRightButton.Location = new System.Drawing.Point(205, 381);
            this.GoToRightButton.Name = "GoToRightButton";
            this.GoToRightButton.Size = new System.Drawing.Size(87, 34);
            this.GoToRightButton.TabIndex = 12;
            this.GoToRightButton.Text = "Right";
            this.GoToRightButton.UseVisualStyleBackColor = true;
            // 
            // GoToDownButton
            // 
            this.GoToDownButton.Location = new System.Drawing.Point(112, 403);
            this.GoToDownButton.Name = "GoToDownButton";
            this.GoToDownButton.Size = new System.Drawing.Size(87, 34);
            this.GoToDownButton.TabIndex = 11;
            this.GoToDownButton.Text = "Down";
            this.GoToDownButton.UseVisualStyleBackColor = true;
            // 
            // LeveLabel
            // 
            this.LeveLabel.AutoSize = true;
            this.LeveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeveLabel.Location = new System.Drawing.Point(11, 61);
            this.LeveLabel.Name = "LeveLabel";
            this.LeveLabel.Size = new System.Drawing.Size(42, 13);
            this.LeveLabel.TabIndex = 3;
            this.LeveLabel.Text = "Level ";
            this.LeveLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // GoToLeftButton
            // 
            this.GoToLeftButton.Location = new System.Drawing.Point(19, 381);
            this.GoToLeftButton.Name = "GoToLeftButton";
            this.GoToLeftButton.Size = new System.Drawing.Size(87, 34);
            this.GoToLeftButton.TabIndex = 10;
            this.GoToLeftButton.Text = "Left";
            this.GoToLeftButton.UseVisualStyleBackColor = true;
            this.GoToLeftButton.Click += new System.EventHandler(this.GoToLeftButton_Click);
            // 
            // LifeLabel
            // 
            this.LifeLabel.AutoSize = true;
            this.LifeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LifeLabel.Location = new System.Drawing.Point(11, 39);
            this.LifeLabel.Name = "LifeLabel";
            this.LifeLabel.Size = new System.Drawing.Size(32, 13);
            this.LifeLabel.TabIndex = 2;
            this.LifeLabel.Text = "Life ";
            this.LifeLabel.Click += new System.EventHandler(this.Lifelbl_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(11, 17);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(43, 13);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name ";
            this.NameLabel.Click += new System.EventHandler(this.Namelbl_Click);
            // 
            // Ingame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 563);
            this.Controls.Add(this.UserControls);
            this.Controls.Add(this.GameView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ingame";
            this.RightToLeftLayout = true;
            this.Text = "Word Master";
            this.Load += new System.EventHandler(this.Ingame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GameView)).EndInit();
            this.UserControls.ResumeLayout(false);
            this.UserControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GameView;
        private System.Windows.Forms.Panel UserControls;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label LeveLabel;
        private System.Windows.Forms.Label LifeLabel;
		private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button QuitTheGame;
        private System.Windows.Forms.Label NumVerLabel;
        private System.Windows.Forms.Button GoToLeftButton;
        private System.Windows.Forms.Button GoToDownButton;
        private System.Windows.Forms.Button GoToRightButton;
        private System.Windows.Forms.Button GoToUpButton;
    }
}