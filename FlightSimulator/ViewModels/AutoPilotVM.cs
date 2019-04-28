using System;
using FlightSimulator.Model;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class AutoPilotVM : BaseNotify
    {
        private String content = "";
        private bool didSend = false;
        private ICommand clearCommand;
        private ICommand okCommand;
        public String BackgroundColor
        {
            get
            {
                if (content != "")
                {
                    if (didSend == true)
                    {
                        didSend = false;
                        return "White";
                    }
                    return "Pink";
                }
                else
                {
                    return "White";
                }
            }
        }
        public String Content
        {
            get { return content; }

            set
            {
                content = value;
                NotifyPropertyChanged("Content");
                NotifyPropertyChanged("BackgroundColor");
            }
        }
        public ICommand ClearCommand
        {
            get
            {
                return clearCommand ?? (clearCommand = new CommandHandler(() => ClearClick()));
            }
        }
        private void ClearClick()
        {
            content = "";
            NotifyPropertyChanged("Content");
            NotifyPropertyChanged("BackgroundColor");
        }
        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new CommandHandler(() => OKClick()));
            }
        }
        private void OKClick()
        {
            CommandClient.Instance.openThread(content);
            didSend = true;
            NotifyPropertyChanged("BackgroundColor");
        }
    }
}