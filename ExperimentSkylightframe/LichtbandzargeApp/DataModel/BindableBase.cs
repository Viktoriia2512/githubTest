using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
//maybe next ones will not be used
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LichtbandzargeApp.DataModel
{
    public class BindableBase : INotifyPropertyChanged
    {
        // //allows to notify subscribers (such as UI controls) that a property's value has changed.
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //"..?." checks if the PropertyChanged event has any subscribers (event handlers) before invoking it.
            // If there are no subscribers, the event won't be invoked, 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // So, when the PropertyChanged event is invoked (if there are subscribers),
        // all the event handlers (methods that have been subscribed to the event) will be called.
        //This allows the UI controls to update their visuals according to the new property value.

        
        ////purpose is to set the value of a property and raise the PropertyChanged event if the new value is different from the existing one.
        //protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        //{
        //    //This checks whether the new value is equal to the current value of the property:
        //    if (EqualityComparer<T>.Default.Equals(storage, value))
        //        return false;
        //    storage = value;
        //    this.OnPropertyChanged(propertyName);
        //    return true;
        //}

    }
}
