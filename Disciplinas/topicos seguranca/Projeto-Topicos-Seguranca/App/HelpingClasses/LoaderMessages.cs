using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    internal class LoaderMessages
    {
        #region Custom UI
        private TableLayoutPanel _messagesContainer;
        private int _paddingBetweenMessages;
        private List<YourMessage> _myMessagesList;
        private List<NotYourMessage> _notMineMessagesList;

        public LoaderMessages(TableLayoutPanel messagesContainer, int paddingBetweenMessages)
        {
            _messagesContainer = messagesContainer;
            _paddingBetweenMessages = paddingBetweenMessages;

            _myMessagesList = new List<YourMessage>();
            _notMineMessagesList = new List<NotYourMessage>();



            _messagesContainer.RowStyles.RemoveAt(0);
            _messagesContainer.RowCount--;
            _messagesContainer.Height = 0;
        }

        public void AddMessage(YourMessage messageComponent)
        {
            _myMessagesList.Add(messageComponent);
            AddToContainer(messageComponent);
        }

        public void AddMessage(NotYourMessage messageComponent)
        {
            _notMineMessagesList.Add(messageComponent);
            AddToContainer(messageComponent);
        }

        private void AddToContainer(YourMessage component)
        {

            if (_messagesContainer.RowCount > 0)
            {
                _messagesContainer.RowCount++;
                _messagesContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, this._paddingBetweenMessages));

            }




            component.TopLevel = false;
            component.TopMost = true;
            component.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            component.Show();

            _messagesContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, component.RealHeight));
            _messagesContainer.Controls.Add(component, 1, _messagesContainer.RowCount);



            _messagesContainer.RowCount++;

        }


        private void AddToContainer(NotYourMessage component)
        {

            if (_messagesContainer.RowCount > 0)
            {
                _messagesContainer.RowCount++;
                _messagesContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, this._paddingBetweenMessages));
            }


           


            component.TopLevel = false;
            component.TopMost = true;
            component.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            component.Show();

            _messagesContainer.Controls.Add(component, 1, this._messagesContainer.RowCount);
            _messagesContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            

            _messagesContainer.RowCount++;

        }
        #endregion
    }
}
