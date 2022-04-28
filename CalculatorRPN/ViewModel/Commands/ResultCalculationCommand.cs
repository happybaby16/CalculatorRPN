using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorRPN.ViewModel.Commands
{
    public class ResultCalculationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action<object> _execute;

        public ResultCalculationCommand(Action<object> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
