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
			this.ExperienceTextBox = new System.Windows.Forms.RichTextBox();
			this.ExperienceLabel = new System.Windows.Forms.Label();
			this.DescriptionTextBox = new System.Windows.Forms.RichTextBox();
			this.ArmorTextBox = new System.Windows.Forms.RichTextBox();
			this.LevelTextBox = new System.Windows.Forms.RichTextBox();
			this.LifeTextBox = new System.Windows.Forms.RichTextBox();
			this.NameTextBox = new System.Windows.Forms.RichTextBox();
			this.NameLabel = new System.Windows.Forms.Label();
			this.LifeLabel = new System.Windows.Forms.Label();
			this.LevelLabel = new System.Windows.Forms.Label();
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.ArmorLabel = new System.Windows.Forms.Label();
			this.DungeonPanel = new System.Windows.Forms.Panel();
			this.MiscTextBox1 = new System.Windows.Forms.RichTextBox();
			this.MiscTextBox2 = new System.Windows.Forms.RichTextBox();
			this.MiscLabel = new System.Windows.Forms.Label();
			this.SquareTextBox2 = new System.Windows.Forms.RichTextBox();
			this.FloorTextBox2 = new System.Windows.Forms.RichTextBox();
			this.DungeonTextBox2 = new System.Windows.Forms.RichTextBox();
			this.DungeonTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SquareTextBox1 = new System.Windows.Forms.RichTextBox();
			this.FloorTextBox1 = new System.Windows.Forms.RichTextBox();
			this.DungeonLabel = new System.Windows.Forms.Label();
			this.FloorLabel = new System.Windows.Forms.Label();
			this.SquareLabel = new System.Windows.Forms.Label();
			this.GoToUpButton = new System.Windows.Forms.Button();
			this.GoToDownButton = new System.Windows.Forms.Button();
			this.GoToLeftButton = new System.Windows.Forms.Button();
			this.GoToRightButton = new System.Windows.Forms.Button();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.ControlPanel = new System.Windows.Forms.Panel();
			this.FloorViewer = new WordMaster.UI.FloorViewer();
			this.CharacterPanel.SuspendLayout();
			this.DungeonPanel.SuspendLayout();
			this.MainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.ControlPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// QuitTheGame
			// 
			this.QuitTheGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.QuitTheGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.QuitTheGame.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.QuitTheGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.QuitTheGame.Location = new System.Drawing.Point(34, 89);
			this.QuitTheGame.Name = "QuitTheGame";
			this.QuitTheGame.Size = new System.Drawing.Size(119, 25);
			this.QuitTheGame.TabIndex = 7;
			this.QuitTheGame.Text = "Quit the game";
			this.QuitTheGame.UseVisualStyleBackColor = false;
			this.QuitTheGame.Click += new System.EventHandler(this.QuitTheGame_Click);
			// 
			// CharacterPanel
			// 
			this.CharacterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CharacterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(159)))), ((int)(((byte)(126)))));
			this.CharacterPanel.Controls.Add(this.ExperienceTextBox);
			this.CharacterPanel.Controls.Add(this.ExperienceLabel);
			this.CharacterPanel.Controls.Add(this.DescriptionTextBox);
			this.CharacterPanel.Controls.Add(this.ArmorTextBox);
			this.CharacterPanel.Controls.Add(this.LevelTextBox);
			this.CharacterPanel.Controls.Add(this.LifeTextBox);
			this.CharacterPanel.Controls.Add(this.NameTextBox);
			this.CharacterPanel.Controls.Add(this.NameLabel);
			this.CharacterPanel.Controls.Add(this.LifeLabel);
			this.CharacterPanel.Controls.Add(this.LevelLabel);
			this.CharacterPanel.Controls.Add(this.DescriptionLabel);
			this.CharacterPanel.Controls.Add(this.ArmorLabel);
			this.CharacterPanel.Cursor = System.Windows.Forms.Cursors.Default;
			this.CharacterPanel.Location = new System.Drawing.Point(3, 73);
			this.CharacterPanel.Name = "CharacterPanel";
			this.CharacterPanel.Size = new System.Drawing.Size(180, 233);
			this.CharacterPanel.TabIndex = 18;
			// 
			// ExperienceTextBox
			// 
			this.ExperienceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.ExperienceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ExperienceTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.ExperienceTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.ExperienceTextBox.Location = new System.Drawing.Point(71, 117);
			this.ExperienceTextBox.Name = "ExperienceTextBox";
			this.ExperienceTextBox.ReadOnly = true;
			this.ExperienceTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
			this.ExperienceTextBox.Size = new System.Drawing.Size(104, 14);
			this.ExperienceTextBox.TabIndex = 24;
			this.ExperienceTextBox.Text = "";
			this.ExperienceTextBox.WordWrap = false;
			// 
			// ExperienceLabel
			// 
			this.ExperienceLabel.AutoSize = true;
			this.ExperienceLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ExperienceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.ExperienceLabel.Location = new System.Drawing.Point(3, 117);
			this.ExperienceLabel.Name = "ExperienceLabel";
			this.ExperienceLabel.Size = new System.Drawing.Size(61, 14);
			this.ExperienceLabel.TabIndex = 23;
			this.ExperienceLabel.Text = "Experience";
			// 
			// DescriptionTextBox
			// 
			this.DescriptionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.DescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DescriptionTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.DescriptionTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.DescriptionTextBox.Location = new System.Drawing.Point(5, 162);
			this.DescriptionTextBox.Name = "DescriptionTextBox";
			this.DescriptionTextBox.ReadOnly = true;
			this.DescriptionTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.DescriptionTextBox.Size = new System.Drawing.Size(170, 65);
			this.DescriptionTextBox.TabIndex = 22;
			this.DescriptionTextBox.Text = "";
			// 
			// ArmorTextBox
			// 
			this.ArmorTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.ArmorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ArmorTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.ArmorTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.ArmorTextBox.Location = new System.Drawing.Point(71, 88);
			this.ArmorTextBox.Name = "ArmorTextBox";
			this.ArmorTextBox.ReadOnly = true;
			this.ArmorTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
			this.ArmorTextBox.Size = new System.Drawing.Size(104, 14);
			this.ArmorTextBox.TabIndex = 21;
			this.ArmorTextBox.Text = "";
			this.ArmorTextBox.WordWrap = false;
			// 
			// LevelTextBox
			// 
			this.LevelTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.LevelTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LevelTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.LevelTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.LevelTextBox.Location = new System.Drawing.Point(71, 62);
			this.LevelTextBox.Name = "LevelTextBox";
			this.LevelTextBox.ReadOnly = true;
			this.LevelTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
			this.LevelTextBox.Size = new System.Drawing.Size(104, 14);
			this.LevelTextBox.TabIndex = 20;
			this.LevelTextBox.Text = "";
			this.LevelTextBox.WordWrap = false;
			// 
			// LifeTextBox
			// 
			this.LifeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.LifeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LifeTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.LifeTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.LifeTextBox.Location = new System.Drawing.Point(71, 35);
			this.LifeTextBox.Name = "LifeTextBox";
			this.LifeTextBox.ReadOnly = true;
			this.LifeTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
			this.LifeTextBox.Size = new System.Drawing.Size(104, 14);
			this.LifeTextBox.TabIndex = 19;
			this.LifeTextBox.Text = "";
			this.LifeTextBox.WordWrap = false;
			// 
			// NameTextBox
			// 
			this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.NameTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.NameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.NameTextBox.Location = new System.Drawing.Point(71, 9);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.ReadOnly = true;
			this.NameTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
			this.NameTextBox.Size = new System.Drawing.Size(104, 14);
			this.NameTextBox.TabIndex = 18;
			this.NameTextBox.Text = "";
			this.NameTextBox.WordWrap = false;
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.NameLabel.Location = new System.Drawing.Point(3, 11);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(40, 14);
			this.NameLabel.TabIndex = 1;
			this.NameLabel.Text = "Name ";
			// 
			// LifeLabel
			// 
			this.LifeLabel.AutoSize = true;
			this.LifeLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LifeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.LifeLabel.Location = new System.Drawing.Point(3, 37);
			this.LifeLabel.Name = "LifeLabel";
			this.LifeLabel.Size = new System.Drawing.Size(28, 14);
			this.LifeLabel.TabIndex = 2;
			this.LifeLabel.Text = "Life ";
			// 
			// LevelLabel
			// 
			this.LevelLabel.AutoSize = true;
			this.LevelLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LevelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.LevelLabel.Location = new System.Drawing.Point(3, 64);
			this.LevelLabel.Name = "LevelLabel";
			this.LevelLabel.Size = new System.Drawing.Size(36, 14);
			this.LevelLabel.TabIndex = 3;
			this.LevelLabel.Text = "Level ";
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.AutoSize = true;
			this.DescriptionLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.DescriptionLabel.Location = new System.Drawing.Point(3, 146);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(63, 14);
			this.DescriptionLabel.TabIndex = 4;
			this.DescriptionLabel.Text = "Description";
			// 
			// ArmorLabel
			// 
			this.ArmorLabel.AutoSize = true;
			this.ArmorLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ArmorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.ArmorLabel.Location = new System.Drawing.Point(3, 90);
			this.ArmorLabel.Name = "ArmorLabel";
			this.ArmorLabel.Size = new System.Drawing.Size(38, 14);
			this.ArmorLabel.TabIndex = 14;
			this.ArmorLabel.Text = "Armor";
			// 
			// DungeonPanel
			// 
			this.DungeonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DungeonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(159)))), ((int)(((byte)(126)))));
			this.DungeonPanel.Controls.Add(this.MiscTextBox1);
			this.DungeonPanel.Controls.Add(this.MiscTextBox2);
			this.DungeonPanel.Controls.Add(this.MiscLabel);
			this.DungeonPanel.Controls.Add(this.SquareTextBox2);
			this.DungeonPanel.Controls.Add(this.FloorTextBox2);
			this.DungeonPanel.Controls.Add(this.DungeonTextBox2);
			this.DungeonPanel.Controls.Add(this.DungeonTextBox1);
			this.DungeonPanel.Controls.Add(this.SquareTextBox1);
			this.DungeonPanel.Controls.Add(this.FloorTextBox1);
			this.DungeonPanel.Controls.Add(this.DungeonLabel);
			this.DungeonPanel.Controls.Add(this.FloorLabel);
			this.DungeonPanel.Controls.Add(this.SquareLabel);
			this.DungeonPanel.Cursor = System.Windows.Forms.Cursors.Default;
			this.DungeonPanel.Location = new System.Drawing.Point(2, 313);
			this.DungeonPanel.Name = "DungeonPanel";
			this.DungeonPanel.Size = new System.Drawing.Size(180, 277);
			this.DungeonPanel.TabIndex = 19;
			// 
			// MiscTextBox1
			// 
			this.MiscTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.MiscTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MiscTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.MiscTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.MiscTextBox1.Location = new System.Drawing.Point(57, 217);
			this.MiscTextBox1.Name = "MiscTextBox1";
			this.MiscTextBox1.ReadOnly = true;
			this.MiscTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
			this.MiscTextBox1.Size = new System.Drawing.Size(118, 14);
			this.MiscTextBox1.TabIndex = 27;
			this.MiscTextBox1.Text = "";
			this.MiscTextBox1.WordWrap = false;
			// 
			// MiscTextBox2
			// 
			this.MiscTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.MiscTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MiscTextBox2.Cursor = System.Windows.Forms.Cursors.Default;
			this.MiscTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.MiscTextBox2.Location = new System.Drawing.Point(6, 237);
			this.MiscTextBox2.Name = "MiscTextBox2";
			this.MiscTextBox2.ReadOnly = true;
			this.MiscTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.MiscTextBox2.Size = new System.Drawing.Size(169, 35);
			this.MiscTextBox2.TabIndex = 26;
			this.MiscTextBox2.Text = "";
			// 
			// MiscLabel
			// 
			this.MiscLabel.AutoSize = true;
			this.MiscLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MiscLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.MiscLabel.Location = new System.Drawing.Point(3, 217);
			this.MiscLabel.Name = "MiscLabel";
			this.MiscLabel.Size = new System.Drawing.Size(30, 14);
			this.MiscLabel.TabIndex = 25;
			this.MiscLabel.Text = "Misc";
			// 
			// SquareTextBox2
			// 
			this.SquareTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.SquareTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SquareTextBox2.Cursor = System.Windows.Forms.Cursors.Default;
			this.SquareTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.SquareTextBox2.Location = new System.Drawing.Point(6, 165);
			this.SquareTextBox2.Name = "SquareTextBox2";
			this.SquareTextBox2.ReadOnly = true;
			this.SquareTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.SquareTextBox2.Size = new System.Drawing.Size(169, 35);
			this.SquareTextBox2.TabIndex = 24;
			this.SquareTextBox2.Text = "";
			// 
			// FloorTextBox2
			// 
			this.FloorTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.FloorTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.FloorTextBox2.Cursor = System.Windows.Forms.Cursors.Default;
			this.FloorTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.FloorTextBox2.Location = new System.Drawing.Point(6, 94);
			this.FloorTextBox2.Name = "FloorTextBox2";
			this.FloorTextBox2.ReadOnly = true;
			this.FloorTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.FloorTextBox2.Size = new System.Drawing.Size(169, 35);
			this.FloorTextBox2.TabIndex = 23;
			this.FloorTextBox2.Text = "";
			// 
			// DungeonTextBox2
			// 
			this.DungeonTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.DungeonTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DungeonTextBox2.Cursor = System.Windows.Forms.Cursors.Default;
			this.DungeonTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.DungeonTextBox2.Location = new System.Drawing.Point(6, 25);
			this.DungeonTextBox2.Name = "DungeonTextBox2";
			this.DungeonTextBox2.ReadOnly = true;
			this.DungeonTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.DungeonTextBox2.Size = new System.Drawing.Size(169, 35);
			this.DungeonTextBox2.TabIndex = 22;
			this.DungeonTextBox2.Text = "";
			// 
			// DungeonTextBox1
			// 
			this.DungeonTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.DungeonTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DungeonTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.DungeonTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.DungeonTextBox1.Location = new System.Drawing.Point(57, 5);
			this.DungeonTextBox1.Name = "DungeonTextBox1";
			this.DungeonTextBox1.ReadOnly = true;
			this.DungeonTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
			this.DungeonTextBox1.Size = new System.Drawing.Size(118, 14);
			this.DungeonTextBox1.TabIndex = 21;
			this.DungeonTextBox1.Text = "";
			this.DungeonTextBox1.WordWrap = false;
			// 
			// SquareTextBox1
			// 
			this.SquareTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.SquareTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SquareTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.SquareTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.SquareTextBox1.Location = new System.Drawing.Point(57, 145);
			this.SquareTextBox1.Name = "SquareTextBox1";
			this.SquareTextBox1.ReadOnly = true;
			this.SquareTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
			this.SquareTextBox1.Size = new System.Drawing.Size(118, 14);
			this.SquareTextBox1.TabIndex = 20;
			this.SquareTextBox1.Text = "";
			this.SquareTextBox1.WordWrap = false;
			// 
			// FloorTextBox1
			// 
			this.FloorTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.FloorTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.FloorTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.FloorTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.FloorTextBox1.Location = new System.Drawing.Point(57, 74);
			this.FloorTextBox1.Name = "FloorTextBox1";
			this.FloorTextBox1.ReadOnly = true;
			this.FloorTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
			this.FloorTextBox1.Size = new System.Drawing.Size(118, 14);
			this.FloorTextBox1.TabIndex = 19;
			this.FloorTextBox1.Text = "";
			this.FloorTextBox1.WordWrap = false;
			// 
			// DungeonLabel
			// 
			this.DungeonLabel.AutoSize = true;
			this.DungeonLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DungeonLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.DungeonLabel.Location = new System.Drawing.Point(3, 5);
			this.DungeonLabel.Name = "DungeonLabel";
			this.DungeonLabel.Size = new System.Drawing.Size(51, 14);
			this.DungeonLabel.TabIndex = 15;
			this.DungeonLabel.Text = "Dungeon";
			// 
			// FloorLabel
			// 
			this.FloorLabel.AutoSize = true;
			this.FloorLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FloorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.FloorLabel.Location = new System.Drawing.Point(3, 74);
			this.FloorLabel.Name = "FloorLabel";
			this.FloorLabel.Size = new System.Drawing.Size(32, 14);
			this.FloorLabel.TabIndex = 16;
			this.FloorLabel.Text = "Floor";
			// 
			// SquareLabel
			// 
			this.SquareLabel.AutoSize = true;
			this.SquareLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SquareLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.SquareLabel.Location = new System.Drawing.Point(3, 145);
			this.SquareLabel.Name = "SquareLabel";
			this.SquareLabel.Size = new System.Drawing.Size(41, 14);
			this.SquareLabel.TabIndex = 17;
			this.SquareLabel.Text = "Square";
			// 
			// GoToUpButton
			// 
			this.GoToUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.GoToUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GoToUpButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GoToUpButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.GoToUpButton.Location = new System.Drawing.Point(64, 11);
			this.GoToUpButton.Name = "GoToUpButton";
			this.GoToUpButton.Size = new System.Drawing.Size(54, 25);
			this.GoToUpButton.TabIndex = 13;
			this.GoToUpButton.Text = "Up";
			this.GoToUpButton.UseVisualStyleBackColor = false;
			this.GoToUpButton.Click += new System.EventHandler(this.GoToUpButton_Click);
			// 
			// GoToDownButton
			// 
			this.GoToDownButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.GoToDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GoToDownButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GoToDownButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.GoToDownButton.Location = new System.Drawing.Point(64, 42);
			this.GoToDownButton.Name = "GoToDownButton";
			this.GoToDownButton.Size = new System.Drawing.Size(54, 25);
			this.GoToDownButton.TabIndex = 11;
			this.GoToDownButton.Text = "Down";
			this.GoToDownButton.UseVisualStyleBackColor = false;
			this.GoToDownButton.Click += new System.EventHandler(this.GoToDownButton_Click);
			// 
			// GoToLeftButton
			// 
			this.GoToLeftButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.GoToLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GoToLeftButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GoToLeftButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.GoToLeftButton.Location = new System.Drawing.Point(6, 26);
			this.GoToLeftButton.Name = "GoToLeftButton";
			this.GoToLeftButton.Size = new System.Drawing.Size(54, 25);
			this.GoToLeftButton.TabIndex = 10;
			this.GoToLeftButton.Text = "Left";
			this.GoToLeftButton.UseVisualStyleBackColor = false;
			this.GoToLeftButton.Click += new System.EventHandler(this.GoToLeftButton_Click);
			// 
			// GoToRightButton
			// 
			this.GoToRightButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.GoToRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GoToRightButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GoToRightButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.GoToRightButton.Location = new System.Drawing.Point(122, 26);
			this.GoToRightButton.Name = "GoToRightButton";
			this.GoToRightButton.Size = new System.Drawing.Size(54, 25);
			this.GoToRightButton.TabIndex = 12;
			this.GoToRightButton.Text = "Right";
			this.GoToRightButton.UseVisualStyleBackColor = false;
			this.GoToRightButton.Click += new System.EventHandler(this.GoToRightButton_Click);
			// 
			// MainPanel
			// 
			this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.MainPanel.Controls.Add(this.pictureBox1);
			this.MainPanel.Controls.Add(this.DungeonPanel);
			this.MainPanel.Controls.Add(this.CharacterPanel);
			this.MainPanel.Controls.Add(this.ControlPanel);
			this.MainPanel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainPanel.Location = new System.Drawing.Point(757, 6);
			this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(184, 750);
			this.MainPanel.TabIndex = 1;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::WordMaster.UI.Properties.Resources.Logo_v1;
			this.pictureBox1.Location = new System.Drawing.Point(2, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(180, 65);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 21;
			this.pictureBox1.TabStop = false;
			// 
			// ControlPanel
			// 
			this.ControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(159)))), ((int)(((byte)(126)))));
			this.ControlPanel.Controls.Add(this.GoToUpButton);
			this.ControlPanel.Controls.Add(this.GoToDownButton);
			this.ControlPanel.Controls.Add(this.GoToRightButton);
			this.ControlPanel.Controls.Add(this.QuitTheGame);
			this.ControlPanel.Controls.Add(this.GoToLeftButton);
			this.ControlPanel.Location = new System.Drawing.Point(2, 596);
			this.ControlPanel.Name = "ControlPanel";
			this.ControlPanel.Size = new System.Drawing.Size(180, 117);
			this.ControlPanel.TabIndex = 20;
			// 
			// FloorViewer
			// 
			this.FloorViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FloorViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.FloorViewer.Cursor = System.Windows.Forms.Cursors.Default;
			this.FloorViewer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FloorViewer.Location = new System.Drawing.Point(3, 6);
			this.FloorViewer.Margin = new System.Windows.Forms.Padding(0);
			this.FloorViewer.Name = "FloorViewer";
			this.FloorViewer.Size = new System.Drawing.Size(750, 750);
			this.FloorViewer.TabIndex = 2;
			this.FloorViewer.Text = "FloorViewer";
			// 
			// InGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(944, 762);
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.FloorViewer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "InGame";
			this.RightToLeftLayout = true;
			this.ShowInTaskbar = false;
			this.Text = "Word Master";
			this.Load += new System.EventHandler(this.InGame_Load);
			this.CharacterPanel.ResumeLayout(false);
			this.CharacterPanel.PerformLayout();
			this.DungeonPanel.ResumeLayout(false);
			this.DungeonPanel.PerformLayout();
			this.MainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ControlPanel.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private FloorViewer FloorViewer;
		private Button QuitTheGame;
		private Panel CharacterPanel;
		private Label NameLabel;
		private Label LifeLabel;
		private Label LevelLabel;
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
		private Panel ControlPanel;
		private RichTextBox NameTextBox;
		private RichTextBox DescriptionTextBox;
		private RichTextBox ArmorTextBox;
		private RichTextBox LevelTextBox;
		private RichTextBox LifeTextBox;
		private RichTextBox DungeonTextBox1;
		private RichTextBox SquareTextBox1;
		private RichTextBox FloorTextBox1;
		private RichTextBox DungeonTextBox2;
		private RichTextBox FloorTextBox2;
		private RichTextBox SquareTextBox2;
		private RichTextBox MiscTextBox1;
		private RichTextBox MiscTextBox2;
		private Label MiscLabel;
		private RichTextBox ExperienceTextBox;
		private Label ExperienceLabel;
		private PictureBox pictureBox1;
    }
}