using System.Windows.Input;
using Xamarin.Forms;
using LikeyLikey.Abstractions;
using LikeyLikey.Views;
using LikeyLikey.Helpers;
using System.Threading.Tasks;

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
            LoginAttemptCommand = new Command(async () => await LoginAttemptAsync(), CanLogin);
            NavigateToRegisterPageCommand = new Command(NavigateToRegisterPage);

#if DEBUG 
            Settings.Email = "ryan@likeylikey.com";
            Settings.Password = "likeylikeyPassword";
#endif 

            Email = Settings.Email;
            Password = Settings.Password;
            
        }


        async Task LoginAttemptAsync()
        {
            await Task.Run(() => LoginAttempt());

        }

        private void LoginAttempt()
        {
            string url = "http://likey20180525084949.azurewebsites.net/token";


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
