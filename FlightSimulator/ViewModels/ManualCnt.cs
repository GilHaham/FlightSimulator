using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class ManualCnt
    {

       
        private double throttle = 0;

        public double Throttle
        {
            set
            {
                throttle = value;
                //TO-DO!!!
                //call the server model to send the valeu of the throttle to the simolator
            }
            get
            {
                return throttle;

            }
        }

        private double aileron = 0;

        public double Aileron
        {
            set
            {
                aileron = value;
                //TO-DO!!!
                //call the server model to send the valeu of the aileron to the simolator
            }
            get
            {
                return aileron;

            }
        }

        private double rudder = 0;
        public double Rudder
        {
            set
            {
                rudder = value;
                //TO-DO!!!
                //call the server model to send the valeu of the rudder to the simolator
            }
            get
            { return rudder; }
        }

        private double elevator = 0;

        public double Elevator
        {
            set
            {
                elevator = value;
                //TO-DO!!!
                //call the server model to send the valeu of the elevator to the simolator
            }
            get
            {
                return elevator;

            }
        }


    }
}

