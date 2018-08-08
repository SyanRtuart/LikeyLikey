using LikeyLikey.Abstractions;
using LikeyLikey.Helpers;
using LikeyLikey.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LikeyLikey.ViewModels
{
    public class SideMenuPageViewModel : BaseViewModel
    {

        private MasterPageItem _selectedItem;
        public MasterPageItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;

                if (_selectedItem == null)
                    return;

                NavigateToPageCommand.Execute(_selectedItem);

                SelectedItem = null;
            }
        }


        public ICommand NavigateToPageCommand { get; private set; }


        public List<MasterPageItem> MenuList { get; set; }

        private readonly IPageService _pageService;

        public SideMenuPageViewModel(IPageService pageService)
        {

            _pageService = pageService;
            NavigateToPageCommand = new Command(async () => await NavigateToPage());


            MenuList = new List<MasterPageItem>()
            {
                new MasterPageItem() { Title="223212121212" , TargetType= typeof(MainPage)}
            };
                        
        }

        private async Task NavigateToPage()
        {

            await _pageService.DisplayAlert("Youre in", "You have logged in - Please try again", "Ok", "Cancel");




        }




    }
}
