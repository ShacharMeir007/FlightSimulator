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
        IFlightSimulatorModel model;
        public FlightSimulatorViewModel(IFlightSimulatorModel model)
        {
            this.model = model;
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs property)
            {
                Console.WriteLine("norified " + property.PropertyName);
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(property.PropertyName));
            };
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public String IndicatedHeadingDeg {
            get { return model.IndicatedHeadingDeg; }
            set { model.IndicatedHeadingDeg = value; }
        }
        public String GpsIndicatedVerticalSpeed
        {
            get { return model.GpsIndicatedVerticalSpeed; }
            set { model.GpsIndicatedVerticalSpeed = value; }
        }
        public String GpsIndicatedGroundSpeedKt
        {
            get { return model.GpsIndicatedGroundSpeedKt; }
            set { model.GpsIndicatedGroundSpeedKt = value; }
        }
        public String AirspeedIndicatorIndicatedSpeedKt
        {
            get { return model.AirspeedIndicatorIndicatedSpeedKt; }
            set { model.AirspeedIndicatorIndicatedSpeedKt = value; }
        }
        public String GpsIndicatedAltitudeFt
        {
            get { return model.GpsIndicatedAltitudeFt; }
            set { model.GpsIndicatedAltitudeFt = value; }
        }
        public String AttitudeIndicatorInternalRollDeg
        {
            get { return model.AttitudeIndicatorInternalRollDeg; }
            set { model.AttitudeIndicatorInternalRollDeg = value; }
        }
        public String AttitudeIndicatorInternalPitchDeg
        {
            get { return model.AttitudeIndicatorInternalPitchDeg; }
            set { model.AttitudeIndicatorInternalPitchDeg = value; }
        }
        public String AltimeterIndicatedAltitudeFt
        {
            get { return model.AltimeterIndicatedAltitudeFt; }
            set { model.AltimeterIndicatedAltitudeFt = value; }
        }
    }
}
