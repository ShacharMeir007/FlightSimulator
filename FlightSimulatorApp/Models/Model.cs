using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace FlightSimulatorApp.Models
{
    public class Model:IFlightSimulatorModel
    {
        private volatile bool _run;
        private readonly ITelnet _telnet;
        private readonly XmlPropertiesAnalyzer _analyzer;
        private double _rudder = 10;
        private string _indicatedHeadingDeg;
        private string _gpsIndicatedVerticalSpeed;
        private string _gpsIndicatedGroundSpeedKt;
        private string _airspeedIndicatorIndicatedSpeedKt;
        private string _gpsIndicatedAltitudeFt;
        private string _attitudeIndicatorInternalRollDeg;
        private string _attitudeIndicatorInternalPitchDeg;
        private string _altimeterIndicatedAltitudeFt;
        private double _elevator;
        private double _aileron;
        private double _throttle;

        public Model(ITelnet telnet)
        {
            _telnet = telnet;
            _analyzer = new XmlPropertiesAnalyzer();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string IndicatedHeadingDeg
        {
            get => _indicatedHeadingDeg;
            set 
            {
                _indicatedHeadingDeg = value;
                Notify("IndicatedHeadingDeg");
            }
        }
        public string GpsIndicatedVerticalSpeed {
            get => _gpsIndicatedVerticalSpeed;
            set
            {
                _gpsIndicatedVerticalSpeed = value;
                Notify("GpsIndicatedVerticalSpeed");
            }
        }
        public string GpsIndicatedGroundSpeedKt {
            get => _gpsIndicatedGroundSpeedKt;
            set
            {
                _gpsIndicatedGroundSpeedKt = value;
                Notify("GpsIndicatedGroundSpeedKt");
            }
        }
        public string AirspeedIndicatorIndicatedSpeedKt {
            get => _airspeedIndicatorIndicatedSpeedKt;
            set
            {
                _airspeedIndicatorIndicatedSpeedKt = value;
                Notify("AirspeedIndicatorIndicatedSpeedKt");
            }
        }
        public string GpsIndicatedAltitudeFt {
            get => _gpsIndicatedAltitudeFt;
            set
            {
                _gpsIndicatedAltitudeFt = value;
                Notify("GpsIndicatedAltitudeFt");
            }
        }
        public string AttitudeIndicatorInternalRollDeg {
            get => _attitudeIndicatorInternalRollDeg;
            set
            {
                _attitudeIndicatorInternalRollDeg = value;
                Notify("AttitudeIndicatorInternalRollDeg");
            }
        }
        public string AttitudeIndicatorInternalPitchDeg {
            get => _attitudeIndicatorInternalPitchDeg;
            set
            {
                _attitudeIndicatorInternalPitchDeg = value;
                Notify("AttitudeIndicatorInternalPitchDeg");
            }
        }
        public string AltimeterIndicatedAltitudeFt {
            get => _altimeterIndicatedAltitudeFt;
            set
            {
                _altimeterIndicatedAltitudeFt = value;
                Notify("AltimeterIndicatedAltitudeFt");
            }
        }
        
        public double Rudder
        {
            get => _rudder;
            set
            {
                _rudder = value; 
                Notify("Rudder");
            }
        }

        public double Elevator
        {
            get => _elevator;
            set
            {
                _elevator = value; 
                Notify("Elevator");
            }
        }

        public double Aileron
        {
            get => _aileron;
            set
            {
                _aileron = value; 
                Notify("Aileron");
                
            }
        }

        public double Throttle
        {
            get => _throttle;
            set
            {
                _throttle = value; 
                Notify("Throttle");
            }
        }
        
        public void Start()
        {
            _run = true;
            _telnet.Connect();
            new Thread(delegate()
            {
                while (_run)
                {
                    Debug.WriteLine(Rudder);
                    
                    int min = Math.Min(_analyzer.GetCommends.Count, 8);
                    for (int i = 0; i < min; i++)
                    {
                        _telnet.Write(_analyzer.GetCommends[i]);
                        string value = _telnet.Read();
                        InsertValueToProperty(_analyzer.PropertiesOrder[i], value);
                    }
                    this._telnet.Write("set /controls/flight/rudder " + Rudder);
                    this.Rudder = Convert.ToDouble(_telnet.Read());
                    this._telnet.Write("set /controls/flight/elevator " + Elevator);
                    this.Elevator = Convert.ToDouble(_telnet.Read());
                    this._telnet.Write("set /controls/flight/aileron " + Aileron);
                    this.Aileron = Convert.ToDouble(_telnet.Read());
                    this._telnet.Write("set /controls/engines/engine/throttle " + Throttle);
                    this.Throttle = Convert.ToDouble(_telnet.Read());
                    Thread.Sleep(50);
                }
            }).Start();
        }

        public void Stop()
        {
            _run = false;
        }
        
        private void InsertValueToProperty(string property, string value)
        {
            switch (property)
            {
                case "airspeed-indicator_indicated-speed-kt":
                    this.AirspeedIndicatorIndicatedSpeedKt = value;
                    break;
                case "altimeter_indicated-altitude-ft":
                    this.AltimeterIndicatedAltitudeFt = value;
                    break;
                case "attitude-indicator_internal-pitch-deg":
                    this.AttitudeIndicatorInternalPitchDeg = value;
                    break;
                case "attitude-indicator_internal-roll-deg":
                    this.AttitudeIndicatorInternalRollDeg = value;
                    break;
                case "indicated-heading-deg":
                    this.IndicatedHeadingDeg = value;
                    break;
                case "gps_indicated-vertical-speed":
                    this.GpsIndicatedVerticalSpeed = value;
                    break;
                case "gps_indicated-ground-speed-kt":
                    this.GpsIndicatedGroundSpeedKt = value;
                    break;
                case "gps_indicated-altitude-ft":
                    this.GpsIndicatedAltitudeFt = value;
                    break;
                default:
                    break;
                    
            }
        }

        private void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}