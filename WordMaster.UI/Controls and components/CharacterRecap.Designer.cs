﻿namespace WordMaster.UI
{
    partial class CharacterRecap
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameLbl = new System.Windows.Forms.Label();
            this.LifeLbl = new System.Windows.Forms.Label();
            this.LevelLbl = new System.Windows.Forms.Label();
            this.DungeonLbl = new System.Windows.Forms.Label();
            this.LaunchBtn = new System.Windows.Forms.Button();
            this.CharacterPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(127, 3);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(44, 13);
            this.NameLbl.TabIndex = 0;
            this.NameLbl.Text = "Name : ";
            // 
            // LifeLbl
            // 
            this.LifeLbl.AutoSize = true;
            this.LifeLbl.Location = new System.Drawing.Point(127, 28);
            this.LifeLbl.Name = "LifeLbl";
            this.LifeLbl.Size = new System.Drawing.Size(33, 13);
            this.LifeLbl.TabIndex = 1;
            this.LifeLbl.Text = "Life : ";
            // 
            // LevelLbl
            // 
            this.LevelLbl.AutoSize = true;
            this.LevelLbl.Location = new System.Drawing.Point(127, 55);
            this.LevelLbl.Name = "LevelLbl";
            this.LevelLbl.Size = new System.Drawing.Size(42, 13);
            this.LevelLbl.TabIndex = 2;
            this.LevelLbl.Text = "Level : ";
            // 
            // DungeonLbl
            // 
            this.DungeonLbl.AutoSize = true;
            this.DungeonLbl.Location = new System.Drawing.Point(127, 79);
            this.DungeonLbl.Name = "DungeonLbl";
            this.DungeonLbl.Size = new System.Drawing.Size(60, 13);
            this.DungeonLbl.TabIndex = 3;
            this.DungeonLbl.Text = "Dungeon : ";
            // 
            // LaunchBtn
            // 
            this.LaunchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LaunchBtn.BackColor = System.Drawing.Color.Gray;
            this.LaunchBtn.Location = new System.Drawing.Point(860, 125);
            this.LaunchBtn.Name = "LaunchBtn";
            this.LaunchBtn.Size = new System.Drawing.Size(87, 29);
            this.LaunchBtn.TabIndex = 4;
            this.LaunchBtn.Text = "Launch Game";
            this.LaunchBtn.UseVisualStyleBackColor = false;
            this.LaunchBtn.Click += new System.EventHandler(this.LaunchBtn_Click);
            // 
            // CharacterPictureBox
            // 
            this.CharacterPictureBox.Location = new System.Drawing.Point(3, 3);
            this.CharacterPictureBox.Name = "CharacterPictureBox";
            this.CharacterPictureBox.Size = new System.Drawing.Size(118, 151);
            this.CharacterPictureBox.TabIndex = 5;
            this.CharacterPictureBox.TabStop = false;
            // 
            // CharacterRecap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.CharacterPictureBox);
            this.Controls.Add(this.LaunchBtn);
            this.Controls.Add(this.DungeonLbl);
            this.Controls.Add(this.LevelLbl);
            this.Controls.Add(this.LifeLbl);
            this.Controls.Add(this.NameLbl);
            this.Name = "CharacterRecap";
            this.Size = new System.Drawing.Size(950, 157);
            ((System.ComponentModel.ISupportInitialize)(this.CharacterPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label LifeLbl;
        private System.Windows.Forms.Label LevelLbl;
        private System.Windows.Forms.Label DungeonLbl;
        private System.Windows.Forms.Button LaunchBtn;
        private System.Windows.Forms.PictureBox CharacterPictureBox;
    }
}
