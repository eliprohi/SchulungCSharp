using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SageAufbaukursCSharp.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string nameProp = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProp));
        }
    }
}
