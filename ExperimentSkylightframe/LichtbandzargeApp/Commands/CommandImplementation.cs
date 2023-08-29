using System;
using System.Windows.Input;
//next ones maybe are not used:
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LichtbandzargeApp.Commands
{
    public class CustomCommandImplementation : ICommand
    {
        private readonly Action<object> _execute;
        //private Predicate<object> _canExecute;
        private readonly Func<object, bool> _canExecute;

        
        public CustomCommandImplementation(Action<object> execute) : this(execute, null)
        {

        }

        public CustomCommandImplementation(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute ?? (x => true);
        }

        
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
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

        public void Refresh()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }

}
