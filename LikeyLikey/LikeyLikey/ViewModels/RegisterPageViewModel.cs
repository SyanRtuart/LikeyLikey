using LightCaseClient;
using LikeyLikey.Abstractions;
using LikeyLikey.Models;
using LikeyLikey.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LikeyLikey.ViewModels
{
    public class RegisterPageViewModel : BaseViewModel
    {
        public ICommand RegisterAttemptCommand { get; private set; }
        public string Title { get; set; } = "Register";
        private Register _register = new Register();
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    _register.Email = _email;
                    _register.Username = _email;
                    ((Command)RegisterAttemptCommand).ChangeCanExecute();
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
                    _register.Password = _password;
                    ((Command)RegisterAttemptCommand).ChangeCanExecute();
                }
            }
        }

        private string _confirmPassword;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value;
                    _register.ConfirmPassword = _confirmPassword;
                    ((Command)RegisterAttemptCommand).ChangeCanExecute();
                }
            }
        }


        private readonly IPageService _pageService;
        public RegisterPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            RegisterAttemptCommand = new Command(RegisterAttempt, CanRegister);
        }

        private void RegisterAttempt()
        {
            string url = "http://likey20180525084949.azurewebsites.net/api/account/register";
            try
            {
                //GenericProxies.RestPost<string, (string, string)>(url, (_email, _password));

                GenericProxies.RestPost<string, Register>(url, _register);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private bool CanRegister()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }




    }
}
