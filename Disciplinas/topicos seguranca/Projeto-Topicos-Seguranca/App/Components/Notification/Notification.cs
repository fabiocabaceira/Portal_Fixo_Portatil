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
    public partial class Notification : Form
    {
        #region Custom UI
        private CustomFont _customFont;
        private string _text;

        #endregion

        internal const int DEFAULT_DELAY = 10 * 1000;

        #region Custom UI
        public Notification(string text)
        {
            InitializeComponent();

            _customFont = new CustomFont();
            _text = text;
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            string[] fontWeightForControl = { "Bold" };
            _customFont.SetCustomFont(fontWeightForControl, Lbl_NotificationText);

            Lbl_NotificationText.Text = _text;
        }

        #endregion

        /// <summary>
        /// Amostra, assincronamente, a notificação desejada
        /// </summary>
        /// <param name="app">A app</param>
        /// <param name="notification">A notificação para amostrar</param>
        /// <param name="delayToClose">O delay que quer até fechar, default: 10 * 1000 (10 segundos)</param>
        /// <returns></returns>
        public static async Task ShowNotification(App app,Notification notification,int delayToClose = DEFAULT_DELAY)
        {
            // O ' _ ' serve para não amostrar "erros" para melhor entendimento retire ' _ = '
            // Espera, assincronamente, até o delay acabar para fechar a notificação
            _ = Task.Run(async () => {

                await Task.Delay(delayToClose);

                // Verifica se a notificação já foi descartada
                if(!notification.IsDisposed)
                    // Invoke porque estão em threads diferentes
                    notification.Invoke((MethodInvoker)(() => notification.Close()));

            });

            // Verifica se o cliente tem a propriedade de notificação aberta, senão fecha a notificação, este caso é para quando o notificação é aberta forcadamente
            _ = Task.Run(async () =>
            {
       
                while (app.Cliente.NotificationOpen)
                {
                    await Task.Delay(200);
                }

                // Verifica se a notificação já foi descartada
                if (!notification.IsDisposed)
                    // Invoke porque estão em threads diferentes
                    notification.Invoke((MethodInvoker)(() => notification.Close()));
            });
   
        }
    }
}
