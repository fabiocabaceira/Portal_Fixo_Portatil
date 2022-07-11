namespace App
{
    partial class YourMessage
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
            this.Lbl_ProfileNameHolder = new System.Windows.Forms.Label();
            this.TxtBox_MessageHolder = new System.Windows.Forms.RichTextBox();
            this.Panel_Profile = new System.Windows.Forms.Panel();
            this.Lbl_ProfilePicName = new System.Windows.Forms.Label();
            this.PictureBox_ProfilePic = new System.Windows.Forms.PictureBox();
            this.Panel_Profile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_ProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_ProfileNameHolder
            // 
            this.Lbl_ProfileNameHolder.AutoSize = true;
            this.Lbl_ProfileNameHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ProfileNameHolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Lbl_ProfileNameHolder.Location = new System.Drawing.Point(55, 0);
            this.Lbl_ProfileNameHolder.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_ProfileNameHolder.Name = "Lbl_ProfileNameHolder";
            this.Lbl_ProfileNameHolder.Size = new System.Drawing.Size(105, 20);
            this.Lbl_ProfileNameHolder.TabIndex = 1;
            this.Lbl_ProfileNameHolder.Text = "nome pessoa";
            this.Lbl_ProfileNameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtBox_MessageHolder
            // 
            this.TxtBox_MessageHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBox_MessageHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.TxtBox_MessageHolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtBox_MessageHolder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtBox_MessageHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBox_MessageHolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.TxtBox_MessageHolder.Location = new System.Drawing.Point(65, 38);
            this.TxtBox_MessageHolder.Margin = new System.Windows.Forms.Padding(0);
            this.TxtBox_MessageHolder.MinimumSize = new System.Drawing.Size(430, 22);
            this.TxtBox_MessageHolder.Name = "TxtBox_MessageHolder";
            this.TxtBox_MessageHolder.ReadOnly = true;
            this.TxtBox_MessageHolder.Size = new System.Drawing.Size(430, 22);
            this.TxtBox_MessageHolder.TabIndex = 3;
            this.TxtBox_MessageHolder.TabStop = false;
            this.TxtBox_MessageHolder.Text = "texto";
            this.TxtBox_MessageHolder.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.TxtBox_MessageHolder_ContentsResized);
            // 
            // Panel_Profile
            // 
            this.Panel_Profile.AutoSize = true;
            this.Panel_Profile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Profile.Controls.Add(this.Lbl_ProfilePicName);
            this.Panel_Profile.Controls.Add(this.PictureBox_ProfilePic);
            this.Panel_Profile.Location = new System.Drawing.Point(0, 0);
            this.Panel_Profile.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_Profile.Name = "Panel_Profile";
            this.Panel_Profile.Size = new System.Drawing.Size(48, 48);
            this.Panel_Profile.TabIndex = 10;
            // 
            // Lbl_ProfilePicName
            // 
            this.Lbl_ProfilePicName.AutoSize = true;
            this.Lbl_ProfilePicName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(86)))), ((int)(((byte)(0)))));
            this.Lbl_ProfilePicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Lbl_ProfilePicName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Lbl_ProfilePicName.Location = new System.Drawing.Point(7, 13);
            this.Lbl_ProfilePicName.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_ProfilePicName.Name = "Lbl_ProfilePicName";
            this.Lbl_ProfilePicName.Size = new System.Drawing.Size(35, 22);
            this.Lbl_ProfilePicName.TabIndex = 8;
            this.Lbl_ProfilePicName.Text = "PN";
            this.Lbl_ProfilePicName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PictureBox_ProfilePic
            // 
            this.PictureBox_ProfilePic.Image = global::App.Properties.Resources.profile__icon__clr119_86_0;
            this.PictureBox_ProfilePic.Location = new System.Drawing.Point(0, 0);
            this.PictureBox_ProfilePic.Margin = new System.Windows.Forms.Padding(0);
            this.PictureBox_ProfilePic.Name = "PictureBox_ProfilePic";
            this.PictureBox_ProfilePic.Size = new System.Drawing.Size(48, 48);
            this.PictureBox_ProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_ProfilePic.TabIndex = 7;
            this.PictureBox_ProfilePic.TabStop = false;
            // 
            // YourMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(536, 69);
            this.Controls.Add(this.Panel_Profile);
            this.Controls.Add(this.TxtBox_MessageHolder);
            this.Controls.Add(this.Lbl_ProfileNameHolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(536, 69);
            this.Name = "YourMessage";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.Text = "MessageTemplate";
            this.Load += new System.EventHandler(this.YourMessage_Load);
            this.Panel_Profile.ResumeLayout(false);
            this.Panel_Profile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_ProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lbl_ProfileNameHolder;
        private System.Windows.Forms.RichTextBox TxtBox_MessageHolder;
        private System.Windows.Forms.Panel Panel_Profile;
        private System.Windows.Forms.Label Lbl_ProfilePicName;
        private System.Windows.Forms.PictureBox PictureBox_ProfilePic;
    }
}