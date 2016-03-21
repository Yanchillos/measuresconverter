using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeasuresConverter.MVVMEngine
{
    public class RelayCommandParameterless : ICommand
    {
        private Action methodToExecute;
        private Func<bool> canExecuteEvaluator;

        public RelayCommandParameterless(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        public RelayCommandParameterless(Action methodToExecute)
            : this(methodToExecute, null)
        {
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

        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
