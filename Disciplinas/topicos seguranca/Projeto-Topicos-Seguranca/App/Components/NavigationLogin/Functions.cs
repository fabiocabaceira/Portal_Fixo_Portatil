using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    internal partial class NavigationLogin
    {
        #region Custom UI
        //BtnSelected Functions
        private void ChangeSelectedBtn(Button newBtn)
        {
            Button oldBtnSelected = this._btnSelected;
            _btnSelected = newBtn;

            ChangeBtnVisuals(oldBtnSelected);
        }

        private void ChangeBtnVisuals(Button oldBtn = null)
        {
            if (oldBtn != null)
            {
                oldBtn.ForeColor = _btnNormalTextClr;
                oldBtn.Image = (Image)Properties.Resources.ResourceManager.GetObject(ParseName(oldBtn, "_normal"));
                oldBtn.BackColor = _btnNormalBgClr;

                oldBtn.FlatAppearance.MouseOverBackColor = _btnHoverBgClr;
                oldBtn.FlatAppearance.MouseDownBackColor = _btnFocusBgClr;
            }

            _btnSelected.ForeColor = _btnActiveTextClr;
            _btnSelected.Image = (Image)Properties.Resources.ResourceManager.GetObject(ParseName(_btnSelected, "_active"));
            _btnSelected.BackColor = _btnActiveBgClr;

            _btnSelected.FlatAppearance.MouseOverBackColor = _btnActiveBgClr;
            _btnSelected.FlatAppearance.MouseDownBackColor = _btnActiveBgClr;
        }

        private string ParseName(Control control, string suffix = "")
        {
            string[] palavras = control.Name.Split('_');
            string name = $"{palavras[1]}{suffix}";
            return name;
        }

        #endregion
    }
}
