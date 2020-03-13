using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    abstract public class GetCommend : ICommend
    {
        public GetCommend()
        {
            GetCommedsList.AddCommend(this); 
        }

        public abstract string Commend { get; }
        public abstract string Property { get; }

    }

}