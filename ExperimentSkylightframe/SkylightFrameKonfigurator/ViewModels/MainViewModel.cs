using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkylightFrameKonfigurator.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Commands FirstCommand { get; set; }

        public MainViewModel()
        {
            FirstCommand = new Commands(o => PrintName(), o => IsAllow);
        }
        public void PrintName()
        {
            MessageBox.Show("Hi from relay command");
        }
        private bool myVar;
        private bool _isAllow;

        public bool IsAllow
        {
            get { return _isAllow; }
            set { _isAllow = value; OnPropertyChanged("IsAllow"); }
        }

    }
}
