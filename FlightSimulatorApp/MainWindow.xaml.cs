using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FlightSimulatorViewModel vm = new FlightSimulatorViewModel(new MyFlightSimulatorModel(new MyTelnet()));//initiate a real Model later
        public MainWindow()
        {
            InitializeComponent();
            dash.DataContext = vm;
            DataContext = vm;
            vm.AltimeterIndicatedAltitudeFt = "1";
            vm.AttitudeIndicatorInternalPitchDeg = "2";
            vm.AttitudeIndicatorInternalRollDeg = "3";
            vm.AirspeedIndicatorIndicatedSpeedKt = "4";
            vm.GpsIndicatedAltitudeFt = "5";
            vm.GpsIndicatedGroundSpeedKt = "6";
            vm.GpsIndicatedVerticalSpeed = "7";
            vm.IndicatedHeadingDeg = "8";
        }

        private void DashBoard_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}