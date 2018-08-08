using LikeyLikey.Helpers;
using LikeyLikey.Services;
using LikeyLikey.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LikeyLikey.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuPage : MasterDetailPage
    {

       // public List<MasterPageItem> MenuList {get; set;}

		public SideMenuPage ()
		{

            ViewModel = new SideMenuPageViewModel(new PageService());

			InitializeComponent ();


		}

        //private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = (MasterPageItem)e.SelectedItem;
        //    Type page = item.TargetType;

        //    Detail = new NavigationPage((Page)Activator.CreateInstance(page));
        //    IsPresented = false;

        //}

        private SideMenuPageViewModel ViewModel
        {
            get { return BindingContext as SideMenuPageViewModel; }
            set { BindingContext = value; }
        }


    }
}