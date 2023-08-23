using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkylightFrameKonfigurator.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //implement interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            // is not 0:the null-conditional operator (?.) to check if there are any subscribers to the PropertyChanged event.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
