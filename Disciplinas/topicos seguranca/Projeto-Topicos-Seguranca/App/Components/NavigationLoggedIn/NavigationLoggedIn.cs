using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class NavigationLoggedIn : Form
    {
        private App _app;

        #region Custom UI
        private CustomFont _customFont;

        private string _name;
        private string _iconColor;
        #endregion Custom UI
        public NavigationLoggedIn(string name, App app, string iconColor)
        {
            #region Custom UI
            InitializeComponent();

            _customFont = new CustomFont();

            Btn_Logout.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            _name = name;
            _iconColor = iconColor;

            #endregion

            _app = app;
            
        }

        #region Custom UI
        private void NavigationLoggedIn_Load(object sender, EventArgs e)
        {
            // Dar load das fontes
            string[] fontWeightsForControls = { "Regular", "Regular" };
            _customFont.SetCustomFont(fontWeightsForControls, Lbl_ProfileName, Btn_Logout);

            Lbl_ProfileName.Text = _name;

            MessageHelper.LoadProfileIconAndName(Panel_Profile, PictureBox_ProfilePic, Lbl_ProfilePicName, _iconColor, _name);

        }
        #endregion

        /// <summary>
        /// Desconecta o cliente, assincronamente, do servidor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_Logout_Click(object sender, EventArgs e)
        {
            // Verifica se a app já está a trabalhar em algo
            if (!_app.Cliente.IsWorking)
            {
                // A app passa a trabalhar em algo
                _app.Cliente.IsWorking = true;

                // Espera, assincronamente, que o cliente desconecte-se do servidor
                await Task.Run(() => _app.Cliente.Disconnect());

                // Muda a navegação da app para a navbar da página de login
                _app.AppNavigationController.SetComponentOnLoader(new NavigationLogin(_app));

                // Muda a página para a página login
                _app.AppFormController.SetComponentOnLoader(new LoginForm(_app));

            } else
            {
                // Verifica se já existe alguma notificação aberta
                if (_app.Cliente.NotificationOpen) return;

                // A app passa a ter uma notificação aberta
                _app.Cliente.NotificationOpen = true;

                // Amostra a notificação assíncronamente
                Task.Run(() => Client.ShowNotification(_app, "Espere que a operação acabe!"));
            }

        }

        
    }
}
