namespace App
{
    partial class LoginForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MaskedTxtBox_Name = new System.Windows.Forms.MaskedTextBox();
            this.Lbl_Login = new System.Windows.Forms.Label();
            this.MaskedTxtBox_Password = new System.Windows.Forms.MaskedTextBox();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Lbl_Name = new System.Windows.Forms.Label();
            this.Lbl_Password = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.MaskedTxtBox_Name, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_Login, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MaskedTxtBox_Password, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Login, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_Name, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_Password, 0, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(200, 201);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 30, 20, 30);
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(342, 341);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // MaskedTxtBox_Name
            // 
            this.MaskedTxtBox_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.MaskedTxtBox_Name.BeepOnError = true;
            this.MaskedTxtBox_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaskedTxtBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskedTxtBox_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.MaskedTxtBox_Name.Location = new System.Drawing.Point(23, 132);
            this.MaskedTxtBox_Name.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.MaskedTxtBox_Name.Mask = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            this.MaskedTxtBox_Name.Name = "MaskedTxtBox_Name";
            this.MaskedTxtBox_Name.PromptChar = ' ';
            this.MaskedTxtBox_Name.Size = new System.Drawing.Size(299, 26);
            this.MaskedTxtBox_Name.TabIndex = 4;
            // 
            // Lbl_Login
            // 
            this.Lbl_Login.AutoSize = true;
            this.Lbl_Login.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Login.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Lbl_Login.Location = new System.Drawing.Point(20, 30);
            this.Lbl_Login.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_Login.Name = "Lbl_Login";
            this.Lbl_Login.Size = new System.Drawing.Size(302, 36);
            this.Lbl_Login.TabIndex = 0;
            this.Lbl_Login.Text = "Login";
            this.Lbl_Login.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaskedTxtBox_Password
            // 
            this.MaskedTxtBox_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.MaskedTxtBox_Password.BeepOnError = true;
            this.MaskedTxtBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaskedTxtBox_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskedTxtBox_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.MaskedTxtBox_Password.Location = new System.Drawing.Point(23, 224);
            this.MaskedTxtBox_Password.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.MaskedTxtBox_Password.Mask = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            this.MaskedTxtBox_Password.Name = "MaskedTxtBox_Password";
            this.MaskedTxtBox_Password.PasswordChar = '*';
            this.MaskedTxtBox_Password.PromptChar = ' ';
            this.MaskedTxtBox_Password.Size = new System.Drawing.Size(299, 26);
            this.MaskedTxtBox_Password.TabIndex = 2;
            // 
            // Btn_Login
            // 
            this.Btn_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(60)))), ((int)(((byte)(237)))));
            this.Btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Login.FlatAppearance.BorderSize = 0;
            this.Btn_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(24)))), ((int)(((byte)(216)))));
            this.Btn_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(24)))), ((int)(((byte)(216)))));
            this.Btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Btn_Login.Location = new System.Drawing.Point(23, 280);
            this.Btn_Login.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(91, 31);
            this.Btn_Login.TabIndex = 1;
            this.Btn_Login.TabStop = false;
            this.Btn_Login.Text = "Enviar";
            this.Btn_Login.UseVisualStyleBackColor = false;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            this.Btn_Login.MouseEnter += new System.EventHandler(this.Btn_Login_MouseEnter);
            this.Btn_Login.MouseLeave += new System.EventHandler(this.Btn_Login_MouseLeave);
            // 
            // Lbl_Name
            // 
            this.Lbl_Name.AutoSize = true;
            this.Lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Lbl_Name.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.Lbl_Name.Location = new System.Drawing.Point(20, 96);
            this.Lbl_Name.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_Name.Name = "Lbl_Name";
            this.Lbl_Name.Size = new System.Drawing.Size(302, 26);
            this.Lbl_Name.TabIndex = 0;
            this.Lbl_Name.Text = "Nome:";
            this.Lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lbl_Password
            // 
            this.Lbl_Password.AutoSize = true;
            this.Lbl_Password.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Password.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Lbl_Password.Location = new System.Drawing.Point(20, 188);
            this.Lbl_Password.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_Password.Name = "Lbl_Password";
            this.Lbl_Password.Size = new System.Drawing.Size(302, 26);
            this.Lbl_Password.TabIndex = 3;
            this.Lbl_Password.Text = "Password:";
            this.Lbl_Password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(742, 824);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MaskedTextBox MaskedTxtBox_Name;
        private System.Windows.Forms.Label Lbl_Login;
        private System.Windows.Forms.MaskedTextBox MaskedTxtBox_Password;
        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.Label Lbl_Name;
        private System.Windows.Forms.Label Lbl_Password;
    }
}