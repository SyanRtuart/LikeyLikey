using LikeyLikey.Abstractions;
using LikeyLikey.Models;
using System.Windows.Input;
using Xamarin.Forms;
using LikeyLikey.Helpers;
using LikeyLikey.Services;

namespace LikeyLikey.ViewModels
{
    public class RegisterPageViewModel : BaseViewModel
    {
        public ICommand RegisterAttemptCommand
        {
            get
            {
                return new Command(async () =>
                    {
                        var isSuccess = await _apiService.RegisterAsync(Email, Password, ConfirmPassword);

                        if (isSuccess)
                        {
                            Settings.Email = Email;
                            Settings.Password = Password;
                            await _pageService.PopModalAsync();
                        }
                        else
                            await _pageService.DisplayAlert("Unsuccessful", "Unable to register - Please try again", "Ok", "Cancel");

                        
                    }, CanRegister);
            }
        }


        private User _userRegistering = new User();
        private ApiService _apiService = new ApiService();

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


        public string Title { get; set; } = "Register";

        private readonly IPageService _pageService;
        public RegisterPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
#if DEBUG
            Email = "ryan@likeylikey.com";
            Password = "likeylikeyPassword";
#endif 
        }
        

        private bool CanRegister()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }




    }
}
