using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMaster.Gameplay;
using WordMaster.Rendering;

namespace WordMaster.UI
{
    partial class InGame : Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InGame));
			this.QuitTheGame = new System.Windows.Forms.Button();
			this.CharacterPanel = new System.Windows.Forms.Panel();
			this.NameLabel = new System.Windows.Forms.Label();
			this.LifeLabel = new System.Windows.Forms.Label();
			this.LeveLabel = new System.Windows.Forms.Label();
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.ArmorLabel = new System.Windows.Forms.Label();
			this.DungeonPanel = new System.Windows.Forms.Panel();
			this.DungeonLabel = new System.Windows.Forms.Label();
			this.FloorLabel = new System.Windows.Forms.Label();
			this.SquareLabel = new System.Windows.Forms.Label();
			this.GoToUpButton = new System.Windows.Forms.Button();
			this.GoToDownButton = new System.Windows.Forms.Button();
			this.GoToLeftButton = new System.Windows.Forms.Button();
			this.GoToRightButton = new System.Windows.Forms.Button();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.FloorViewer = new WordMaster.UI.FloorViewer();
			this.CharacterPanel.SuspendLayout();
			this.DungeonPanel.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// QuitTheGame
			// 
			this.QuitTheGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.QuitTheGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(220)))));
			this.QuitTheGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.QuitTheGame.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.QuitTheGame.Location = new System.Drawing.Point(6, 571);
			this.QuitTheGame.Name = "QuitTheGame";
			this.QuitTheGame.Size = new System.Drawing.Size(190, 26);
			this.QuitTheGame.TabIndex = 7;
			this.QuitTheGame.Text = "Quit the game";
			this.QuitTheGame.UseVisualStyleBackColor = false;
			this.QuitTheGame.Click += new System.EventHandler(this.QuitTheGame_Click);
			// 
			// CharacterPanel
			// 
			this.CharacterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CharacterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
			this.CharacterPanel.Controls.Add(this.NameLabel);
			this.CharacterPanel.Controls.Add(this.LifeLabel);
			this.CharacterPanel.Controls.Add(this.LeveLabel);
			this.CharacterPanel.Controls.Add(this.DescriptionLabel);
			this.CharacterPanel.Controls.Add(this.ArmorLabel);
			this.CharacterPanel.Cursor = System.Windows.Forms.Cursors.Default;
			this.CharacterPanel.Location = new System.Drawing.Point(6, 286);
			this.CharacterPanel.Name = "CharacterPanel";
			this.CharacterPanel.Size = new System.Drawing.Size(189, 197);
			this.CharacterPanel.TabIndex = 18;
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameLabel.Location = new System.Drawing.Point(15, 15);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(42, 14);
			this.NameLabel.TabIndex = 1;
			this.NameLabel.Text = "Name ";
			this.NameLabel.Click += new System.EventHandler(this.Namelbl_Click);
			// 
			// LifeLabel
			// 
			this.LifeLabel.AutoSize = true;
			this.LifeLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LifeLabel.Location = new System.Drawing.Point(15, 45);
			this.LifeLabel.Name = "LifeLabel";
			this.LifeLabel.Size = new System.Drawing.Size(30, 14);
			this.LifeLabel.TabIndex = 2;
			this.LifeLabel.Text = "Life ";
			this.LifeLabel.Click += new System.EventHandler(this.Lifelbl_Click);
			// 
			// LeveLabel
			// 
			this.LeveLabel.AutoSize = true;
			this.LeveLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LeveLabel.Location = new System.Drawing.Point(15, 75);
			this.LeveLabel.Name = "LeveLabel";
			this.LeveLabel.Size = new System.Drawing.Size(38, 14);
			this.LeveLabel.TabIndex = 3;
			this.LeveLabel.Text = "Level ";
			this.LeveLabel.Click += new System.EventHandler(this.label3_Click);
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.AutoSize = true;
			this.DescriptionLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DescriptionLabel.Location = new System.Drawing.Point(15, 135);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(69, 14);
			this.DescriptionLabel.TabIndex = 4;
			this.DescriptionLabel.Text = "Description";
			this.DescriptionLabel.Click += new System.EventHandler(this.DescriptionLabel_Click);
			// 
			// ArmorLabel
			// 
			this.ArmorLabel.AutoSize = true;
			this.ArmorLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ArmorLabel.Location = new System.Drawing.Point(15, 105);
			this.ArmorLabel.Name = "ArmorLabel";
			this.ArmorLabel.Size = new System.Drawing.Size(39, 14);
			this.ArmorLabel.TabIndex = 14;
			this.ArmorLabel.Text = "Armor";
			// 
			// DungeonPanel
			// 
			this.DungeonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DungeonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
			this.DungeonPanel.Controls.Add(this.DungeonLabel);
			this.DungeonPanel.Controls.Add(this.FloorLabel);
			this.DungeonPanel.Controls.Add(this.SquareLabel);
			this.DungeonPanel.Cursor = System.Windows.Forms.Cursors.Default;
			this.DungeonPanel.Location = new System.Drawing.Point(6, 174);
			this.DungeonPanel.Name = "DungeonPanel";
			this.DungeonPanel.Size = new System.Drawing.Size(189, 106);
			this.DungeonPanel.TabIndex = 19;
			// 
			// DungeonLabel
			// 
			this.DungeonLabel.AutoSize = true;
			this.DungeonLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DungeonLabel.Location = new System.Drawing.Point(15, 15);
			this.DungeonLabel.Name = "DungeonLabel";
			this.DungeonLabel.Size = new System.Drawing.Size(56, 14);
			this.DungeonLabel.TabIndex = 15;
			this.DungeonLabel.Text = "Dungeon";
			// 
			// FloorLabel
			// 
			this.FloorLabel.AutoSize = true;
			this.FloorLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FloorLabel.Location = new System.Drawing.Point(15, 45);
			this.FloorLabel.Name = "FloorLabel";
			this.FloorLabel.Size = new System.Drawing.Size(35, 14);
			this.FloorLabel.TabIndex = 16;
			this.FloorLabel.Text = "Floor";
			this.FloorLabel.Click += new System.EventHandler(this.FloorLabel_Click);
			// 
			// SquareLabel
			// 
			this.SquareLabel.AutoSize = true;
			this.SquareLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SquareLabel.Location = new System.Drawing.Point(15, 75);
			this.SquareLabel.Name = "SquareLabel";
			this.SquareLabel.Size = new System.Drawing.Size(45, 14);
			this.SquareLabel.TabIndex = 17;
			this.SquareLabel.Text = "Square";
			// 
			// GoToUpButton
			// 
			this.GoToUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GoToUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.GoToUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GoToUpButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GoToUpButton.Location = new System.Drawing.Point(71, 489);
			this.GoToUpButton.Name = "GoToUpButton";
			this.GoToUpButton.Size = new System.Drawing.Size(59, 35);
			this.GoToUpButton.TabIndex = 13;
			this.GoToUpButton.Text = "Up";
			this.GoToUpButton.UseVisualStyleBackColor = false;
			this.GoToUpButton.Click += new System.EventHandler(this.GoToUpButton_Click);
			// 
			// GoToDownButton
			// 
			this.GoToDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GoToDownButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.GoToDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GoToDownButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GoToDownButton.Location = new System.Drawing.Point(71, 530);
			this.GoToDownButton.Name = "GoToDownButton";
			this.GoToDownButton.Size = new System.Drawing.Size(59, 35);
			this.GoToDownButton.TabIndex = 11;
			this.GoToDownButton.Text = "Down";
			this.GoToDownButton.UseVisualStyleBackColor = false;
			this.GoToDownButton.Click += new System.EventHandler(this.GoToDownButton_Click);
			// 
			// GoToLeftButton
			// 
			this.GoToLeftButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GoToLeftButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.GoToLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GoToLeftButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GoToLeftButton.Location = new System.Drawing.Point(6, 530);
			this.GoToLeftButton.Name = "GoToLeftButton";
			this.GoToLeftButton.Size = new System.Drawing.Size(59, 35);
			this.GoToLeftButton.TabIndex = 10;
			this.GoToLeftButton.Text = "Left";
			this.GoToLeftButton.UseVisualStyleBackColor = false;
			this.GoToLeftButton.Click += new System.EventHandler(this.GoToLeftButton_Click);
			// 
			// GoToRightButton
			// 
			this.GoToRightButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GoToRightButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.GoToRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GoToRightButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GoToRightButton.Location = new System.Drawing.Point(136, 530);
			this.GoToRightButton.Name = "GoToRightButton";
			this.GoToRightButton.Size = new System.Drawing.Size(59, 35);
			this.GoToRightButton.TabIndex = 12;
			this.GoToRightButton.Text = "Right";
			this.GoToRightButton.UseVisualStyleBackColor = false;
			this.GoToRightButton.Click += new System.EventHandler(this.GoToRightButton_Click);
			// 
			// MainPanel
			// 
			this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(50)))));
			this.MainPanel.Controls.Add(this.GoToRightButton);
			this.MainPanel.Controls.Add(this.GoToLeftButton);
			this.MainPanel.Controls.Add(this.GoToDownButton);
			this.MainPanel.Controls.Add(this.GoToUpButton);
			this.MainPanel.Controls.Add(this.DungeonPanel);
			this.MainPanel.Controls.Add(this.CharacterPanel);
			this.MainPanel.Controls.Add(this.QuitTheGame);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.MainPanel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainPanel.Location = new System.Drawing.Point(600, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(200, 600);
			this.MainPanel.TabIndex = 1;
			this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// FloorViewer
			// 
			this.FloorViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.FloorViewer.Cursor = System.Windows.Forms.Cursors.Cross;
			this.FloorViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FloorViewer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FloorViewer.Location = new System.Drawing.Point(0, 0);
			this.FloorViewer.Name = "FloorViewer";
			this.FloorViewer.Size = new System.Drawing.Size(600, 600);
			this.FloorViewer.TabIndex = 2;
			this.FloorViewer.Text = "FloorViewer";
			this.FloorViewer.Click += new System.EventHandler(this.floorView1_Click);
			// 
			// InGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.FloorViewer);
			this.Controls.Add(this.MainPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(1920, 1440);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "InGame";
			this.RightToLeftLayout = true;
			this.ShowInTaskbar = false;
			this.Text = "Word Master";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.InGame_Load);
			this.CharacterPanel.ResumeLayout(false);
			this.CharacterPanel.PerformLayout();
			this.DungeonPanel.ResumeLayout(false);
			this.DungeonPanel.PerformLayout();
			this.MainPanel.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private FloorViewer FloorViewer;
		private Button QuitTheGame;
		private Panel CharacterPanel;
		private Label NameLabel;
		private Label LifeLabel;
		private Label LeveLabel;
		private Label DescriptionLabel;
		private Label ArmorLabel;
		private Panel DungeonPanel;
		private Label DungeonLabel;
		private Label FloorLabel;
		private Label SquareLabel;
		private Button GoToUpButton;
		private Button GoToDownButton;
		private Button GoToLeftButton;
		private Button GoToRightButton;
		private Panel MainPanel;
    }
}