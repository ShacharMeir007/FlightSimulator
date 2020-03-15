using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace FlightSimulatorApp
{
    class FlightSimulatorViewModel:INotifyPropertyChanged
    {
        private readonly IFlightSimulatorModel _model;
        public FlightSimulatorViewModel(IFlightSimulatorModel model)
        {
            this._model = model;
            this._model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs property)
            {
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(property.PropertyName));
            };
        }

        public void Start()
        {
            this._model.Connect();
            this._model.Start();
        }
        public void Stop()
        {
            this._model.Stop();
            this._model.Disconnect();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public String IndicatedHeadingDeg {
            get => _model.IndicatedHeadingDeg;
            set => _model.IndicatedHeadingDeg = value;
        }
        public String GpsIndicatedVerticalSpeed
        {
            get => _model.GpsIndicatedVerticalSpeed;
            set => _model.GpsIndicatedVerticalSpeed = value;
        }
        public String GpsIndicatedGroundSpeedKt
        {
            get => _model.GpsIndicatedGroundSpeedKt;
            set => _model.GpsIndicatedGroundSpeedKt = value;
        }
        public String AirspeedIndicatorIndicatedSpeedKt
        {
            get => _model.AirspeedIndicatorIndicatedSpeedKt;
            set => _model.AirspeedIndicatorIndicatedSpeedKt = value;
        }
        public String GpsIndicatedAltitudeFt
        {
            get => _model.GpsIndicatedAltitudeFt;
            set => _model.GpsIndicatedAltitudeFt = value;
        }
        public String AttitudeIndicatorInternalRollDeg
        {
            get => _model.AttitudeIndicatorInternalRollDeg;
            set => _model.AttitudeIndicatorInternalRollDeg = value;
        }
        public String AttitudeIndicatorInternalPitchDeg
        {
            get => _model.AttitudeIndicatorInternalPitchDeg;
            set => _model.AttitudeIndicatorInternalPitchDeg = value;
        }
        public String AltimeterIndicatedAltitudeFt
        {
            get => _model.AltimeterIndicatedAltitudeFt;
            set => _model.AltimeterIndicatedAltitudeFt = value;
        }
    }
}
