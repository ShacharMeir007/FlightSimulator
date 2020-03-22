using System.ComponentModel;

namespace FlightSimulatorApp.ViewModels
{
    public interface IViewModel:INotifyPropertyChanged
    {
        void Start();
        void Stop();
    }
}