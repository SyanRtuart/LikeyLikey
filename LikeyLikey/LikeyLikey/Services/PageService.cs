using System.Threading.Tasks;
using Xamarin.Forms;
using LikeyLikey.Abstractions;

namespace LikeyLikey.Services
{
    public class PageService : IPageService
    {
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PopAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync(true);
        }

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
