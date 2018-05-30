using LightCaseClient;
using LikeyLikey.Abstractions;
using LikeyLikey.Models;
using LikeyLikey.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using LikeyLikey.Helpers;
using System.Threading.Tasks;

namespace LikeyLikey.ViewModels
{
    public class RegisterPageViewModel : BaseViewModel
    {
        public ICommand RegisterAttemptCommand { get; private set; }
        public string Title { get; set; } = "Register";
        private User _userRegistering = new User();
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    _userRegistering.Email = _email;
                    _userRegistering.Username = _email;
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
                    _userRegistering.Password = _password;
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
                    _userRegistering.ConfirmPassword = _confirmPassword;
                    ((Command)RegisterAttemptCommand).ChangeCanExecute();
                }
            }
        }


        private readonly IPageService _pageService;
        public RegisterPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            RegisterAttemptCommand = new Command(async ()  => await RegisterAttemptAsync (), CanRegister);
#if DEBUG
            Email = "ryan@likeylikey.com";
            Password = "likeylikeyPassword";
#endif 
        }


        async Task RegisterAttemptAsync()
        {
            await Task.Run(() => RegisterAttempt());

        }



        private void RegisterAttempt()
        {
            string url = "http://likey20180525084949.azurewebsites.net/api/account/register";
           
            try
            {

                GenericProxies.RestPostAsync<string, User>(url, _userRegistering,
                                    (ex, registeredUser) =>
                                    {
                                        if (ex != null)
                                        {
                                            _pageService.PopModalAsync();
                                        }
                                        else
                                        {
                                            Settings.Email = _userRegistering.Email;
                                            Settings.Password = _userRegistering.Password;
                                        }
                                                                                    
                                    }
                    );
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
