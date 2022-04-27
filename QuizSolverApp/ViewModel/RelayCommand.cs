using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace QuizMVVM.ViewModel
{
    public class RelayCommand : ICommand
    {
        #region EXECUTES
#pragma warning disable CS8612 // Obsługa wartości null dla typów referencyjnych w typie jest niezgodna z niejawnie implementowaną składową.
        public event EventHandler CanExecuteChanged
#pragma warning restore CS8612 // Obsługa wartości null dla typów referencyjnych w typie jest niezgodna z niejawnie implementowaną składową.
        {
            add
            {
                if (canExecute != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (canExecute != null) CommandManager.RequerySuggested -= value;
            }
        }

        private Action<object> execute;
        private Predicate<object> canExecute;

#pragma warning disable CS8625 // Nie można przekonwertować literału o wartości null na nienullowalny typ referencyjny.
        public RelayCommand(Action<object> execute) : this(execute, null)
#pragma warning restore CS8625 // Nie można przekonwertować literału o wartości null na nienullowalny typ referencyjny.
        { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }


#pragma warning disable CS8767 // Dopuszczanie wartości null dla typów referencyjnych w typie parametru nie jest zgodne z niejawnie zaimplementowaną składową (prawdopodobnie z powodu atrybutów dopuszczania wartości null).
        public bool CanExecute(object parameter)
#pragma warning restore CS8767 // Dopuszczanie wartości null dla typów referencyjnych w typie parametru nie jest zgodne z niejawnie zaimplementowaną składową (prawdopodobnie z powodu atrybutów dopuszczania wartości null).
        {

            return canExecute == null ? true : canExecute(parameter);
        }

#pragma warning disable CS8767 // Dopuszczanie wartości null dla typów referencyjnych w typie parametru nie jest zgodne z niejawnie zaimplementowaną składową (prawdopodobnie z powodu atrybutów dopuszczania wartości null).
        public void Execute(object parameter) => execute(parameter);
#pragma warning restore CS8767 // Dopuszczanie wartości null dla typów referencyjnych w typie parametru nie jest zgodne z niejawnie zaimplementowaną składową (prawdopodobnie z powodu atrybutów dopuszczania wartości null).
        #endregion
    }
}
