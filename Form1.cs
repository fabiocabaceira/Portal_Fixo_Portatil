using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FichaPratica5_Base
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		// DEFINIR PROPRIEDADES
		private RSACryptoServiceProvider rsa;



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonGenerateKeys_Click(object sender, EventArgs e)
        {
			rsa = new RSACryptoServiceProvider();

			//CRIAR E DEVOLVER UMA STRING QUE CONTEM A CHAVE-PUBLICA
			string publickey = rsa.ToXmlString(false);

			//CRIAR E DEVOLVER UMA STRING QUE CONTEM CHAVE-PRIVADA 
			string bothkeys = rsa.ToXmlString(true);
			
			//GUARDAR A INFORMACAO
			tbPublicKey.Text = publickey;
			tbBothKeys.Text = bothkeys;
        }

        private void buttonSavePublic_Click(object sender, EventArgs e)
        {
			File.WriteAllText("publickey.txt", tbPublicKey.Text);


        }

        private void buttonSaveBothKeys_Click(object sender, EventArgs e)
        {
			File.WriteAllText("privatekey.txt", tbBothKeys.Text);

        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
			//OBTER CHAVE SUMETRICA PARA CIFRAR 
			string keyS = tbSymmetricKey.Text;
			byte [] DADOS = Encoding.UTF8.GetBytes(keyS);

			//CIFRAR DADOS UTILIZANDO RSA
			byte[] dadosEnc = rsa.Encrypt(DADOS, true);
			tbSymmetricEncrypted.Text = Convert.ToBase64String(dadosEnc);
			tbBitsSize.Text = (dadosEnc.Length* 8).ToString();
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
			//OBTER A CHAVE SIMETRICA DECIFRADA
			string keySEnc = tbSymmetricEncrypted.Text;
			byte [] dados = Convert.FromBase64String(keySEnc);

			//DECIFRAR DADOS ATRAVES DO RSA
			
			byte[] dadosDec = rsa.Decrypt(dados, true);
			tbSymmetricDecrypted.Text = Encoding.UTF8.GetString(dadosDec);

        }
    }
}
