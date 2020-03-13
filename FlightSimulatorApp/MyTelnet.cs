using System;
using System.Collections.Generic;
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
        private int _port;
        public void Connect()
        {
            _client = new TcpClient();
            _client.Connect("localhost", _port);
        }

        public void Disconnect()
        {
            _client.Close();
        }

        public string Read()
        {
            NetworkStream serverStream = _client.GetStream();
            int size = _client.ReceiveBufferSize;
            byte[] buffer = new byte[size];
            serverStream.Read(buffer, 0, size);
            string msg = Encoding.ASCII.GetString(buffer);
            return msg;
        }

        public void Write(string msg)
        {
            throw new NotImplementedException();
        }
    }
}