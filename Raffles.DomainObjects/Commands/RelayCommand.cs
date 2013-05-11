using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Raffles.DomainObjects.Commands
{
    
    public class RelayCommand : ICommand
    {
        #region Fields
        private Action<object> execute;
        private Predicate<object> canExecute;
        #endregion 

        #region Constructors
        public RelayCommand(Action<object> execute)
            : this(execute, null) { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute) {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter) {
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter) {
            execute(parameter);
        }
        public event EventHandler CanExecuteChanged {
            add {
                if (canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove {
                if (canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
        #endregion


    }
     
}
