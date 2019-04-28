using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using FlightSimulator.ViewModels;



namespace FlightSimulator.Model
{
    class Info : BaseNotify
    {
        TcpClient _client;
        double lon;
        double lat;
        Thread threadInfo;
        //FlightBoardViewModel vm = new FlightBoardViewModel();

        public double Lon
        {
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
            get { return lon; }
        }

        public double Lat
        {
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
            get { return lat; }
        }

        public bool shouldContinue
        {
            set;
            get;
        }

        private static Info m_Instance = null;
        public static Info Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Info();
                }
                return m_Instance;
            }
        }

        public Info()
        {
            //lon = 0.0f;
            //lat = 0.0f;
            shouldContinue = true;
        }

        public void connect()
        {

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
                ApplicationSettingsModel.Instance.FlightInfoPort);
            TcpListener listener = new TcpListener(ep);
            listener.Start();
            _client = listener.AcceptTcpClient();
            Console.WriteLine("Info channel: Client connected");
            threadInfo = new Thread(() => listen(_client));
            threadInfo.Start();
        }

        public void closeThread()
        {
            _client.Close();
            shouldContinue = false;
        }

        public void listen(TcpClient _client)
        {
            Byte[] bytes;
            string[] splitMsg = new string[25];

            NetworkStream ns = _client.GetStream();

            while (shouldContinue)
            {
                if (_client.ReceiveBufferSize > 0)
                {
                    bytes = new byte[_client.ReceiveBufferSize];
                    ns.Read(bytes, 0, _client.ReceiveBufferSize);
                    string msg = Encoding.ASCII.GetString(bytes); //the message incoming
                    splitMsg = msg.Split(',');
                    Lon = float.Parse(splitMsg[0]);
                    Lat = float.Parse(splitMsg[1]);
                    Console.WriteLine(msg);

                }
            }
            ns.Close();
            _client.Close();
        }


    }
}
