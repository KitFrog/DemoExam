using System;
using System.ComponentModel;
using System.Windows.Input;
using MVVM_learn.Models;
using MVVM_learn.Models.Data;
using MVVM_learn.Models.Events;
using MVVM_learn.View;

namespace MVVM_learn.ViewModels.Authorization
{
    public class AuthorizationVM : ViewModelBase
    {
        private static readonly DbModel db = new DbModel();

        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible != value) { _isVisible = value; propertyChanged(nameof(IsVisible)); }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                propertyChanged(nameof(Name));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                propertyChanged(nameof(Password));
            }
        }

        private bool capthaCorrect = true;


        public ICommand PassIn { get; set; }

        public AuthorizationVM()
        {
            PassIn = new RelayCommand(PassInExecute, PassInCanExecute);

            EventAggregator.Instance.MyEventOccured += HandleMyEvent;
        }

        private void passwordIsNotAvalible()
        {
            EventAggregator.Instance.PublishMyEvent(nameof(passwordIsNotAvalible));
        }

        private void HandleMyEvent(object sender, MyEvent e)
        {
            string Message = e.Message;

            switch (Message)
            {
                case "CaptchaIsNotCorrect":
                    capthaCorrect = false;
                    break;
                case "CaptchaIsCorrect":
                    capthaCorrect = true;
                    break;
                case "ListViewIsOpened":
                    IsVisible = false;
                    break;
            }
        }

        private void PassInExecute(object parameter)
        {
            if (db.IsPass(Name, Password))
            {
                ListOfProducts obj = new ListOfProducts();
                obj.Show();
            }
            else
            {
                passwordIsNotAvalible();
                capthaCorrect = false;
            }
        }

        private bool PassInCanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Password) && capthaCorrect;
        }
    }
}
