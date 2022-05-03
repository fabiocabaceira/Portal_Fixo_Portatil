namespace FichaPratica5_Base
{
	partial class Form1
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
            this.buttonGenerateKeys = new System.Windows.Forms.Button();
            this.buttonSavePublic = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPublicKey = new System.Windows.Forms.TextBox();
            this.tbBothKeys = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSaveBothKeys = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSymmetricKey = new System.Windows.Forms.TextBox();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.tbSymmetricEncrypted = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBitsSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.tbSymmetricDecrypted = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGenerateKeys
            // 
            this.buttonGenerateKeys.Location = new System.Drawing.Point(23, 13);
            this.buttonGenerateKeys.Name = "buttonGenerateKeys";
            this.buttonGenerateKeys.Size = new System.Drawing.Size(189, 36);
            this.buttonGenerateKeys.TabIndex = 0;
            this.buttonGenerateKeys.Text = "GERAR CHAVES (privada/pública)";
            this.buttonGenerateKeys.UseVisualStyleBackColor = true;
            this.buttonGenerateKeys.Click += new System.EventHandler(this.buttonGenerateKeys_Click);
            // 
            // buttonSavePublic
            // 
            this.buttonSavePublic.Location = new System.Drawing.Point(291, 83);
            this.buttonSavePublic.Name = "buttonSavePublic";
            this.buttonSavePublic.Size = new System.Drawing.Size(209, 53);
            this.buttonSavePublic.TabIndex = 1;
            this.buttonSavePublic.Text = "SALVAR CHAVE-PÚBLICA (.txt)";
            this.buttonSavePublic.UseVisualStyleBackColor = true;
            this.buttonSavePublic.Click += new System.EventHandler(this.buttonSavePublic_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chave-Pública";
            // 
            // tbPublicKey
            // 
            this.tbPublicKey.Location = new System.Drawing.Point(26, 83);
            this.tbPublicKey.Multiline = true;
            this.tbPublicKey.Name = "tbPublicKey";
            this.tbPublicKey.ReadOnly = true;
            this.tbPublicKey.Size = new System.Drawing.Size(259, 53);
            this.tbPublicKey.TabIndex = 3;
            // 
            // tbBothKeys
            // 
            this.tbBothKeys.Location = new System.Drawing.Point(26, 171);
            this.tbBothKeys.Multiline = true;
            this.tbBothKeys.Name = "tbBothKeys";
            this.tbBothKeys.ReadOnly = true;
            this.tbBothKeys.Size = new System.Drawing.Size(259, 53);
            this.tbBothKeys.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chave-Privada/Pública";
            // 
            // buttonSaveBothKeys
            // 
            this.buttonSaveBothKeys.Location = new System.Drawing.Point(291, 171);
            this.buttonSaveBothKeys.Name = "buttonSaveBothKeys";
            this.buttonSaveBothKeys.Size = new System.Drawing.Size(209, 53);
            this.buttonSaveBothKeys.TabIndex = 4;
            this.buttonSaveBothKeys.Text = "SALVAR CHAVE-PRIVADA/PÚBLICA (.txt)";
            this.buttonSaveBothKeys.UseVisualStyleBackColor = true;
            this.buttonSaveBothKeys.Click += new System.EventHandler(this.buttonSaveBothKeys_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chave Simétrica para Cifrar";
            // 
            // tbSymmetricKey
            // 
            this.tbSymmetricKey.Location = new System.Drawing.Point(171, 281);
            this.tbSymmetricKey.Name = "tbSymmetricKey";
            this.tbSymmetricKey.Size = new System.Drawing.Size(210, 20);
            this.tbSymmetricKey.TabIndex = 8;
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(388, 280);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(112, 23);
            this.buttonEncrypt.TabIndex = 9;
            this.buttonEncrypt.Text = "CIFRAR";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // tbSymmetricEncrypted
            // 
            this.tbSymmetricEncrypted.Location = new System.Drawing.Point(191, 316);
            this.tbSymmetricEncrypted.Multiline = true;
            this.tbSymmetricEncrypted.Name = "tbSymmetricEncrypted";
            this.tbSymmetricEncrypted.ReadOnly = true;
            this.tbSymmetricEncrypted.Size = new System.Drawing.Size(309, 69);
            this.tbSymmetricEncrypted.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Chave-Secreta Simétrica cifrada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Número de BITS";
            // 
            // tbBitsSize
            // 
            this.tbBitsSize.Location = new System.Drawing.Point(31, 365);
            this.tbBitsSize.Name = "tbBitsSize";
            this.tbBitsSize.ReadOnly = true;
            this.tbBitsSize.Size = new System.Drawing.Size(100, 20);
            this.tbBitsSize.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Chave-Secreta Simétrica Decifrada";
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(411, 419);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(88, 23);
            this.buttonDecrypt.TabIndex = 16;
            this.buttonDecrypt.Text = "DECIFRAR";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // tbSymmetricDecrypted
            // 
            this.tbSymmetricDecrypted.Location = new System.Drawing.Point(202, 420);
            this.tbSymmetricDecrypted.Multiline = true;
            this.tbSymmetricDecrypted.Name = "tbSymmetricDecrypted";
            this.tbSymmetricDecrypted.ReadOnly = true;
            this.tbSymmetricDecrypted.Size = new System.Drawing.Size(204, 23);
            this.tbSymmetricDecrypted.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 495);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.tbSymmetricDecrypted);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbBitsSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSymmetricEncrypted);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.tbSymmetricKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBothKeys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSaveBothKeys);
            this.Controls.Add(this.tbPublicKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSavePublic);
            this.Controls.Add(this.buttonGenerateKeys);
            this.Name = "Form1";
            this.Text = "FichaPrática05";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonGenerateKeys;
		private System.Windows.Forms.Button buttonSavePublic;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbPublicKey;
		private System.Windows.Forms.TextBox tbBothKeys;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonSaveBothKeys;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbSymmetricKey;
		private System.Windows.Forms.Button buttonEncrypt;
		private System.Windows.Forms.TextBox tbSymmetricEncrypted;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbBitsSize;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonDecrypt;
		private System.Windows.Forms.TextBox tbSymmetricDecrypted;
	}
}

