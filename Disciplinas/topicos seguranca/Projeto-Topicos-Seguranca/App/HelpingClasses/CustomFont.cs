using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace App
{
    public class CustomFont
    {
        #region Custom UI
        private PrivateFontCollection _pfc;

        public CustomFont() {
            InitCustomFont();
        }

        private void InitCustomFont()
        {
            _pfc = new PrivateFontCollection();

            _pfc.AddFontFile($"{Application.StartupPath}/Assets/font/RobotoSlab-Regular.ttf");
            _pfc.AddFontFile($"{Application.StartupPath}/Assets/font/RobotoSlab-Bold.ttf");

        }

        public void SetCustomFont(string[] fontWeight,params Control[] controls)
        {
           
            int counter = 0;
            foreach (Control control in controls)
            {
                switch(fontWeight[counter])
                {
                    case "regular": 
                    case "Regular":
                        control.Font = new Font(Array.Find(_pfc.Families,ele => string.Equals(ele.Name, "Roboto Slab Regular")), control.Font.Size);
                        break;

                    case "bold":
                    case "Bold":
                        control.Font = new Font(Array.Find(_pfc.Families, ele => string.Equals(ele.Name, "Roboto Slab Bold")), control.Font.Size);
                        break;
                }
                
                counter++;
            }
        }
        #endregion
    }
}
