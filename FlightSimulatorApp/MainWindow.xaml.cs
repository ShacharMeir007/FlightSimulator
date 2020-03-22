using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using FlightSimulatorApp.Models;
using FlightSimulatorApp.ViewModels;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IFlightSimulatorModel _model = new Model(new MyTelnet());
        

        public MainWindow()
        {
            InitializeComponent();
            Dash.DataContext = new DashBoardViewModel(_model);
            Joystick.DataContext = new JoystickViewModel(_model);
            _model.Start();
        }

        private void DashBoard_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            _model.Stop();
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            
        }
    }
}