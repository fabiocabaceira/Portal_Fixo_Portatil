namespace App
{
    partial class NavigationLogin
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
            this.FlowLayoutPanel_NavigationLogin = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Btn_Register = new System.Windows.Forms.Button();
            this.FlowLayoutPanel_NavigationLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowLayoutPanel_NavigationLogin
            // 
            this.FlowLayoutPanel_NavigationLogin.AutoSize = true;
            this.FlowLayoutPanel_NavigationLogin.Controls.Add(this.Btn_Login);
            this.FlowLayoutPanel_NavigationLogin.Controls.Add(this.Btn_Register);
            this.FlowLayoutPanel_NavigationLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.FlowLayoutPanel_NavigationLogin.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutPanel_NavigationLogin.Margin = new System.Windows.Forms.Padding(0);
            this.FlowLayoutPanel_NavigationLogin.Name = "FlowLayoutPanel_NavigationLogin";
            this.FlowLayoutPanel_NavigationLogin.Padding = new System.Windows.Forms.Padding(0, 201, 0, 0);
            this.FlowLayoutPanel_NavigationLogin.Size = new System.Drawing.Size(208, 824);
            this.FlowLayoutPanel_NavigationLogin.TabIndex = 0;
            // 
            // Btn_Login
            // 
            this.Btn_Login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Login.FlatAppearance.BorderSize = 0;
            this.Btn_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.Btn_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.Btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Btn_Login.Image = global::App.Properties.Resources.Login_normal;
            this.Btn_Login.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Login.Location = new System.Drawing.Point(0, 201);
            this.Btn_Login.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.Btn_Login.Size = new System.Drawing.Size(208, 55);
            this.Btn_Login.TabIndex = 1;
            this.Btn_Login.TabStop = false;
            this.Btn_Login.Text = "               Login";
            this.Btn_Login.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Login.UseVisualStyleBackColor = true;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // Btn_Register
            // 
            this.Btn_Register.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Register.FlatAppearance.BorderSize = 0;
            this.Btn_Register.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.Btn_Register.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.Btn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Btn_Register.Image = global::App.Properties.Resources.Register_normal;
            this.Btn_Register.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Register.Location = new System.Drawing.Point(0, 308);
            this.Btn_Register.Margin = new System.Windows.Forms.Padding(0, 52, 0, 0);
            this.Btn_Register.Name = "Btn_Register";
            this.Btn_Register.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.Btn_Register.Size = new System.Drawing.Size(208, 55);
            this.Btn_Register.TabIndex = 1;
            this.Btn_Register.TabStop = false;
            this.Btn_Register.Text = "               Register";
            this.Btn_Register.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Register.UseVisualStyleBackColor = true;
            this.Btn_Register.Click += new System.EventHandler(this.Btn_Register_Click);
            // 
            // NavigationLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(208, 824);
            this.Controls.Add(this.FlowLayoutPanel_NavigationLogin);
            this.Font = new System.Drawing.Font("Rage Italic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NavigationLogin";
            this.Text = "NavigationLogin";
            this.Load += new System.EventHandler(this.NavigationLogin_Load);
            this.FlowLayoutPanel_NavigationLogin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel_NavigationLogin;
        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.Button Btn_Register;
    }
}