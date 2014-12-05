namespace WordMaster.UI
{
    partial class DungeonRecap
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.FloorsCountLbl = new System.Windows.Forms.Label();
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.SelectBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 156);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(152, 14);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(44, 13);
            this.NameLbl.TabIndex = 1;
            this.NameLbl.Text = "Name : ";
            // 
            // FloorsCountLbl
            // 
            this.FloorsCountLbl.AutoSize = true;
            this.FloorsCountLbl.Location = new System.Drawing.Point(152, 36);
            this.FloorsCountLbl.Name = "FloorsCountLbl";
            this.FloorsCountLbl.Size = new System.Drawing.Size(44, 13);
            this.FloorsCountLbl.TabIndex = 2;
            this.FloorsCountLbl.Text = "Floors : ";
            this.FloorsCountLbl.Click += new System.EventHandler(this.label2_Click);
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.AutoSize = true;
            this.DescriptionLbl.Location = new System.Drawing.Point(377, 14);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(69, 13);
            this.DescriptionLbl.TabIndex = 3;
            this.DescriptionLbl.Text = "Description : ";
            // 
            // SelectBtn
            // 
            this.SelectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectBtn.Location = new System.Drawing.Point(1007, 124);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(90, 35);
            this.SelectBtn.TabIndex = 4;
            this.SelectBtn.Text = "Select";
            this.SelectBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SelectBtn.UseVisualStyleBackColor = true;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // DungeonRecap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.SelectBtn);
            this.Controls.Add(this.DescriptionLbl);
            this.Controls.Add(this.FloorsCountLbl);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DungeonRecap";
            this.Size = new System.Drawing.Size(1100, 162);
            this.Load += new System.EventHandler(this.DungeonRecap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label FloorsCountLbl;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.Button SelectBtn;
    }
}
