using System.Windows.Input;
using Xamarin.Forms;
using LikeyLikey.Abstractions;
using LikeyLikey.Views;
using LikeyLikey.Helpers;
using System.Threading.Tasks;
using LikeyLikey.Services;
using System;

namespace LikeyLikey.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginAttemptCommand { get;  private set; }
        public ICommand NavigateToRegisterPageCommand { get; private set; }

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

        private readonly IApiService _apiService;
        private readonly IPageService _pageService;

        public string Title { get; set; } = "Likey? Likey!";


        public LoginPageViewModel(IPageService pageService, IApiService apiService)
        {
            _apiService = apiService;
            _pageService = pageService;
            NavigateToRegisterPageCommand = new Command(NavigateToRegisterPage);
            LoginAttemptCommand = new Command(async () => await LoginAttempt(),() => CanLogin());
            Email = Settings.Email;
            Password = Settings.Password;
            
        }

        private async Task LoginAttempt()
        {

            string accessToken = null;
            if (Settings.AccessToken == "")
                accessToken = await _apiService.LoginAsync(Email, Password);
            else
                accessToken = Settings.AccessToken;




            if (accessToken != null)
            {
                Settings.AccessToken = accessToken;

                //await _pageService.DisplayAlert("Youre in", "You have logged in - Please try again", "Ok", "Cancel");
                await _pageService.PushModalAsync(new MainPage());
            }
            else
                await _pageService.DisplayAlert("Unsuccessful", "Unable to Login - Please try again", "Ok", "Cancel");
            

        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private void NavigateToRegisterPage()
        {
            _pageService.PushModalAsync(new RegisterPage());

        }


    }
}
