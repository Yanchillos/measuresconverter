using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeasuresConverter.MVVMEngine
{
    public class RelayCommand : ICommand
    {
        private Action<object> methodToExecute;
        private Func<bool> canExecuteEvaluator;

        public RelayCommand(Action<object> methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        public RelayCommand(Action<object> methodToExecute)
            : this(methodToExecute, null)
        {
        }

        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this.canExecuteEvaluator.Invoke();
                return result;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
