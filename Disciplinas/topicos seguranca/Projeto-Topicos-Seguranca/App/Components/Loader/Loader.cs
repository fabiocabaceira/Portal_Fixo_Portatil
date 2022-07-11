using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Loader : Form
    {
        #region Custom UI

        private CustomFont _customFont;
        private Client _client;
        public Loader(Client client)
        {
            InitializeComponent();

            _client = client;
            _customFont = new CustomFont();
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            string[] fontWeightsForControls = { "Regular" };
            _customFont.SetCustomFont(fontWeightsForControls, Lbl_Loader);

            // Dá invoke porque este inicia numa thread diferente
            Lbl_Loader.Invoke((MethodInvoker)(() =>
            {
                Lbl_Loader.Text = _client.LoadingState;
            }));
        }

        #endregion

        /// <summary>
        /// Espera assincronamente que a variável _closeLoader do cliente passe para true para poder fechar o loader
        /// </summary>
        /// <returns></returns>
        public async Task CloseAfterDone()
        {

            // Espera que a funcão assincrona acabe
            await Task.Run(async () =>
            { 
                // https://stackoverflow.com/questions/7181756/invoke-or-begininvoke-cannot-be-called-on-a-control-until-the-window-handle-has
                bool hasFinished = false;

                while (!hasFinished)
                {
                    await Task.Delay(250);

                    // Verifica se existe a handle por que senão iria dar uma exceção ou se o CloseLoader está false
                    if (Lbl_Loader.IsHandleCreated && !_client.CloseLoader)
                    {
                        // Invoke porque estão em threads diferentes
                        Lbl_Loader.Invoke((MethodInvoker)(() =>
                        {
                            // Muda o texto do loader com o loading state do cliente
                            Lbl_Loader.Text = _client.LoadingState;
                        }));
                    }
                    else
                    {
                        hasFinished = true;
                    }

                }

                
                await Task.Delay(1000);
                 
            });


            Close();
        }
    }
}
