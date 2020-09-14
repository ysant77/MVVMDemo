using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly bool _canExecute;
        private Action<object> _actionWithParameter;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> actionWithParameter, bool canExecute)
        {
            _actionWithParameter = actionWithParameter;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }
        public void Execute(object parameter)
        {
            _actionWithParameter(parameter);
        }
    }
}
