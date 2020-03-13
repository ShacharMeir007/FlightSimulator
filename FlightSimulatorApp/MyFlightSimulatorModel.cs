using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
namespace FlightSimulatorApp
{
    class MyFlightSimulatorModel : IFlightSimulatorModel
    {
        private ITelnet telnet;
        private string indicatedHeadingDeg;
        private string gpsIndicatedVerticalSpeed;
        private string gpsIndicatedGroundSpeedKt;
        private string airspeedIndicatorIndicatedSpeedKt;
        private string gpsIndicatedAltitudeFt;
        private string attitudeIndicatorInternalRollDeg;
        private string attitudeIndicatorInternalPitchDeg;
        private string altimeterIndicatedAltitudeFt;
        private volatile bool run = true;

        public MyFlightSimulatorModel(ITelnet telnet)
        {
            this.telnet = telnet ?? throw new ArgumentNullException(nameof(telnet));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string IndicatedHeadingDeg
        {
            get => indicatedHeadingDeg;
            set 
            {
                indicatedHeadingDeg = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IndicatedHeadingDeg"));
            }
        }
        public string GpsIndicatedVerticalSpeed {
            get => gpsIndicatedVerticalSpeed;
            set
            {
                gpsIndicatedVerticalSpeed = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GpsIndicatedVerticalSpeed"));
            }
        }
        public string GpsIndicatedGroundSpeedKt {
            get => gpsIndicatedGroundSpeedKt;
            set
            {
                gpsIndicatedGroundSpeedKt = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GpsIndicatedGroundSpeedKt"));
            }
        }
        public string AirspeedIndicatorIndicatedSpeedKt {
            get => airspeedIndicatorIndicatedSpeedKt;
            set
            {
                airspeedIndicatorIndicatedSpeedKt = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AirspeedIndicatorIndicatedSpeedKt"));
            }
        }
        public string GpsIndicatedAltitudeFt {
            get => gpsIndicatedAltitudeFt;
            set
            {
                gpsIndicatedAltitudeFt = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GpsIndicatedAltitudeFt"));
            }
        }
        public string AttitudeIndicatorInternalRollDeg {
            get => attitudeIndicatorInternalRollDeg;
            set
            {
                attitudeIndicatorInternalRollDeg = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AttitudeIndicatorInternalRollDeg"));
            }
        }
        public string AttitudeIndicatorInternalPitchDeg {
            get => attitudeIndicatorInternalPitchDeg;
            set
            {
                attitudeIndicatorInternalPitchDeg = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AttitudeIndicatorInternalPitchDeg"));
            }
        }
        public string AltimeterIndicatedAltitudeFt {
            get => altimeterIndicatedAltitudeFt;
            set
            {
                altimeterIndicatedAltitudeFt = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AltimeterIndicatedAltitudeFt"));
            }
        }

        

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            this.run = true;
            telnet.Connect();
            new Thread(delegate() 
            {
                while (run)
                {
                    string input = telnet.Read();
                    HandleRead(input);
                    Thread.Sleep(250);
                }
                telnet.Disconnect();
            }).Start();
            
        }
        //updates the values of the 
        private void HandleRead(string input)
        {
            this.AirspeedIndicatorIndicatedSpeedKt = input;
        }
        public void Stop()
        {
            this.run = false;
        }
    }
}
