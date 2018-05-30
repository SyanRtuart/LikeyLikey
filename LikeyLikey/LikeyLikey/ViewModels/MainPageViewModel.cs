using LikeyLikey.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

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


        }

        //public Task<Movie> GetMoviesAsync()
        //{
        //    return  restService.RefreshDataAsync();


        //}


    }
}
