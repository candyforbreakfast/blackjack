using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Blackjack {
    /// <summary>
    /// MVVM Command binding.
    /// </summary>
    /// <remarks>
    /// thanks http://msdn.microsoft.com/en-us/magazine/dd419663.aspx
    /// </remarks>
    public class RelayCommand : ICommand {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        [DebuggerStepThrough]
        public RelayCommand(Action<object> execute, Predicate<object> canexecute) {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canexecute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null) { }
        [DebuggerStepThrough]
        public bool CanExecute(object parameter) {
            return (_canExecute == null || _canExecute(parameter));
        }
        [DebuggerStepThrough]
        public void Execute(object parameter) {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
