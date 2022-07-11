using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    internal class MessageHelper
    {
        #region Custom UI
        private List<string> allColors;

        public static string iconDarkOrange = "119_86_0";
        public static string iconDarkCyan = "0_106_130";
        public static string iconDarkBlue = "0_5_130";
        public static string iconPureViolet = "129_0_231";
        public static string iconPureBlue = "0_157_224";

        public MessageHelper() {
            allColors = new List<string>();

            allColors.Add(iconDarkOrange);
            allColors.Add(iconDarkCyan);
            allColors.Add(iconDarkBlue);
            allColors.Add(iconPureViolet);
            allColors.Add(iconPureBlue);
        }

       

        public static void CenterToContainer(Control control, Panel parent)
        {

            int centerX = (int)((parent.Width / 2) - (control.Width / 2));
            int centerY = (int)((parent.Height / 2) - (control.Height / 2));

            control.Location = new Point(centerX, centerY);
        }

        public static string GetUppercase(string name, int maxUppercases = 2)
        {
            char[] delimiter = new char[] { ' ', '-', '_' };
            string[] splitedName = name.Split(delimiter);

            List<char> allUppercases = new List<char>();


            for (int i = 0; i < splitedName.Length; i++)
            {
                string uppercase = splitedName[i].ToUpper();

                allUppercases.Add(uppercase[0]);
            }

            string choosenUppercases = null;

            if (maxUppercases > allUppercases.Count)
                maxUppercases = allUppercases.Count;

            for (int i = 0; i < maxUppercases; i++)
            {
                choosenUppercases += $"{allUppercases[i]}";
            }


            return choosenUppercases;
        }

        public static void LoadProfileIconAndName(Panel panelOfHolders,PictureBox iconHolder,Label nameHolder, string iconColor, string name)
        {
            string iconFullName = GetFullIconName(iconColor);

            iconHolder.Image = (Image)Properties.Resources.ResourceManager.GetObject(iconFullName);

            string wantedString = "clr";
            int found = iconFullName.IndexOf(wantedString);

            string colorOfIcon = iconFullName.Substring(found + wantedString.Length);

            string[] rgbColor = colorOfIcon.Split('_');
            int red = Convert.ToInt16(rgbColor[0]);
            int green = Convert.ToInt16(rgbColor[1]);
            int blue = Convert.ToInt16(rgbColor[2]);
           
            nameHolder.BackColor = Color.FromArgb(red, green, blue);

            nameHolder.Text = GetUppercase(name);
            CenterToContainer(nameHolder, panelOfHolders);

        }

        #endregion

        /// <summary>
        /// Retorna uma cor random
        /// </summary>
        /// <returns>Uma cor</returns>
        public string GetRandomIconColor()
        {
            Random rd = new Random();

            // Obtém o número random entre 0 e o tamanho da lista de cores
            int rand_num = rd.Next(0, allColors.Count);

            // Retorna a cor
            return allColors[rand_num];
        }

        #region Custom UI

        private static string GetFullIconName(string iconColor)
        {
            string fullName = "profile__icon__clr";
            fullName += iconColor;

            return fullName;
        }

        #endregion

    }
}
