using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class ManualCnt : BaseNotify
    {
        public CommandClient commandSend = CommandClient.Instance;
    
        private double throttle = 0;
        private double aileron = 0;
        private double rudder = 0;
        private double elevator = 0;

        public double Throttle
        {
            set
            {
                throttle = value;
                string send = "set controls/engines/current-engine/throttle " + value + "\r\n"; 
                CommandClient.Instance.openThread(send);

                NotifyPropertyChanged("Throttle");

            }
            get
            {
                return throttle;

            }
        }
        public double Aileron
        {
            set
            {
                aileron = value;
                string send = "set controls/flight/aileron " + value + "\r\n"; 
                CommandClient.Instance.openThread(send);

              NotifyPropertyChanged("Aileron");

            }
            get
            {
                return aileron;

            }
        }

        public double Rudder
        {
            set
            {
                rudder = value;

                string send = "set controls/flight/rudder " + value + "\r\n"; 
                CommandClient.Instance.openThread(send);
               
               NotifyPropertyChanged("Rudder");
            }
            get
            { return rudder; }
        }

        public double Elevator
        {
            set
            {
                elevator = value;
                
                string send = "set controls/flight/elevator " + value + "\r\n"; 
                CommandClient.Instance.openThread(send);
   
                NotifyPropertyChanged("Elevator");

            }
            get
            {
                return elevator;

            }
        }
    }
}