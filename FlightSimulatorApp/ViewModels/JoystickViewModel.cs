using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FlightSimulatorApp.Annotations;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.ViewModels
{
    public class JoystickViewModel:IViewModel
    {
        private IFlightSimulatorModel _model;
        public event PropertyChangedEventHandler PropertyChanged;
        public JoystickViewModel(IFlightSimulatorModel model)
        {
            this._model = model;
            this._model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs property)
            {
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(property.PropertyName));
            };
            //_model.Rudder = -15;
        }

        public double Rudder
        {
            get => _model.Rudder;
            set
            {
                _model.Rudder = value;
                Debug.WriteLine("change rudder vm");
            }
        }

        public double Elevator
        {
            get => _model.Elevator;
            set => _model.Elevator = value;
        }

        public double Aileron
        {
            get => _model.Aileron;
            set => _model.Aileron = value;
        }

        public double Throttle
        {
            get => _model.Throttle;
            set => _model.Throttle = value;
        }

        private string PointToValue(string rudder)
        {
            return "";
        }

        public void Start()
        {
            this._model.Start();
        }

        public void Stop()
        {
            this._model.Stop();
        }
    }
}