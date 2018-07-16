using LikeyLikey.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace LikeyLikey.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand GetMoviesCommand { get; private set; }

        public ObservableCollection<MovieViewModel> Movies { get; private set; } = new ObservableCollection<MovieViewModel>();
        private string _restUrl = "http://www.omdbapi.com/?i=tt0111161&apikey=7dc7fa6d";

        private readonly IApiService _apiService;
        private readonly IPageService _pageService;

        public MainPageViewModel(IPageService pageService, IApiService apiService)
        {
            _apiService = apiService;
            _pageService = pageService;
            GetMoviesCommand = new Command(GetMovieAsync);
        }

        //private void GetMovie(object obj)
        //{
        //    var movie = _apiService.GetMovie();
            
        //    do
        //    {
        //        movie = restService.GetMovie();
        //    } while (movie.Title == null);
            

        //    Movies.Add(movie);

        //}

        private void GetMovieAsync(object obj)
        {


        }



    }
}
