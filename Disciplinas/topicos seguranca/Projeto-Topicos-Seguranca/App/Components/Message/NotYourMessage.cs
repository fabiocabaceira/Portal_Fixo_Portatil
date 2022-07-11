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
    public partial class NotYourMessage : Form
    {
        #region Custom UI

        private CustomFont _customFont;
        
        private int _realHeight;

        private string _name;
        private string _profileIconName;
        private string _message;

        public int RealHeight { get { return _realHeight; } }

        public NotYourMessage(string name, string message, string profileIconName)
        {
            InitializeComponent();

            _customFont = new CustomFont();

            _realHeight = this.Height;

            _name = name;
            _message = message;
            _profileIconName = profileIconName;
        }

        private void NotYourMessage_Load(object sender, EventArgs e)
        {
            string[] fontWeightsForControls = { "Regular", "Regular", "Regular" };
            _customFont.SetCustomFont(fontWeightsForControls, Lbl_ProfileNameHolder, TxtBox_MessageHolder, Lbl_ProfilePicName);

            Lbl_ProfileNameHolder.Text = this._name;

            TxtBox_MessageHolder.SelectionAlignment = HorizontalAlignment.Right;
            TxtBox_MessageHolder.Text = this._message;


            MessageHelper.LoadProfileIconAndName(Panel_Profile, PictureBox_ProfilePic, Lbl_ProfilePicName, this._profileIconName, this._name);
        }

        private void TxtBox_MessageHolder_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            if (TxtBox_MessageHolder.Height != e.NewRectangle.Height)
            {
                _realHeight -= TxtBox_MessageHolder.Height;
                _realHeight += e.NewRectangle.Height;
            }

            TxtBox_MessageHolder.Height = e.NewRectangle.Height;
        }
        #endregion
    }
}
