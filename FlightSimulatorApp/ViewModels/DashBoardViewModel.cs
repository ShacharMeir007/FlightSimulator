using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.ViewModels
{
    class DashBoardViewModel:IViewModel
    {
        private readonly IFlightSimulatorModel _model;
        public DashBoardViewModel(IFlightSimulatorModel model)
        {
            this._model = model;
            this._model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs property)
            {
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(property.PropertyName));
            };
        }

        public void Start()
        {
            this._model.Start();
        }
        public void Stop()
        {
            this._model.Stop();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string IndicatedHeadingDeg {
            get => _model.IndicatedHeadingDeg;
            set => _model.IndicatedHeadingDeg = value;
        }
        public string GpsIndicatedVerticalSpeed
        {
            get => _model.GpsIndicatedVerticalSpeed;
            set => _model.GpsIndicatedVerticalSpeed = value;
        }
        public string GpsIndicatedGroundSpeedKt
        {
            get => _model.GpsIndicatedGroundSpeedKt;
            set => _model.GpsIndicatedGroundSpeedKt = value;
        }
        public string AirspeedIndicatorIndicatedSpeedKt
        {
            get => _model.AirspeedIndicatorIndicatedSpeedKt;
            set => _model.AirspeedIndicatorIndicatedSpeedKt = value;
        }
        public string GpsIndicatedAltitudeFt
        {
            get => _model.GpsIndicatedAltitudeFt;
            set => _model.GpsIndicatedAltitudeFt = value;
        }
        public string AttitudeIndicatorInternalRollDeg
        {
            get => _model.AttitudeIndicatorInternalRollDeg;
            set => _model.AttitudeIndicatorInternalRollDeg = value;
        }
        public string AttitudeIndicatorInternalPitchDeg
        {
            get => _model.AttitudeIndicatorInternalPitchDeg;
            set => _model.AttitudeIndicatorInternalPitchDeg = value;
        }
        public string AltimeterIndicatedAltitudeFt
        {
            get => _model.AltimeterIndicatedAltitudeFt;
            set => _model.AltimeterIndicatedAltitudeFt = value;
        }
    }
}
