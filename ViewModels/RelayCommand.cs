using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels
{
    public class RelayCommand : ICommand
    {
        Action<object> ExecuteDelegate;
        Predicate<object> CanExecuteDelegate;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> executeDelegate, Predicate<object> canExecuteDelegate = null)
        {
            this.ExecuteDelegate = executeDelegate;
            this.CanExecuteDelegate = canExecuteDelegate;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter) => ((CanExecuteDelegate == null) || CanExecuteDelegate(parameter));
       

        public void Execute(object parameter)
        {
            ExecuteDelegate?.Invoke(parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
