namespace WordMaster.UI
{
    partial class CharacterResume
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
            this.LevelLbl = new System.Windows.Forms.Label();
            this.DungeonLbl = new System.Windows.Forms.Label();
            this.HealthLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DeleteCharacterBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(70, 13);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(38, 13);
            this.NameLbl.TabIndex = 0;
            this.NameLbl.Text = "Nom : ";
            // 
            // LevelLbl
            // 
            this.LevelLbl.AutoSize = true;
            this.LevelLbl.Location = new System.Drawing.Point(70, 35);
            this.LevelLbl.Name = "LevelLbl";
            this.LevelLbl.Size = new System.Drawing.Size(42, 13);
            this.LevelLbl.TabIndex = 1;
            this.LevelLbl.Text = "Level : ";
            // 
            // DungeonLbl
            // 
            this.DungeonLbl.AutoSize = true;
            this.DungeonLbl.Location = new System.Drawing.Point(70, 87);
            this.DungeonLbl.Name = "DungeonLbl";
            this.DungeonLbl.Size = new System.Drawing.Size(60, 13);
            this.DungeonLbl.TabIndex = 2;
            this.DungeonLbl.Text = "Dungeon : ";
            // 
            // HealthLbl
            // 
            this.HealthLbl.AutoSize = true;
            this.HealthLbl.Location = new System.Drawing.Point(70, 61);
            this.HealthLbl.Name = "HealthLbl";
            this.HealthLbl.Size = new System.Drawing.Size(47, 13);
            this.HealthLbl.TabIndex = 3;
            this.HealthLbl.Text = "Health : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 65);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // DeleteCharacterBtn
            // 
            this.DeleteCharacterBtn.Location = new System.Drawing.Point(156, 102);
            this.DeleteCharacterBtn.Name = "DeleteCharacterBtn";
            this.DeleteCharacterBtn.Size = new System.Drawing.Size(26, 22);
            this.DeleteCharacterBtn.TabIndex = 5;
            this.DeleteCharacterBtn.Text = "X";
            this.DeleteCharacterBtn.UseVisualStyleBackColor = true;
            // 
            // CharacterResume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeleteCharacterBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.HealthLbl);
            this.Controls.Add(this.DungeonLbl);
            this.Controls.Add(this.LevelLbl);
            this.Controls.Add(this.NameLbl);
            this.Name = "CharacterResume";
            this.Size = new System.Drawing.Size(199, 137);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label LevelLbl;
        private System.Windows.Forms.Label DungeonLbl;
        private System.Windows.Forms.Label HealthLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button DeleteCharacterBtn;
    }
}
