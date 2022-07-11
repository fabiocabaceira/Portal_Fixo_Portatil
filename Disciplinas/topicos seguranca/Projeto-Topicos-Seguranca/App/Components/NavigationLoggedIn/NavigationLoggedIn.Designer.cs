namespace App
{
    partial class NavigationLoggedIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_ProfileName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Logout = new System.Windows.Forms.Button();
            this.Panel_Profile = new System.Windows.Forms.Panel();
            this.Lbl_ProfilePicName = new System.Windows.Forms.Label();
            this.PictureBox_ProfilePic = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.Panel_Profile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_ProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_ProfileName
            // 
            this.Lbl_ProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ProfileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Lbl_ProfileName.Location = new System.Drawing.Point(9, 125);
            this.Lbl_ProfileName.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_ProfileName.Name = "Lbl_ProfileName";
            this.Lbl_ProfileName.Size = new System.Drawing.Size(190, 207);
            this.Lbl_ProfileName.TabIndex = 1;
            this.Lbl_ProfileName.Text = "Nome";
            this.Lbl_ProfileName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Panel_Profile);
            this.panel1.Controls.Add(this.Btn_Logout);
            this.panel1.Controls.Add(this.Lbl_ProfileName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 824);
            this.panel1.TabIndex = 2;
            // 
            // Btn_Logout
            // 
            this.Btn_Logout.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Logout.FlatAppearance.BorderSize = 0;
            this.Btn_Logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.Btn_Logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.Btn_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Logout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Btn_Logout.Image = global::App.Properties.Resources.Logout_icon;
            this.Btn_Logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Logout.Location = new System.Drawing.Point(0, 743);
            this.Btn_Logout.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Logout.Name = "Btn_Logout";
            this.Btn_Logout.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.Btn_Logout.Size = new System.Drawing.Size(208, 55);
            this.Btn_Logout.TabIndex = 3;
            this.Btn_Logout.TabStop = false;
            this.Btn_Logout.Text = "               Logout";
            this.Btn_Logout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Logout.UseVisualStyleBackColor = true;
            this.Btn_Logout.Click += new System.EventHandler(this.Btn_Logout_Click);
            // 
            // Panel_Profile
            // 
            this.Panel_Profile.AutoSize = true;
            this.Panel_Profile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Profile.Controls.Add(this.Lbl_ProfilePicName);
            this.Panel_Profile.Controls.Add(this.PictureBox_ProfilePic);
            this.Panel_Profile.Location = new System.Drawing.Point(66, 30);
            this.Panel_Profile.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_Profile.Name = "Panel_Profile";
            this.Panel_Profile.Size = new System.Drawing.Size(76, 76);
            this.Panel_Profile.TabIndex = 11;
            // 
            // Lbl_ProfilePicName
            // 
            this.Lbl_ProfilePicName.AutoSize = true;
            this.Lbl_ProfilePicName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(86)))), ((int)(((byte)(0)))));
            this.Lbl_ProfilePicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ProfilePicName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Lbl_ProfilePicName.Location = new System.Drawing.Point(11, 23);
            this.Lbl_ProfilePicName.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_ProfilePicName.Name = "Lbl_ProfilePicName";
            this.Lbl_ProfilePicName.Size = new System.Drawing.Size(52, 31);
            this.Lbl_ProfilePicName.TabIndex = 8;
            this.Lbl_ProfilePicName.Text = "PN";
            this.Lbl_ProfilePicName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PictureBox_ProfilePic
            // 
            this.PictureBox_ProfilePic.Image = global::App.Properties.Resources.profile__icon__clr119_86_0;
            this.PictureBox_ProfilePic.Location = new System.Drawing.Point(0, 0);
            this.PictureBox_ProfilePic.Margin = new System.Windows.Forms.Padding(0);
            this.PictureBox_ProfilePic.Name = "PictureBox_ProfilePic";
            this.PictureBox_ProfilePic.Size = new System.Drawing.Size(76, 76);
            this.PictureBox_ProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_ProfilePic.TabIndex = 7;
            this.PictureBox_ProfilePic.TabStop = false;
            // 
            // NavigationLoggedIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(208, 824);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NavigationLoggedIn";
            this.Text = "NavigationLoggedIn";
            this.Load += new System.EventHandler(this.NavigationLoggedIn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Panel_Profile.ResumeLayout(false);
            this.Panel_Profile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_ProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Lbl_ProfileName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Logout;
        private System.Windows.Forms.Panel Panel_Profile;
        private System.Windows.Forms.Label Lbl_ProfilePicName;
        private System.Windows.Forms.PictureBox PictureBox_ProfilePic;
    }
}