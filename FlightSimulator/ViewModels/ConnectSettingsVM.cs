using FlightSimulator.Model;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class ConnectSettingsVM
    {
        #region SettingsClickCommand
        private ICommand _settingsClickCommand;
        public ICommand SettingsClick
        {
            get
            {
                return _settingsClickCommand ?? (_settingsClickCommand = new CommandHandler(() => OnClickSettings()));
            }
        }
        private void OnClickSettings()
        {
            var settingsClick = new SettingsWindow();
            settingsClick.Show();
        }
        #endregion

        #region ConnectClickCommand
        private ICommand _connectClickCommand;
        public ICommand ConnectClick
        {
            get
            {
                return _connectClickCommand ?? (_connectClickCommand = new CommandHandler(() => OnClickConnect()));
            }
        }
        private void OnClickConnect()
        {
            if (CommandClient.Instance.getIsConnected())
            {
                new Thread(() =>
                {
                //    CommandClient.Instance.closeThread();
                    CommandClient.Instance.connect();
                }).Start();

            }
            else
            {
                new Thread(() =>
                {
                    Info.Instance.connect();
                    CommandClient.Instance.connect();
                }).Start();
            }
        }
        #endregion
    }
}
