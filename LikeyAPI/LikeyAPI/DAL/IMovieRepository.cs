using System;
using System.Collections.Generic;
using LikeyAPI.Models;

namespace LikeyAPI.DAL
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        //IEnumerable<Movie> GetMovies();
        Movie GetMovieByID(int studentId);
        void InsertMovie(Movie movie);
        void DeleteMovie(int movieID);
        void UpdateMovie(Movie movie);
        void Save();
    }
}