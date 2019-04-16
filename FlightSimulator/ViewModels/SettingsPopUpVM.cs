using FlightSimulator.Model;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class SettingsPopUpVM
    {
        #region SettingsClickCommand
        private ICommand _settingsClickCommand;
        public ICommand SettingsClick
        {
            get
            {
                return _settingsClickCommand ?? (_settingsClickCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            var settingsClick = new SettingsWindow();
            settingsClick.Show();
        }
        #endregion
    }
}
