using LikeyLikey.Services;
using LikeyLikey.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LikeyLikey.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
            ViewModel = new MainPageViewModel(new PageService(), new ApiService());

            InitializeComponent();
		}



        private MainPageViewModel ViewModel
        {
            get { return BindingContext as MainPageViewModel; }
            set { BindingContext = value; }
        }
    }
}