using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    /// <summary>
    /// make singelton
    /// list of Commends to send and recive value for
    /// </summary>
    public class GetCommedsList
    {
        private static List<GetCommend> list = new List<GetCommend>();

        public static List<GetCommend> List { get => list;}

        public static void AddCommend(GetCommend commend) 
        {
            List.Add(commend);
        }
    }
}