using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FlightSimulatorApp.Views
{
    public partial class Joystick : UserControl
    {
       
        private bool _pressed;
        private bool _stoppedMoving = true;
        private const int _latency = 30; 
        public Joystick()
        {
            InitializeComponent();
        }

        private void centerKnob_Completed(object sender, EventArgs e)
        {
            Storyboard storyboard = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
        }

        private void Knob_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this._pressed = true;
            Canvas c = sender as Canvas;
            Point p = e.GetPosition(c);
            MoveKnob(p.X,p.Y,_latency);
        }

        private void Knob_OnMouseMove(object sender, MouseEventArgs e)
        {
            Canvas c = sender as Canvas;
            Point p = e.GetPosition(c);
            if (this._pressed && _stoppedMoving)
            {
                MoveKnob(p.X,p.Y,_latency);
            }
        }

        private void Knob_OnMouseUP(object sender, MouseButtonEventArgs e)
        {
            ResetKnob();
        }

        private void Knob_OnMouseLeave(object sender, MouseEventArgs e)
        {
            ResetKnob();
        }

        private void MoveKnob(double x, double y, int milli)
        {
            double additionX = x - KnobBase.Width/2;
            double additionY = y - KnobBase.Height/2;
            int extended = 0;
            double dist = Dist(knobPosition.X + additionX, knobPosition.Y + additionY, 0, 0);
            if ( dist >= 42)
            {
                extended = 1;
                Console.WriteLine();
                
            }
            DoubleAnimation animationX = new DoubleAnimation();
            _stoppedMoving = false;
            animationX.From = knobPosition.X;
            animationX.To = (knobPosition.X + additionX)*Math.Pow(40 / dist,extended);
            animationX.Completed += (sender, args) => { _stoppedMoving = true; };
            animationX.Duration = new Duration(new TimeSpan(0,0,0,0,milli));
            DoubleAnimation animationY = new DoubleAnimation();
            animationY.From = knobPosition.Y;
            animationY.To = (knobPosition.Y + additionY)*Math.Pow(40 / dist,extended);;
            animationY.Duration = new Duration(new TimeSpan(0,0,0,0,milli));
            
            knobPosition.BeginAnimation(TranslateTransform.XProperty, animationX);
            knobPosition.BeginAnimation(TranslateTransform.YProperty, animationY);
        }

        private void ResetKnob()
        {
            this._pressed = false;
            DoubleAnimation animationX = new DoubleAnimation();
            animationX.From = knobPosition.X;
            animationX.To = 0;
            animationX.Duration = new Duration(new TimeSpan(0,0,0,0,500));
            DoubleAnimation animationY = new DoubleAnimation();
            animationY.From = knobPosition.Y;
            animationY.To = 0;
            animationY.Duration = new Duration(new TimeSpan(0,0,0,0,500));
            knobPosition.BeginAnimation(TranslateTransform.XProperty, animationX);
            knobPosition.BeginAnimation(TranslateTransform.YProperty, animationY);
        }

        private double Dist(double x, double y, double x0, double y0)
        {
            return Math.Sqrt(Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2));
        }
    }
}