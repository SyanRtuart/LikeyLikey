using LikeyLikey.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LikeyLikey.Services;

namespace LikeyLikey.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            ViewModel = new LoginPageViewModel(new PageService());

            InitializeComponent ();
		}

        private LoginPageViewModel ViewModel
        {
            get { return BindingContext as LoginPageViewModel; }
            set { BindingContext = value; }
        }
    }
}