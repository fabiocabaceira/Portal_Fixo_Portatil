using App.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    internal partial class NavigationLogin : Form
    {
        #region Custom UI
        private App _app;
        private CustomFont _customFont;


        //Navigation Buttons
        private Button _btnSelected;

        //Normal state
        private readonly Color _btnNormalTextClr;
        private readonly Color _btnNormalBgClr;

        //Hover state
        private readonly Color _btnHoverBgClr;

        //Focus state
        private readonly Color _btnFocusBgClr;

        //Active state
        private readonly Color _btnActiveTextClr;
        private readonly Color _btnActiveBgClr;

        

        public NavigationLogin(App app)
        {
            InitializeComponent();

            _customFont = new CustomFont();

            //Navigation buttons
            _btnNormalTextClr = Color.FromArgb(210, 210, 210);
            _btnNormalBgClr = Color.FromArgb(32, 32, 32);

            _btnHoverBgClr = Color.FromArgb(49, 49, 49);

            _btnFocusBgClr = Color.FromArgb(67, 67, 67);

            _btnActiveTextClr = Color.FromArgb(244, 244, 244);
            _btnActiveBgClr = Color.FromArgb(40, 40, 40);
            
            _app = app;
        }

        private void NavigationLogin_Load(object sender, EventArgs e)
        {
            Btn_Login.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            Btn_Register.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            //  Default btn selected
            ChangeSelectedBtn(Btn_Login);

            // Dar load das fontes
            string[] fontWeightsForControls = { "Regular", "Regular" };
            _customFont.SetCustomFont(fontWeightsForControls, Btn_Login, Btn_Register);
        }


        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (_btnSelected == Btn_Login) return;

            ChangeSelectedBtn(Btn_Login);

            // Muda para página login
            _app.AppFormController.SetComponentOnLoader(new LoginForm(_app));
        }

        private void Btn_Register_Click(object sender, EventArgs e)
        {
            if(_btnSelected == Btn_Register) return;


            ChangeSelectedBtn(Btn_Register);


            // Muda para página Register
            _app.AppFormController.SetComponentOnLoader(new RegisterForm(_app));
        }

        #endregion
    }
}
