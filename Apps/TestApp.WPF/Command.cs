using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestApp.WPF
{
    public class Command : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Command(Action execute) : this(execute, null) { }

        public Command(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;
            return canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
