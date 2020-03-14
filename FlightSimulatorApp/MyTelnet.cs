using System;
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
        private XmlPropertiesAnalyzer _analyzer;
        private bool _isConnected = false;

        public MyTelnet()
        {
            _analyzer = new XmlPropertiesAnalyzer();
        }

        public void Connect()
        {
            _client = new TcpClient();
            try
            {
                _client.Connect("localhost", 5600);
                _isConnected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
           
        }

        public void Disconnect()
        {
            _client.Close();
            _isConnected = false;
        }

        public string Read()
        {
            if (!_isConnected)
            {
                string errMsg = "";
                Random random = new Random();
                for (int i = 0; i < 8; i++)
                {
                    errMsg += random.Next(1000).ToString() + _analyzer.Delimiter; 
                }

                return errMsg;
            }
            string msg = "";
            foreach (string getCommend in _analyzer.GetCommends)
            {
                Write(getCommend);
                NetworkStream serverStream = _client.GetStream();
                int size = _client.ReceiveBufferSize;
                byte[] buffer = new byte[size];
                serverStream.Read(buffer, 0, size);
                msg += Encoding.ASCII.GetString(buffer);
                msg += _analyzer.Delimiter;
            }
            return msg;
        }

        public void Write(string msg)
        {
            throw new NotImplementedException();
        }
    }
}