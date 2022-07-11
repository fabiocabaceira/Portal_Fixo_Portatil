using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
namespace App
{
    public class LoaderController
    {
        #region Custom UI
        private Panel _loader;
        private Form _wantedComponent;
        #endregion

        private Form _activeComponent;
        

        public Form ActiveComponent { get { return _activeComponent; } }

        #region Custom UI

        private System.Timers.Timer _timerDelay;

        public LoaderController(Panel loader, Form activeComponent, double secondsOfDelayOfLoad = 0.05)
        {
            _loader = loader;
            _activeComponent = null;

            _timerDelay = new System.Timers.Timer
            {
                Interval = secondsOfDelayOfLoad * 1000,
            };


            SetComponentOnLoader(activeComponent);
            _activeComponent = activeComponent;
        }

        public void SetComponentOnLoader(Form component)
        {
            if (_activeComponent != null && String.Compare(_activeComponent.Name,component.Name) == 0)
                return;

            _loader.Controls.Clear();

            _wantedComponent = component;

            _wantedComponent.Dock = DockStyle.Fill;
            _wantedComponent.TopLevel = false;
            _wantedComponent.TopMost = true;
            HideControls();

            _loader.Controls.Add(this._wantedComponent);
            _wantedComponent.Show();
           
            _timerDelay.Elapsed += OnTimedEvent;
            _timerDelay.Enabled = true;

            _activeComponent = this._wantedComponent;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            
            ShowControls();

            _timerDelay.Enabled = false;
        }

        private void HideControls ()
        {
            foreach(Control control in _wantedComponent.Controls)
            {
                control.Hide();
            }
        }

        private void ShowControls()
        {
            /* Fix dos threads
             * https://www.youtube.com/watch?v=rvMIIuRXmU4
             */

            foreach (Control control in this._wantedComponent.Controls)
            {
                control.Invoke((MethodInvoker)(()=> control.Show()));
            }
        }

        #endregion
    }
}
