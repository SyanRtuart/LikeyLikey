using LikeyLikey.Services;
using LikeyLikey.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LikeyLikey.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
            ViewModel = new RegisterPageViewModel(new PageService());

            InitializeComponent();
		}

        private RegisterPageViewModel ViewModel
        {
            get { return BindingContext as RegisterPageViewModel; }
            set { BindingContext = value; }
        }

    }
}