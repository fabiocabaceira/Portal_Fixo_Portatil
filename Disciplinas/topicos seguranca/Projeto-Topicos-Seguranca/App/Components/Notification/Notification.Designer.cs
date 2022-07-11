namespace App
{
    partial class Notification
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
            this.Lbl_NotificationText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbl_NotificationText
            // 
            this.Lbl_NotificationText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_NotificationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lbl_NotificationText.Location = new System.Drawing.Point(0, 0);
            this.Lbl_NotificationText.Name = "Lbl_NotificationText";
            this.Lbl_NotificationText.Size = new System.Drawing.Size(298, 63);
            this.Lbl_NotificationText.TabIndex = 0;
            this.Lbl_NotificationText.Text = "Utilizador Inválido !";
            this.Lbl_NotificationText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(298, 63);
            this.Controls.Add(this.Lbl_NotificationText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Notification";
            this.Text = "Notification";
            this.Load += new System.EventHandler(this.Notification_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_NotificationText;
    }
}