﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FlightSimulatorApp
{
    class MyTelnet : ITelnet
    {
        private TcpClient _client;
        private const int Port = 5600;
        private readonly XmlPropertiesAnalyzer _analyzer;
        private bool _isConnected;
        public MyTelnet()
        {
            _analyzer = new XmlPropertiesAnalyzer();
        }

        public void Connect()
        {
            _client = new TcpClient();
                if (_isConnected)
                {
                    return;
                }
                try
                {
                    _client.Connect("localhost", Port);
                    _isConnected = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
        }

        public void Disconnect()
        {
            if (_isConnected)
            {
                _client.Close();
                _isConnected = false;
            }
        }

        public string Read()
        {
            if (!_isConnected)
            {
                string errMsg = String.Empty;
                Random random = new Random();
                errMsg += random.Next(30).ToString();
                return errMsg;
            }
            string msg = String.Empty;
            try
            {
                NetworkStream serverStream = _client.GetStream();
                int size = _client.ReceiveBufferSize;
                byte[] buffer = new byte[size];
                int len = serverStream.Read(buffer, 0, size);
                buffer[len] = 0;
                msg = Encoding.Default.GetString(buffer, 0, len);
                return msg;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Err";
            }
        }

        public void Write(string msg)
        {
            try
            {
                if (!_isConnected)
                {
                    Connect();
                }
                NetworkStream serverStream = _client.GetStream();
                byte[] buffer = Encoding.ASCII.GetBytes(msg);
                serverStream.Write(buffer, 0, buffer.Length);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        
    }
}