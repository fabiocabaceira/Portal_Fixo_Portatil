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
using Server;

namespace App
{
    public partial class App : Form
    {

        public Client Cliente { get; private set; }
        public LoaderController AppHeaderController { get; private set; }
        public LoaderController AppNavigationController { get; private set; }
        public LoaderController AppFormController { get; private set; }

        private bool _forcedClosed;
        public App()
        {
            InitializeComponent();

            _forcedClosed = false;

        }

        private async void App_Load(object sender, EventArgs e)
        {
            #region Custom UI

            AppHeaderController = new LoaderController(Panel_AppHeaderLoader, new AppHeader(this));
            AppNavigationController = new LoaderController(Panel_AppNavigationLoader, new NavigationLogin(this));
            AppFormController = new LoaderController(Panel_AppFormLoader, new LoginForm(this));

            #endregion

            Cliente = new Client(Server.Server.serverController.MyEP, this);

            #region Custom UI
            //ResizeAppByCurrentScreen();
            #endregion
        }

        #region Custom UI
        /*
        private void ResizeAppByCurrentScreen(double percentageOfWidth = 55,double percentageOfHeight = 60)
        {

            percentageOfWidth =  100;
            percentageOfHeight =  100;

            Rectangle screen = Screen.FromControl(this).Bounds;

            double preferableSizeWidth = screen.Width * percentageOfWidth;
            double preferableSizeHeight = screen.Height * percentageOfHeight;


            this.Width = (int)preferableSizeWidth;
            this.Height = (int)preferableSizeHeight;

            this.CenterToScreen();
        }
        */
        #endregion

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Se o forcedClosed está falso então cancela o fecho da app
            if(!_forcedClosed) e.Cancel = true;
        }

        /// <summary>
        /// Fecha a aplicação seguramente, assincronamente.
        /// </summary>
        public async void CloseSafely()
        {
            try
            {
                // Verifica se a app já está a trabalhar em algo
                if (!Cliente.IsWorking)
                {
                    // A app passa a trabalhar em algo
                    Cliente.IsWorking = true;

                    // Verifica se o cliente está disponivel
                    if (Cliente.IsAvailable())
                    {
                        // Espera que o cliente disconecte-se do servidor
                        await Task.Run(() => Cliente.Disconnect());


                    }


                    // Muda o forcedClosed para true para o evento do  FormClosing conseguir passar o if e fechar a app
                    _forcedClosed = true;

                    Application.Exit();

                } else
                {
                    // Amostra a notificação forçosamente assíncronamente
                    Task.Run(() => Client.ShowNotification(this, "Espere que a operação acabe!", true));
                }

            } catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

            
        }
    }
}
