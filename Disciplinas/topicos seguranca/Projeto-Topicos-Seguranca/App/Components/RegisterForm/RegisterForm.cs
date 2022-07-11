using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EI.SI;

namespace App
{
    public partial class RegisterForm : Form
    {
        private App _app;

        #region Custom UI
        private MessageHelper _messageHelper;
        private CustomFont _customFont;
        #endregion

        public RegisterForm(App app)
        {
            InitializeComponent();

            _app = app;

            #region CustomUI
            _messageHelper = new MessageHelper();
            _customFont = new CustomFont();
            #endregion
        }

        #region Custom UI
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            Btn_Register.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            string[] fontWeightsForControls = { "Bold", "Regular", "Regular" ,"Regular", "Regular", "Regular" };
            _customFont.SetCustomFont(fontWeightsForControls, Lbl_Register, Lbl_Name, Lbl_Password, MaskedTxtBox_Name, MaskedTxtBox_Password, Btn_Register);
        }

        private void Btn_Register_MouseEnter(object sender, EventArgs e)
        {
            Btn_Register.ForeColor = Color.FromArgb(244, 244, 244);
        }

        private void Btn_Register_MouseLeave(object sender, EventArgs e)
        {
            Btn_Register.ForeColor = Color.FromArgb(210, 210, 210);
        }

        #endregion

        /// <summary>
        /// Conecta-se ao servidor e envia uma mensagem de register, assincronamente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_Register_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(MaskedTxtBox_Name.Text) || String.IsNullOrEmpty(MaskedTxtBox_Password.Text)) return;
            
            string username = MaskedTxtBox_Name.Text;
            string password = MaskedTxtBox_Password.Text;

            // Vai buscar uma cor de profile random
            string profileIcon = _messageHelper.GetRandomIconColor();

            // Retirar os espaços do lado esquerdo e direito do username e password
            username = username.Trim(' ');
            password = password.Trim(' ');

            // Dá reset do texto nas TextBoxes do nome e password
            MaskedTxtBox_Name.Text = string.Empty;
            MaskedTxtBox_Password.Text = string.Empty;


            // Verifica se a app já está a trabalhar em algo
            if (!_app.Cliente.IsWorking)
            {
                // A app passa a trabalhar em algo
                _app.Cliente.IsWorking = true;

                // Espera, assincronamente, que o cliente conecte-se ao servidor
                await Task.Run(() => _app.Cliente.Connect(true));

                // Espera, assincronamente, que o cliente envia a mensagem de register para o servidor
                await Task.Run(() => _app.Cliente.SendMessageToServer($"REGISTER;{username};{password};{profileIcon}", ProtocolSICmdType.SYM_CIPHER_DATA, false));

            }
            else
            {
                // Verifica se já existe alguma notificação aberta
                if (_app.Cliente.NotificationOpen) return;

                // A app passa a ter uma notificação aberta
                _app.Cliente.NotificationOpen = true;

                // Amostra a notificação assíncronamente
                Task.Run(() => Client.ShowNotification(_app,"Espere que a operação acabe!"));
            }
        }
    }
}
