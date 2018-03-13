using DelegateCommandDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DelegateCommandDemo.ViewModel
{
    class PersonViewModel
    {
        public DelegateCommand ButtonClick { get; set; }
        public PersonModel Person { get; set; }

        public PersonViewModel()
        {
            Person = new PersonModel();
            ButtonClick = new DelegateCommand();
            ButtonClick.ExecuteCommand = new Action<object>(EditName);
            Person.Name = "Xiaobolo";
        }

        private void EditName(object obj) => Person.Name = "Hermione";
    }

    internal class DelegateCommand : ICommand
    {
        public Action<object> ExecuteCommand = null;
        public Func<object, bool> CanExecuteCommand = null;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (CanExecuteCommand != null)
            {
                return CanExecuteCommand(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            ExecuteCommand?.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
