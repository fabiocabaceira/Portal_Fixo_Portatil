using EI.SI;
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
    public partial class ChatLayout : Form
    {

        private App _app;

        #region Custom UI

        private string _chatName;

        private CustomFont _customFont;

        private int _oldHeight;

        private LoaderMessages _messagesLoader;

        #endregion Custom UI



        internal LoaderMessages MessagesLoader { get { return _messagesLoader; } }

   
        public ChatLayout(App app)
        {
            InitializeComponent();

            _app = app;

            #region Custom UI

            _chatName = "Chat: TPS_Projeto";

            _customFont = new CustomFont();

            _oldHeight = TxtBox_Message.Height;

            _messagesLoader = new LoaderMessages(TableLayoutPanel_MessagesHolder, 50);

            #endregion Custom UI
        }


        #region Custom UI
        private void ChatLayout_Load(object sender, EventArgs e)
        {
            Btn_SendMessage.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            string[] fontWeightsForControls = { "Bold", "Regular", "Regular" };
            this._customFont.SetCustomFont(fontWeightsForControls, Lbl_ChatName, TxtBox_Message, Btn_SendMessage);

            Lbl_ChatName.Text = this._chatName;
        }
        

        /* Auto size to increase Height
         * https://bytes.com/topic/visual-basic-net/answers/595659-auto-adjust-height-richtextbox-textbox-based-length-string
         */
        private void TxtBox_Message_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
                TxtBox_Message.Height = e.NewRectangle.Height - 21;



            if (this._oldHeight < TxtBox_Message.Height)
            {
                this._oldHeight = TxtBox_Message.Height;
                    
            }
            if (this._oldHeight > TxtBox_Message.Height)
            {
                TableLayoutPanel_ChatContainer.Height -= this._oldHeight - TxtBox_Message.Height;
                this._oldHeight = TxtBox_Message.Height;
            }
        }

        private void ChatLayout_SizeChanged(object sender, EventArgs e)
        {
            CenterXToContainer(TableLayoutPanel_ChatContainer, this);
        }

        private void CenterXToContainer(Control control, Form parent)
        {
            int centerX = (parent.Width / 2) - (control.Width / 2);

            control.Location = new Point(centerX, control.Location.Y);
        }




        private void Btn_SendMessage_MouseEnter(object sender, EventArgs e)
        {
            Btn_SendMessage.ForeColor = Color.FromArgb(244, 244, 244);
        }

        private void Btn_SendMessage_MouseLeave(object sender, EventArgs e)
        {
            Btn_SendMessage.ForeColor = Color.FromArgb(210, 210, 210);
        }

        #endregion Custom UI

        /// <summary>
        /// Envia uma mensagem, assincronamente, ao servidor com a mensagem escrita pelo cliente na TextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_SendMessage_Click(object sender, EventArgs e)
        {
            // Verifica se a string está vazia ou é null
            if (String.IsNullOrEmpty(TxtBox_Message.Text)) return;

            string message = TxtBox_Message.Text;

            // Dá reset do texto na TextBox
            TxtBox_Message.Text = string.Empty;

            // Verifica se a app já está a trabalhar em algo
            if (!_app.Cliente.IsWorking)
            {
                // A app passa a trabalhar em algo
                _app.Cliente.IsWorking = true;

                // Espera, assincronamente, que a mensagem seja enviada para o server
                await Task.Run(() => _app.Cliente.SendMessageToServer($"MESSAGE;{_app.Cliente.Username};{message}", ProtocolSICmdType.SYM_CIPHER_DATA, false));
            }
            else
            {
                // Verifica se já existe alguma notificação aberta
                if (_app.Cliente.NotificationOpen) return;

                // A app passa a ter uma notificação aberta
                _app.Cliente.NotificationOpen = true;

                // Amostra a notificação assíncronamente
                Task.Run(() => Client.ShowNotification(_app, "Espere que a operação acabe!"));

            }

        }

        #region Custom UI

        // Only first time
        private bool _hasDoneFirstTime = false;
        private void Panel_ChatMessagesContainer_Resize(object sender, EventArgs e)
        {
            if (Panel_ChatMessagesContainer.VerticalScroll.Visible && !_hasDoneFirstTime)
            {
                int additionalWidth = 10;
                TableLayoutPanel_ChatContainer.MaximumSize = new Size(TableLayoutPanel_ChatContainer.Width + additionalWidth,TableLayoutPanel_ChatContainer.Height);
                TableLayoutPanel_ChatContainer.Width += additionalWidth;

                this._hasDoneFirstTime = true;
            }
        }

        #endregion
    }
}
