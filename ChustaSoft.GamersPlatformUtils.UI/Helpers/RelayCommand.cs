using System;
using System.Windows.Input;

namespace ChustaSoft.GamersPlatformUtils.UI.Helpers
{
    public class RelayCommand : ICommand
    {

        Action _targetExecuteMethod;
        Func<bool> _targetCanExecuteMethod;

        public event EventHandler CanExecuteChanged = delegate { };


        public RelayCommand(Action executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }


        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }


        bool ICommand.CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                return _targetCanExecuteMethod();
            }
            if (_targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        void ICommand.Execute(object parameter)
        {
            _targetExecuteMethod?.Invoke();
        }

    }

    public class RelayCommand<T> : ICommand
    {

        Action<T> _targetExecuteMethod;
        Func<T, bool> _targetCanExecuteMethod;

        public event EventHandler CanExecuteChanged = delegate { };


        public RelayCommand(Action<T> executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }


        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                T tparm = (T)parameter;
                return _targetCanExecuteMethod(tparm);
            }
            if (_targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        void ICommand.Execute(object parameter)
        {
            _targetExecuteMethod?.Invoke((T)parameter);
        }

    }
}
