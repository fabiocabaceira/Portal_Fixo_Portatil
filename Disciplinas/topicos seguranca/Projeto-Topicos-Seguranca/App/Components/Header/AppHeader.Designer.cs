namespace App
{
    partial class AppHeader
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
            this.FlowLayoutPanel_AppHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_CloseApp = new System.Windows.Forms.Button();
            this.Btn_Maximize = new System.Windows.Forms.Button();
            this.Btn_Minimize = new System.Windows.Forms.Button();
            this.FlowLayoutPanel_AppHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowLayoutPanel_AppHeader
            // 
            this.FlowLayoutPanel_AppHeader.AutoSize = true;
            this.FlowLayoutPanel_AppHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.FlowLayoutPanel_AppHeader.Controls.Add(this.Btn_CloseApp);
            this.FlowLayoutPanel_AppHeader.Controls.Add(this.Btn_Maximize);
            this.FlowLayoutPanel_AppHeader.Controls.Add(this.Btn_Minimize);
            this.FlowLayoutPanel_AppHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanel_AppHeader.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel_AppHeader.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutPanel_AppHeader.Margin = new System.Windows.Forms.Padding(0);
            this.FlowLayoutPanel_AppHeader.Name = "FlowLayoutPanel_AppHeader";
            this.FlowLayoutPanel_AppHeader.Size = new System.Drawing.Size(950, 31);
            this.FlowLayoutPanel_AppHeader.TabIndex = 2;
            this.FlowLayoutPanel_AppHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlowLayoutPanel_AppHeader_MouseDown);
            this.FlowLayoutPanel_AppHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FlowLayoutPanel_AppHeader_MouseMove);
            // 
            // Btn_CloseApp
            // 
            this.Btn_CloseApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn_CloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_CloseApp.FlatAppearance.BorderSize = 0;
            this.Btn_CloseApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.Btn_CloseApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.Btn_CloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_CloseApp.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_CloseApp.Image = global::App.Properties.Resources.close;
            this.Btn_CloseApp.Location = new System.Drawing.Point(924, 0);
            this.Btn_CloseApp.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_CloseApp.Name = "Btn_CloseApp";
            this.Btn_CloseApp.Size = new System.Drawing.Size(26, 31);
            this.Btn_CloseApp.TabIndex = 1;
            this.Btn_CloseApp.TabStop = false;
            this.Btn_CloseApp.UseVisualStyleBackColor = false;
            this.Btn_CloseApp.Click += new System.EventHandler(this.Btn_CloseApp_Click);
            // 
            // Btn_Maximize
            // 
            this.Btn_Maximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn_Maximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Maximize.FlatAppearance.BorderSize = 0;
            this.Btn_Maximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(60)))), ((int)(((byte)(237)))));
            this.Btn_Maximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.Btn_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Maximize.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_Maximize.Image = global::App.Properties.Resources.maximize;
            this.Btn_Maximize.Location = new System.Drawing.Point(898, 0);
            this.Btn_Maximize.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Maximize.Name = "Btn_Maximize";
            this.Btn_Maximize.Size = new System.Drawing.Size(26, 31);
            this.Btn_Maximize.TabIndex = 1;
            this.Btn_Maximize.TabStop = false;
            this.Btn_Maximize.UseVisualStyleBackColor = false;
            this.Btn_Maximize.Click += new System.EventHandler(this.Btn_Maximize_Click);
            // 
            // Btn_Minimize
            // 
            this.Btn_Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn_Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Minimize.FlatAppearance.BorderSize = 0;
            this.Btn_Minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(60)))), ((int)(((byte)(237)))));
            this.Btn_Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.Btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Minimize.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_Minimize.Image = global::App.Properties.Resources.minimize;
            this.Btn_Minimize.Location = new System.Drawing.Point(872, 0);
            this.Btn_Minimize.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Minimize.Name = "Btn_Minimize";
            this.Btn_Minimize.Size = new System.Drawing.Size(26, 31);
            this.Btn_Minimize.TabIndex = 1;
            this.Btn_Minimize.TabStop = false;
            this.Btn_Minimize.UseVisualStyleBackColor = false;
            this.Btn_Minimize.Click += new System.EventHandler(this.Btn_Minimize_Click);
            // 
            // AppHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(950, 31);
            this.Controls.Add(this.FlowLayoutPanel_AppHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppHeader";
            this.Text = "AppHeader";
            this.Load += new System.EventHandler(this.AppHeader_Load);
            this.FlowLayoutPanel_AppHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel_AppHeader;
        private System.Windows.Forms.Button Btn_CloseApp;
        private System.Windows.Forms.Button Btn_Maximize;
        private System.Windows.Forms.Button Btn_Minimize;
    }
}