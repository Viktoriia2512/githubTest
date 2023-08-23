using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkylightFrameKonfigurator.ViewModels
{
    public class Commands : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public Commands(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }

        }

        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }


        void ICommand.Execute(object parameter)
        {
            _execute(parameter);
        }

    }
}
