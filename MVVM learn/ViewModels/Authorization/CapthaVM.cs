using System;
using System.Collections.Generic;
using System.ComponentModel;
using MVVM_learn.Models;
using System.Windows.Input;
using System.Windows.Threading;
using MVVM_learn.Models.Events;

namespace MVVM_learn.ViewModels.Authorization
{
    public class CapthaVM : ViewModelBase
    {
        private DispatcherTimer timer;
        private int secondsRemaining;

        public int SecondsRemaining
        {
            get { return secondsRemaining; }
            set
            {
                if (secondsRemaining != value)
                {
                    secondsRemaining = value;
                    propertyChanged(nameof(SecondsRemaining));
                }
            }
        }

        private string captchalVisibility;
        public string CaptchaVisibility
        {
            get { return captchalVisibility; }
            set
            {
                captchalVisibility = value;
                propertyChanged(nameof(CaptchaVisibility));
            }
        }

        private string stackPanelVisibility;
        public string StackPanelVisibility
        {
            get { return stackPanelVisibility; }
            set
            {
                stackPanelVisibility = value;
                propertyChanged(nameof(StackPanelVisibility));
            }
        }

        private CapthaModel captcha;
        public CapthaModel Captcha
        {
            get { return captcha; }
            set
            {
                captcha = value;
                propertyChanged(nameof(Captcha));
            }
        }

        private string userInput;
        public string UserInput
        {
            get { return userInput; }
            set
            {
                userInput = value;
                propertyChanged(nameof(UserInput));
            }
        }

        public CapthaVM()
        {
            EventAggregator.Instance.MyEventOccured += HandleMyEvent;

            Captcha = new CapthaModel();
            timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;

            restartTimer();
            setCaptchaVisibility(false);

            Captcha.GenerateCaptha();
            ValidateCommand = new RelayCommand(validateCommandExecute, validateCommandCanExecute);
        }

        private void HandleMyEvent(object sender, MyEvent e)
        {
            string message = e.Message;

            switch (message)
            {
                case "passwordIsNotAvalible":
                    CaptchaIsNotCorrect();
                    Captcha.GenerateCaptha();
                    setCaptchaVisibility(true);
                    break;
            }
        }

        private void CaptchaIsNotCorrect()
        {
            EventAggregator.Instance.PublishMyEvent(nameof(CaptchaIsNotCorrect));
        }
        private void CaptchaIsCorrect()
        {
            EventAggregator.Instance.PublishMyEvent(nameof(CaptchaIsCorrect));
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (SecondsRemaining > 0)
            {
                SecondsRemaining--;
            }
            else
            {
                restartTimer();
                timer.Stop();
            }
        }

        private void setStackPanelVisibility(bool isVisible)
        {
            StackPanelVisibility = isVisible ? "Visible" : "Hidden";
        }

        private void setCaptchaVisibility(bool isVisible)
        {
            CaptchaVisibility = isVisible ? "Visible" : "Hidden";
        }

        private void restartTimer()
        {
            setStackPanelVisibility(false);
            secondsRemaining = 10;
        }

        private void startTimer()
        {
            setStackPanelVisibility(true);
            timer.Start();
        }

        public ICommand ValidateCommand { get; set; }

        private void validateCommandExecute(object parameter)
        {
            if (Captcha.IsEqual(UserInput))
            {
                CaptchaIsCorrect();
                //Open Some Window
            }
            else
            {
                CaptchaIsNotCorrect();
                startTimer();
            }
        }



        private bool validateCommandCanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(UserInput) && !timer.IsEnabled;
        }
    }
}
