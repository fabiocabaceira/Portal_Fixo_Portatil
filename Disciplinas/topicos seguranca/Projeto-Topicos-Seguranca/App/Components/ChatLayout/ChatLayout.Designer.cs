namespace App
{
    partial class ChatLayout
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
            this.Lbl_ChatName = new System.Windows.Forms.Label();
            this.Panel_ChatMessagesContainer = new System.Windows.Forms.Panel();
            this.TableLayoutPanel_MessagesHolder = new System.Windows.Forms.TableLayoutPanel();
            this.TxtBox_Message = new System.Windows.Forms.RichTextBox();
            this.Btn_SendMessage = new System.Windows.Forms.Button();
            this.TableLayoutPanel_ChatContainer = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_SendMessagesContainer = new System.Windows.Forms.Panel();
            this.Panel_ChatMessagesContainer.SuspendLayout();
            this.TableLayoutPanel_ChatContainer.SuspendLayout();
            this.Panel_SendMessagesContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_ChatName
            // 
            this.Lbl_ChatName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_ChatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ChatName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Lbl_ChatName.Location = new System.Drawing.Point(30, 40);
            this.Lbl_ChatName.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_ChatName.Name = "Lbl_ChatName";
            this.Lbl_ChatName.Size = new System.Drawing.Size(596, 42);
            this.Lbl_ChatName.TabIndex = 1;
            this.Lbl_ChatName.Text = "Chat: Nome do Server";
            // 
            // Panel_ChatMessagesContainer
            // 
            this.Panel_ChatMessagesContainer.AutoScroll = true;
            this.Panel_ChatMessagesContainer.AutoSize = true;
            this.Panel_ChatMessagesContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_ChatMessagesContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.Panel_ChatMessagesContainer.Controls.Add(this.TableLayoutPanel_MessagesHolder);
            this.Panel_ChatMessagesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_ChatMessagesContainer.Location = new System.Drawing.Point(30, 122);
            this.Panel_ChatMessagesContainer.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_ChatMessagesContainer.Name = "Panel_ChatMessagesContainer";
            this.Panel_ChatMessagesContainer.Size = new System.Drawing.Size(596, 427);
            this.Panel_ChatMessagesContainer.TabIndex = 1;
            this.Panel_ChatMessagesContainer.Resize += new System.EventHandler(this.Panel_ChatMessagesContainer_Resize);
            // 
            // TableLayoutPanel_MessagesHolder
            // 
            this.TableLayoutPanel_MessagesHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel_MessagesHolder.AutoSize = true;
            this.TableLayoutPanel_MessagesHolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel_MessagesHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.TableLayoutPanel_MessagesHolder.ColumnCount = 1;
            this.TableLayoutPanel_MessagesHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_MessagesHolder.Location = new System.Drawing.Point(30, 0);
            this.TableLayoutPanel_MessagesHolder.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel_MessagesHolder.MaximumSize = new System.Drawing.Size(740, 999999);
            this.TableLayoutPanel_MessagesHolder.Name = "TableLayoutPanel_MessagesHolder";
            this.TableLayoutPanel_MessagesHolder.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.TableLayoutPanel_MessagesHolder.RowCount = 1;
            this.TableLayoutPanel_MessagesHolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel_MessagesHolder.Size = new System.Drawing.Size(536, 40);
            this.TableLayoutPanel_MessagesHolder.TabIndex = 7;
            // 
            // TxtBox_Message
            // 
            this.TxtBox_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBox_Message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TxtBox_Message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBox_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBox_Message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.TxtBox_Message.Location = new System.Drawing.Point(0, 0);
            this.TxtBox_Message.Margin = new System.Windows.Forms.Padding(0);
            this.TxtBox_Message.MaximumSize = new System.Drawing.Size(552, 85);
            this.TxtBox_Message.MinimumSize = new System.Drawing.Size(419, 28);
            this.TxtBox_Message.Name = "TxtBox_Message";
            this.TxtBox_Message.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TxtBox_Message.Size = new System.Drawing.Size(419, 28);
            this.TxtBox_Message.TabIndex = 2;
            this.TxtBox_Message.TabStop = false;
            this.TxtBox_Message.Text = "";
            this.TxtBox_Message.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.TxtBox_Message_ContentsResized);
            // 
            // Btn_SendMessage
            // 
            this.Btn_SendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_SendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(60)))), ((int)(((byte)(237)))));
            this.Btn_SendMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_SendMessage.FlatAppearance.BorderSize = 0;
            this.Btn_SendMessage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(24)))), ((int)(((byte)(216)))));
            this.Btn_SendMessage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(24)))), ((int)(((byte)(216)))));
            this.Btn_SendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_SendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SendMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Btn_SendMessage.Location = new System.Drawing.Point(505, 0);
            this.Btn_SendMessage.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_SendMessage.Name = "Btn_SendMessage";
            this.Btn_SendMessage.Size = new System.Drawing.Size(91, 31);
            this.Btn_SendMessage.TabIndex = 2;
            this.Btn_SendMessage.TabStop = false;
            this.Btn_SendMessage.Text = "Enviar";
            this.Btn_SendMessage.UseVisualStyleBackColor = false;
            this.Btn_SendMessage.Click += new System.EventHandler(this.Btn_SendMessage_Click);
            this.Btn_SendMessage.MouseEnter += new System.EventHandler(this.Btn_SendMessage_MouseEnter);
            this.Btn_SendMessage.MouseLeave += new System.EventHandler(this.Btn_SendMessage_MouseLeave);
            // 
            // TableLayoutPanel_ChatContainer
            // 
            this.TableLayoutPanel_ChatContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel_ChatContainer.AutoSize = true;
            this.TableLayoutPanel_ChatContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel_ChatContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TableLayoutPanel_ChatContainer.ColumnCount = 1;
            this.TableLayoutPanel_ChatContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_ChatContainer.Controls.Add(this.Panel_ChatMessagesContainer, 0, 2);
            this.TableLayoutPanel_ChatContainer.Controls.Add(this.Panel_SendMessagesContainer, 0, 4);
            this.TableLayoutPanel_ChatContainer.Controls.Add(this.Lbl_ChatName, 0, 0);
            this.TableLayoutPanel_ChatContainer.Location = new System.Drawing.Point(43, 82);
            this.TableLayoutPanel_ChatContainer.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel_ChatContainer.MaximumSize = new System.Drawing.Size(860, 729);
            this.TableLayoutPanel_ChatContainer.MinimumSize = new System.Drawing.Size(656, 660);
            this.TableLayoutPanel_ChatContainer.Name = "TableLayoutPanel_ChatContainer";
            this.TableLayoutPanel_ChatContainer.Padding = new System.Windows.Forms.Padding(30, 40, 30, 40);
            this.TableLayoutPanel_ChatContainer.RowCount = 5;
            this.TableLayoutPanel_ChatContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.TableLayoutPanel_ChatContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanel_ChatContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 427F));
            this.TableLayoutPanel_ChatContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayoutPanel_ChatContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_ChatContainer.Size = new System.Drawing.Size(656, 662);
            this.TableLayoutPanel_ChatContainer.TabIndex = 4;
            // 
            // Panel_SendMessagesContainer
            // 
            this.Panel_SendMessagesContainer.AutoSize = true;
            this.Panel_SendMessagesContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_SendMessagesContainer.Controls.Add(this.Btn_SendMessage);
            this.Panel_SendMessagesContainer.Controls.Add(this.TxtBox_Message);
            this.Panel_SendMessagesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_SendMessagesContainer.Location = new System.Drawing.Point(30, 589);
            this.Panel_SendMessagesContainer.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_SendMessagesContainer.Name = "Panel_SendMessagesContainer";
            this.Panel_SendMessagesContainer.Size = new System.Drawing.Size(596, 33);
            this.Panel_SendMessagesContainer.TabIndex = 5;
            // 
            // ChatLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(742, 824);
            this.Controls.Add(this.TableLayoutPanel_ChatContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(742, 824);
            this.Name = "ChatLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChatLayout";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ChatLayout_Load);
            this.SizeChanged += new System.EventHandler(this.ChatLayout_SizeChanged);
            this.Panel_ChatMessagesContainer.ResumeLayout(false);
            this.Panel_ChatMessagesContainer.PerformLayout();
            this.TableLayoutPanel_ChatContainer.ResumeLayout(false);
            this.TableLayoutPanel_ChatContainer.PerformLayout();
            this.Panel_SendMessagesContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lbl_ChatName;
        private System.Windows.Forms.Panel Panel_ChatMessagesContainer;
        private System.Windows.Forms.RichTextBox TxtBox_Message;
        private System.Windows.Forms.Button Btn_SendMessage;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel_ChatContainer;
        private System.Windows.Forms.Panel Panel_SendMessagesContainer;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel_MessagesHolder;
    }
}