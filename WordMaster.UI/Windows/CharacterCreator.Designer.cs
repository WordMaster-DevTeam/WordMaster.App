﻿namespace WordMaster.UI
{
    partial class CharacterCreator
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
            System.Windows.Forms.OpenFileDialog openFileDialog;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterCreator));
            this.AvatarLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.PathLbl = new System.Windows.Forms.Label();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.AvatarPictureBox = new System.Windows.Forms.PictureBox();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BackBtn = new System.Windows.Forms.Button();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // AvatarLbl
            // 
            this.AvatarLbl.AutoSize = true;
            this.AvatarLbl.BackColor = System.Drawing.Color.Gray;
            this.AvatarLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvatarLbl.Location = new System.Drawing.Point(131, 60);
            this.AvatarLbl.Name = "AvatarLbl";
            this.AvatarLbl.Size = new System.Drawing.Size(152, 29);
            this.AvatarLbl.TabIndex = 0;
            this.AvatarLbl.Text = "Your avatar : ";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.BackColor = System.Drawing.Color.Gray;
            this.NameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.Location = new System.Drawing.Point(135, 102);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(148, 29);
            this.NameLbl.TabIndex = 1;
            this.NameLbl.Text = "Your name : ";
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.AutoSize = true;
            this.DescriptionLbl.BackColor = System.Drawing.Color.Gray;
            this.DescriptionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLbl.Location = new System.Drawing.Point(76, 144);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(207, 29);
            this.DescriptionLbl.TabIndex = 2;
            this.DescriptionLbl.Text = "Your description : ";
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.BackColor = System.Drawing.Color.BurlyWood;
            this.BrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseBtn.Location = new System.Drawing.Point(298, 60);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(90, 26);
            this.BrowseBtn.TabIndex = 3;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = false;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // _nameTextBox
            // 
            this._nameTextBox.BackColor = System.Drawing.Color.BurlyWood;
            this._nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nameTextBox.Location = new System.Drawing.Point(298, 105);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(363, 26);
            this._nameTextBox.TabIndex = 4;
            // 
            // _descriptionRichTextBox
            // 
            this._descriptionRichTextBox.BackColor = System.Drawing.Color.BurlyWood;
            this._descriptionRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._descriptionRichTextBox.Location = new System.Drawing.Point(298, 144);
            this._descriptionRichTextBox.Name = "_descriptionRichTextBox";
            this._descriptionRichTextBox.Size = new System.Drawing.Size(468, 205);
            this._descriptionRichTextBox.TabIndex = 5;
            this._descriptionRichTextBox.Text = "";
            // 
            // PathLbl
            // 
            this.PathLbl.AutoSize = true;
            this.PathLbl.BackColor = System.Drawing.Color.Gray;
            this.PathLbl.Location = new System.Drawing.Point(394, 67);
            this.PathLbl.Name = "PathLbl";
            this.PathLbl.Size = new System.Drawing.Size(29, 13);
            this.PathLbl.TabIndex = 7;
            this.PathLbl.Text = "Path";
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.Location = new System.Drawing.Point(286, 9);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(231, 42);
            this.TitleLbl.TabIndex = 9;
            this.TitleLbl.Text = "Word Master";
            // 
            // AvatarPictureBox
            // 
            this.AvatarPictureBox.BackColor = System.Drawing.Color.BurlyWood;
            this.AvatarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AvatarPictureBox.Location = new System.Drawing.Point(667, 11);
            this.AvatarPictureBox.Name = "AvatarPictureBox";
            this.AvatarPictureBox.Size = new System.Drawing.Size(98, 119);
            this.AvatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AvatarPictureBox.TabIndex = 10;
            this.AvatarPictureBox.TabStop = false;
            // 
            // CreateBtn
            // 
            this.CreateBtn.BackColor = System.Drawing.Color.BurlyWood;
            this.CreateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateBtn.Location = new System.Drawing.Point(95, 377);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(88, 29);
            this.CreateBtn.TabIndex = 11;
            this.CreateBtn.Text = "Create";
            this.CreateBtn.UseVisualStyleBackColor = false;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.BackBtn);
            this.panel1.Controls.Add(this.CreateBtn);
            this.panel1.Controls.Add(this.AvatarPictureBox);
            this.panel1.Controls.Add(this.PathLbl);
            this.panel1.Controls.Add(this._descriptionRichTextBox);
            this.panel1.Controls.Add(this._nameTextBox);
            this.panel1.Controls.Add(this.BrowseBtn);
            this.panel1.Controls.Add(this.DescriptionLbl);
            this.panel1.Controls.Add(this.NameLbl);
            this.panel1.Controls.Add(this.AvatarLbl);
            this.panel1.Location = new System.Drawing.Point(0, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 435);
            this.panel1.TabIndex = 12;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.BurlyWood;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Location = new System.Drawing.Point(677, 377);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(88, 29);
            this.BackBtn.TabIndex = 12;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // CharacterCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 516);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TitleLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CharacterCreator";
            this.Text = "CreateCharacter";
            this.Load += new System.EventHandler(this.CreateCharacter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AvatarLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.RichTextBox _descriptionRichTextBox;
        private System.Windows.Forms.Label PathLbl;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.PictureBox AvatarPictureBox;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BackBtn;
    }
}