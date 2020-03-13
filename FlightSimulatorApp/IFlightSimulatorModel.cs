using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace FlightSimulatorApp
{
    
    interface IFlightSimulatorModel:INotifyPropertyChanged
    {
        string IndicatedHeadingDeg { get; set; }
        string GpsIndicatedVerticalSpeed { get; set; }
        string GpsIndicatedGroundSpeedKt { get; set; }
        string AirspeedIndicatorIndicatedSpeedKt { get; set; }
        string GpsIndicatedAltitudeFt { get; set; }
        string AttitudeIndicatorInternalRollDeg { get; set; }
        string AttitudeIndicatorInternalPitchDeg { get; set; }
        string AltimeterIndicatedAltitudeFt { get; set; }
        void Connect();
        void Disconnect();
        void Start();
        void Stop();
        //Pixel GetMapLocation();
        //void TranslatePositionToSimulatorValues(Pos p);
    }
}