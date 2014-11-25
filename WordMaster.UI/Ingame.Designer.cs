using WordMaster.DLL;
using WordMaster.UI;

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
            this.UserControls = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GoToUpButton = new System.Windows.Forms.Button();
            this.GoToLeftButton = new System.Windows.Forms.Button();
            this.GoToDownButton = new System.Windows.Forms.Button();
            this.GoToRightButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DungeonLabel = new System.Windows.Forms.Label();
            this.FloorLabel = new System.Windows.Forms.Label();
            this.SquareLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.LifeLabel = new System.Windows.Forms.Label();
            this.LeveLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.ArmorLabel = new System.Windows.Forms.Label();
            this.NumVerLabel = new System.Windows.Forms.Label();
            this.QuitTheGame = new System.Windows.Forms.Button();
            this.floorView1 = new WordMaster.UI.FloorView();
            this.UserControls.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserControls
            // 
            this.UserControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UserControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserControls.Controls.Add(this.panel3);
            this.UserControls.Controls.Add(this.panel2);
            this.UserControls.Controls.Add(this.panel1);
            this.UserControls.Controls.Add(this.NumVerLabel);
            this.UserControls.Controls.Add(this.QuitTheGame);
            this.UserControls.Location = new System.Drawing.Point(589, 12);
            this.UserControls.Name = "UserControls";
            this.UserControls.Size = new System.Drawing.Size(304, 542);
            this.UserControls.TabIndex = 1;
            this.UserControls.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.GoToUpButton);
            this.panel3.Controls.Add(this.GoToLeftButton);
            this.panel3.Controls.Add(this.GoToDownButton);
            this.panel3.Controls.Add(this.GoToRightButton);
            this.panel3.Location = new System.Drawing.Point(10, 366);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(282, 81);
            this.panel3.TabIndex = 20;
            // 
            // GoToUpButton
            // 
            this.GoToUpButton.Location = new System.Drawing.Point(96, 3);
            this.GoToUpButton.Name = "GoToUpButton";
            this.GoToUpButton.Size = new System.Drawing.Size(87, 34);
            this.GoToUpButton.TabIndex = 13;
            this.GoToUpButton.Text = "Up";
            this.GoToUpButton.UseVisualStyleBackColor = true;
            // 
            // GoToLeftButton
            // 
            this.GoToLeftButton.Location = new System.Drawing.Point(3, 21);
            this.GoToLeftButton.Name = "GoToLeftButton";
            this.GoToLeftButton.Size = new System.Drawing.Size(87, 34);
            this.GoToLeftButton.TabIndex = 10;
            this.GoToLeftButton.Text = "Left";
            this.GoToLeftButton.UseVisualStyleBackColor = true;
            this.GoToLeftButton.Click += new System.EventHandler(this.GoToLeftButton_Click);
            // 
            // GoToDownButton
            // 
            this.GoToDownButton.Location = new System.Drawing.Point(96, 43);
            this.GoToDownButton.Name = "GoToDownButton";
            this.GoToDownButton.Size = new System.Drawing.Size(87, 34);
            this.GoToDownButton.TabIndex = 11;
            this.GoToDownButton.Text = "Down";
            this.GoToDownButton.UseVisualStyleBackColor = true;
            // 
            // GoToRightButton
            // 
            this.GoToRightButton.Location = new System.Drawing.Point(189, 21);
            this.GoToRightButton.Name = "GoToRightButton";
            this.GoToRightButton.Size = new System.Drawing.Size(87, 34);
            this.GoToRightButton.TabIndex = 12;
            this.GoToRightButton.Text = "Right";
            this.GoToRightButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.DungeonLabel);
            this.panel2.Controls.Add(this.FloorLabel);
            this.panel2.Controls.Add(this.SquareLabel);
            this.panel2.Location = new System.Drawing.Point(10, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 110);
            this.panel2.TabIndex = 19;
            // 
            // DungeonLabel
            // 
            this.DungeonLabel.AutoSize = true;
            this.DungeonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DungeonLabel.Location = new System.Drawing.Point(14, 12);
            this.DungeonLabel.Name = "DungeonLabel";
            this.DungeonLabel.Size = new System.Drawing.Size(58, 13);
            this.DungeonLabel.TabIndex = 15;
            this.DungeonLabel.Text = "Dungeon";
            // 
            // FloorLabel
            // 
            this.FloorLabel.AutoSize = true;
            this.FloorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FloorLabel.Location = new System.Drawing.Point(14, 36);
            this.FloorLabel.Name = "FloorLabel";
            this.FloorLabel.Size = new System.Drawing.Size(35, 13);
            this.FloorLabel.TabIndex = 16;
            this.FloorLabel.Text = "Floor";
            this.FloorLabel.Click += new System.EventHandler(this.FloorLabel_Click);
            // 
            // SquareLabel
            // 
            this.SquareLabel.AutoSize = true;
            this.SquareLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SquareLabel.Location = new System.Drawing.Point(14, 60);
            this.SquareLabel.Name = "SquareLabel";
            this.SquareLabel.Size = new System.Drawing.Size(47, 13);
            this.SquareLabel.TabIndex = 17;
            this.SquareLabel.Text = "Square";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Controls.Add(this.LifeLabel);
            this.panel1.Controls.Add(this.LeveLabel);
            this.panel1.Controls.Add(this.DescriptionLabel);
            this.panel1.Controls.Add(this.ArmorLabel);
            this.panel1.Location = new System.Drawing.Point(10, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 203);
            this.panel1.TabIndex = 18;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(15, 14);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(43, 13);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name ";
            this.NameLabel.Click += new System.EventHandler(this.Namelbl_Click);
            // 
            // LifeLabel
            // 
            this.LifeLabel.AutoSize = true;
            this.LifeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LifeLabel.Location = new System.Drawing.Point(15, 36);
            this.LifeLabel.Name = "LifeLabel";
            this.LifeLabel.Size = new System.Drawing.Size(32, 13);
            this.LifeLabel.TabIndex = 2;
            this.LifeLabel.Text = "Life ";
            this.LifeLabel.Click += new System.EventHandler(this.Lifelbl_Click);
            // 
            // LeveLabel
            // 
            this.LeveLabel.AutoSize = true;
            this.LeveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeveLabel.Location = new System.Drawing.Point(15, 58);
            this.LeveLabel.Name = "LeveLabel";
            this.LeveLabel.Size = new System.Drawing.Size(42, 13);
            this.LeveLabel.TabIndex = 3;
            this.LeveLabel.Text = "Level ";
            this.LeveLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(15, 107);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(71, 13);
            this.DescriptionLabel.TabIndex = 4;
            this.DescriptionLabel.Text = "Description";
            this.DescriptionLabel.Click += new System.EventHandler(this.DescriptionLabel_Click);
            // 
            // ArmorLabel
            // 
            this.ArmorLabel.AutoSize = true;
            this.ArmorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArmorLabel.Location = new System.Drawing.Point(15, 82);
            this.ArmorLabel.Name = "ArmorLabel";
            this.ArmorLabel.Size = new System.Drawing.Size(39, 13);
            this.ArmorLabel.TabIndex = 14;
            this.ArmorLabel.Text = "Armor";
            // 
            // NumVerLabel
            // 
            this.NumVerLabel.AutoSize = true;
            this.NumVerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumVerLabel.Location = new System.Drawing.Point(216, 524);
            this.NumVerLabel.Name = "NumVerLabel";
            this.NumVerLabel.Size = new System.Drawing.Size(83, 13);
            this.NumVerLabel.TabIndex = 5;
            this.NumVerLabel.Text = "Word Master v1";
            this.NumVerLabel.Click += new System.EventHandler(this.WDversionlbl_Click);
            // 
            // QuitTheGame
            // 
            this.QuitTheGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuitTheGame.Location = new System.Drawing.Point(10, 509);
            this.QuitTheGame.Name = "QuitTheGame";
            this.QuitTheGame.Size = new System.Drawing.Size(85, 29);
            this.QuitTheGame.TabIndex = 7;
            this.QuitTheGame.Text = "Quit the game";
            this.QuitTheGame.UseVisualStyleBackColor = true;
            this.QuitTheGame.Click += new System.EventHandler(this.QuitTheGame_Click);
            // 
            // floorView1
            // 
            this.floorView1.BackColor = System.Drawing.Color.Gray;
            this.floorView1.Location = new System.Drawing.Point(12, 12);
            this.floorView1.Name = "floorView1";
            this.floorView1.Size = new System.Drawing.Size(300, 300);
            this.floorView1.TabIndex = 2;
            // 
            // Ingame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 563);
            this.Controls.Add(this.floorView1);
            this.Controls.Add(this.UserControls);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ingame";
            this.RightToLeftLayout = true;
            this.Text = "Word Master";
            this.Load += new System.EventHandler(this.Ingame_Load);
            this.UserControls.ResumeLayout(false);
            this.UserControls.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Label ArmorLabel;
        private System.Windows.Forms.Label SquareLabel;
        private System.Windows.Forms.Label FloorLabel;
        private System.Windows.Forms.Label DungeonLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private FloorView floorView1;
    }
}