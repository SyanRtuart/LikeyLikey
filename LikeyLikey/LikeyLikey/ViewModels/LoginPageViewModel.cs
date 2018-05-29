﻿using System.Windows.Input;
using Xamarin.Forms;
using LikeyLikey.Abstractions;
using LikeyLikey.Views;

namespace LikeyLikey.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginAttemptCommand { get; private set; }
        public ICommand NavigateToRegisterPageCommand { get; private set; }

        public string Title { get; set; } = "Likey? Likey!";

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    ((Command)LoginAttemptCommand).ChangeCanExecute();
                }
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    ((Command)LoginAttemptCommand).ChangeCanExecute();
                }
            }
        }

        public bool RememberMe { get; set; }

        private readonly IPageService _pageService;
        public LoginPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            LoginAttemptCommand = new Command(LoginAttempt, CanLogin);
            NavigateToRegisterPageCommand = new Command(NavigateToRegisterPage);
        }

        private void LoginAttempt()
        {
            if (Email == "1" & Password == "1")
            {
                _pageService.PushAsync(new MainPage());
            }
            else
            {
                _pageService.DisplayAlert("Invalid!", "Invalid Login", "Ok", "Cancel");
            }

        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private void NavigateToRegisterPage()
        {
            _pageService.PushAsync(new RegisterPage());

        }


    }
}
