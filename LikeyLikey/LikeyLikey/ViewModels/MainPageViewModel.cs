using LikeyLikey.Abstractions;
using LikeyLikey.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace LikeyLikey.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand GetNextMovieCommand { get; private set; }

        private Movie _movie;

        public Movie Movie
        {
            get { return _movie; }
            set {
                _movie = value;
                OnPropertyChanged();
            }
        }


        //public ObservableCollection<MovieViewModel> Movies { get; private set; } = new ObservableCollection<MovieViewModel>();
        private string _restUrl = "http://www.omdbapi.com/?i=tt0111161&apikey=7dc7fa6d";
        private readonly IApiService _apiService;
        private readonly IPageService _pageService;

        public MainPageViewModel(IPageService pageService, IApiService apiService)
        {
            _apiService = apiService;
            _pageService = pageService;
            GetNextMovieCommand = new Command(GetNextMovieAsync);
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

        private async void GetNextMovieAsync(object obj)
        {
            Movie = await _apiService.GetMovie();
            
        }



    }
}
