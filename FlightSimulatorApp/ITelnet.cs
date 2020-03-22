using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    public interface ITelnet
    {
        void Connect();
        string Read();
        void Write(string msg);
        void Disconnect();
    }
}