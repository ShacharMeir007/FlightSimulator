using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using FlightSimulatorApp.Models;
using FlightSimulatorApp.ViewModels;

namespace FlightSimulatorApp.Views
{
    public partial class Joystick : UserControl
    {
        private bool _pressed;
        private bool _stoppedMoving = true;
        private const int Latency = 40;
        public Joystick()
        {
            InitializeComponent();
            KnobPosition.X = 20;
        }
        

        private void Base_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this._pressed = true;
            Canvas c = sender as Canvas;
            Point p = e.GetPosition(c);
            MoveKnob(p.X,p.Y,Latency);
        }

        private void Base_OnMouseMove(object sender, MouseEventArgs e)
        {
            Canvas c = sender as Canvas;
            Point p = e.GetPosition(c);
            if (this._pressed && _stoppedMoving)
            {
                MoveKnob(p.X,p.Y,Latency);
            }

            //Debug.Text = $"{KnobPosition.X}, {KnobPosition.Y}";
        }

        private void Base_OnMouseUP(object sender, MouseButtonEventArgs e)
        {
            ResetKnob();
        }

        private void Base_OnMouseLeave(object sender, MouseEventArgs e)
        {
            ResetKnob();
        }

        private void MoveKnob(double x, double y, int milli)
        {
            double additionX = x - Base.Width/2;
            double additionY = y - Base.Height/2;
            double dist = Dist( additionX,  additionY, 0, 0);
            if ( dist >= 42)
            {
                additionX *= 40 / dist;
                additionY *= 40 / dist;
            }
            DoubleAnimation animationX = new DoubleAnimation();
            _stoppedMoving = false;
            animationX.From = KnobPosition.X;
            animationX.To = additionX;
            animationX.Completed += (sender, args) =>
            {
                _stoppedMoving = true;
                KnobPosition.X = KnobPosition.X;
                KnobPosition.Y = KnobPosition.Y;
            };
            animationX.Duration = new Duration(new TimeSpan(0,0,0,0,milli));
            DoubleAnimation animationY = new DoubleAnimation();
            animationY.From = KnobPosition.Y;
            animationY.To = additionY;
            animationY.Duration = new Duration(new TimeSpan(0,0,0,0,milli));
            
            KnobPosition.BeginAnimation(TranslateTransform.XProperty, animationX);
            KnobPosition.BeginAnimation(TranslateTransform.YProperty, animationY);
        }

        private void ResetKnob()
        {
            this._pressed = false;
            MoveKnob(Base.Width/2,Base.Height/2,500);
        }

        private double Dist(double x, double y, double x0, double y0)
        {
            return Math.Sqrt(Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2));
        }

        

       

        
    }
}