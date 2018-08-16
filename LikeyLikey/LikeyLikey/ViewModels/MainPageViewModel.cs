using LikeyLikey.Abstractions;
using LikeyLikey.DummyDatabase;
using LikeyLikey.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LikeyLikey.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand GetNextMovieCommand { get; private set; }
        public ICommand GetListOfMovies { get; private set; }

        public ICommand SwipedLeftCommand { get; private set; }
        public ICommand SwipedRightCommand { get; private set; }


        private MoviesDummyDb _db = new MoviesDummyDb();

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


        private ObservableCollection<Movie> _movies;

        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set { _movies = value;
                OnPropertyChanged();
            }
        }



        //public List<Movie> ListOfMovies = new List<Movie>()
        //{
        //    new Movie(){ Title="erer"},
        //    new Movie(){ Title="aasdasda"}

        //};

        private readonly IApiService _apiService;
        private readonly IPageService _pageService;

        public MainPageViewModel(IPageService pageService, IApiService apiService)
        {
            _apiService = apiService;
            _pageService = pageService;
            GetNextMovieCommand = new Command(GetNextMovieAsync);
            SwipedLeftCommand = new Command<Movie>(async vm => await Dislike(vm));
            SwipedRightCommand = new Command<Movie>(async vm => await Like(vm));
            GetListOfMovies = new Command(GetListOfMoviesAsync);
            Movies = new ObservableCollection<Movie>();

            foreach (var item in _db.GetListOfMovies())
            {
                Movies.Add(item);

            }

        }

        private async Task Like(Movie movie)
        {
            await _pageService.DisplayAlert("Liked" + movie.Title, "Liked", "Ok", "Cancel");
        }

        private async Task Dislike(Movie movie)
        {
            await _pageService.DisplayAlert("Disliked" + movie.Title, "Liked", "Ok", "Cancel");
        }

        private async void GetListOfMoviesAsync(object obj)
        {
            try
            {
                var listOfMovies = _db.GetListOfMovies();

                foreach (var item in listOfMovies)
                {
                    Movies.Add(item);
                }
            }
            catch (Exception ex)
            {

                await _pageService.DisplayAlert( ex.Message , "Movie Not Found", "Ok", "Cancel");
            }
          
            //do
            //{
            //    Movie = await _apiService.GetMovie();
            //    if (Movie.Title != null)                
            //        Movies.Add(Movie);


            //} while (Movies.Count < 10);

            //await _pageService.DisplayAlert("GOT 10", "Movie Not Found", "Ok", "Cancel");
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
            
            if (Movie.Title == null)
            {
                await _pageService.DisplayAlert("Movie Not Found", "Movie Not Found", "Ok", "Cancel");
            }
        }

        
    }
}
