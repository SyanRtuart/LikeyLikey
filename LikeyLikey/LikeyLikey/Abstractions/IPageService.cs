using System.Threading.Tasks;
using Xamarin.Forms;

namespace LikeyLikey.Abstractions
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task PopAsync();

        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);


    }
}
