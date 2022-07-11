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
    // Nota: 
    // Alguns eventos têm o código comentado porque o chat layout estava a dar problemas quando se dava resize na janela
    // por isso decidiu-se deixar o programa maximizado todo o tempo
    public partial class AppHeader : Form
    {
        private App _app;

        #region Custom UI

        //private bool _wantToMaximize;

        //private Point _lastPoint;

        #endregion

        public AppHeader(App app)
        {
            InitializeComponent();

            _app = app;

            #region Custom UI
            //this._wantToMaximize = false;
            #endregion
        }

        #region Custom UI

        private void AppHeader_Load(object sender, EventArgs e)
        {
            /* Meter o border com uma cor transparent para quando se clica fora da app os borders dos botões não "aparecerem"
             * https://stackoverflow.com/questions/9399215/c-sharp-winforms-custom-button-unwanted-border-when-form-unselected
             */

            Btn_Minimize.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            Btn_Maximize.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            Btn_CloseApp.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.ParentForm.WindowState = FormWindowState.Minimized;
        }

        
        private void Btn_Maximize_Click(object sender, EventArgs e)
        {
            /*

            this._wantToMaximize = !this._wantToMaximize;

            if (this._wantToMaximize)
            {
                this.ParentForm.WindowState = FormWindowState.Maximized;

            } else
            {
                this.ParentForm.WindowState = FormWindowState.Normal;
            }
            */
            
        }

        #endregion

        /// <summary>
        /// Fecha a app utilizando o método CloseSafely da App
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_CloseApp_Click(object sender, EventArgs e)
        {
            _app.CloseSafely();
        }

        #region Custom UI
        /*
        
        /* Dragable Form
         * https://www.youtube.com/watch?v=KTTkDhuPV_c
         */
        private void FlowLayoutPanel_AppHeader_MouseDown(object sender, MouseEventArgs e)
        { 
            //this._lastPoint = new Point(e.X, e.Y);
        }

        private void FlowLayoutPanel_AppHeader_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            if(e.Button == MouseButtons.Left)
            {
                this.ParentForm.Left += e.X - this._lastPoint.X;
                this.ParentForm.Top += e.Y - this._lastPoint.Y;
            }
            */
        }
        #endregion
    }
}
