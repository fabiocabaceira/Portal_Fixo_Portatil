namespace App
{
    partial class App
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.Panel_AppNavigationLoader = new System.Windows.Forms.Panel();
            this.Panel_AppFormLoader = new System.Windows.Forms.Panel();
            this.Panel_AppHeaderLoader = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Panel_AppNavigationLoader
            // 
            this.Panel_AppNavigationLoader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel_AppNavigationLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Panel_AppNavigationLoader.Location = new System.Drawing.Point(0, 31);
            this.Panel_AppNavigationLoader.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_AppNavigationLoader.Name = "Panel_AppNavigationLoader";
            this.Panel_AppNavigationLoader.Size = new System.Drawing.Size(208, 824);
            this.Panel_AppNavigationLoader.TabIndex = 1;
            // 
            // Panel_AppFormLoader
            // 
            this.Panel_AppFormLoader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_AppFormLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.Panel_AppFormLoader.Location = new System.Drawing.Point(208, 31);
            this.Panel_AppFormLoader.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_AppFormLoader.Name = "Panel_AppFormLoader";
            this.Panel_AppFormLoader.Size = new System.Drawing.Size(742, 824);
            this.Panel_AppFormLoader.TabIndex = 2;
            // 
            // Panel_AppHeaderLoader
            // 
            this.Panel_AppHeaderLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Panel_AppHeaderLoader.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_AppHeaderLoader.Location = new System.Drawing.Point(0, 0);
            this.Panel_AppHeaderLoader.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_AppHeaderLoader.Name = "Panel_AppHeaderLoader";
            this.Panel_AppHeaderLoader.Size = new System.Drawing.Size(950, 31);
            this.Panel_AppHeaderLoader.TabIndex = 0;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(950, 855);
            this.Controls.Add(this.Panel_AppHeaderLoader);
            this.Controls.Add(this.Panel_AppNavigationLoader);
            this.Controls.Add(this.Panel_AppFormLoader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(950, 855);
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "App";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.App_FormClosing);
            this.Load += new System.EventHandler(this.App_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Panel_AppNavigationLoader;
        private System.Windows.Forms.Panel Panel_AppFormLoader;
        private System.Windows.Forms.Panel Panel_AppHeaderLoader;
    }
}

