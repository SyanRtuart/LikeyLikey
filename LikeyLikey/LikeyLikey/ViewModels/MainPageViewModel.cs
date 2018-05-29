using LikeyLikey.Abstractions;
using LikeyLikey.Data;
using LikeyLikey.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using LightCaseClient;

namespace LikeyLikey.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        IRestService restService;
        public ObservableCollection<MovieViewModel> Movies { get; private set; } = new ObservableCollection<MovieViewModel>();
        private string _restUrl = "http://www.omdbapi.com/?i=tt0111161&apikey=7dc7fa6d";

        public ICommand GetMoviesCommand { get; private set; }

        public MainPageViewModel()
        {
            //GetMoviesCommand = new Command(async vm => await GetMoviesAsync());
            restService = new RestService();
            
            GetMoviesCommand = new Command(GetMovieAsync);
        }

        private void GetMovie(object obj)
        {
            var movie = restService.GetMovie();
            
            do
            {
                movie = restService.GetMovie();
            } while (movie.Title == null);
            

            Movies.Add(movie);

        }

        private void GetMovieAsync(object obj)
        {

            GenericProxies.RestGetAsync<MovieViewModel>(_restUrl,
                (ex, evaluatedMovie) =>
                {
                    if (ex != null)
                        Console.WriteLine("Failed GetMovieAsync " + ex.Message);
                    else
                        Movies.Add(evaluatedMovie);                    
                });

        }

        //public Task<Movie> GetMoviesAsync()
        //{
        //    return  restService.RefreshDataAsync();


        //}


    }
}
