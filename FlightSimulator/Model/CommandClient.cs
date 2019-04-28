using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace FlightSimulator.Model
{
    class CommandClient
    {
        bool isConnnect = false;
        TcpClient tcpClient;
        Thread threadCommand;
        private static CommandClient m_Instance = null;

        public static CommandClient Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new CommandClient();
                }
                return m_Instance;
            }
        }

        public CommandClient()
        {
            //connect();
        }

        public void openThread(string input)
        {

            string[] split = Parse(input);
            threadCommand = new Thread(() => sendMessage(split, tcpClient));
            threadCommand.Start();

        }

        public void closeThread()
        {
            isConnnect = false;
            tcpClient.Close();
        }

        public void sendMessage(string[] split, TcpClient tcpClient)
        {
            if (!isConnnect)
            {
                return;
            }
            NetworkStream ns = tcpClient.GetStream();
            {

                foreach (string s in split)
                {
                    // Send data to server
                    Console.Write("Please enter a number: ");

                    string NewCommand = s;
                    NewCommand += "\r\n";
                    byte[] buff = Encoding.ASCII.GetBytes(NewCommand);
                    ns.Write(buff, 0, buff.Length);
                    Thread.Sleep(2000);
                }

            }
        }

        public void connect()
        {

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
            ApplicationSettingsModel.Instance.FlightCommandPort);
            tcpClient = new TcpClient();
            tcpClient.Connect(ep);
            isConnnect = true;
            Console.WriteLine("You are connected");
        }

        private string[] Parse(string line)
        {
            string[] newLine = { "\r\n" };
            string[] input = line.Split(newLine, StringSplitOptions.None);
            return input;
        }

        public bool getIsConnected()
        {
            return isConnnect;
        }
    }
    }

    
