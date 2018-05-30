using System.Threading.Tasks;
using Xamarin.Forms;

namespace LikeyLikey.Abstractions
{
    public interface IPageService
    {
        Task PushModalAsync(Page page);
        Task PopModalAsync();

        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);


    }
}
