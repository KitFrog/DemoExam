using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Русская_косметика.Models;

namespace Русская_косметика.ViewModels
{
    public class LoginVM : ViewModelBase
    {
        private readonly DbModel _db = new DbModel();

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand PassIn { get; set; }

        public LoginVM()
        {
            PassIn = new RelayCommand();
        }

        private bool CanExecute(object parameter)
        {
            if(Password != null && Login != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Execute(object parameter)
        {
            if (_db.IsPass(Login, Password))
            {

            }
        }
    }
}
