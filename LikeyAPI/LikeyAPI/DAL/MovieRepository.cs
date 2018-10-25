using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using LikeyAPI.Models;
using System.Data.Entity;
using System.Linq.Expressions;

namespace LikeyAPI.DAL
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(LikeyConext context) 
            : base (context)
        {
        }

        //public IEnumerable<Movie> GetMovies()
        //{
        //    return context.Movies.ToList();
        //}

        public Movie GetMovieByID(int id)
        {
            return context.Movies.Find(id);
        }

        public Movie GetMovieByTitle(string title)
        {
            return (from x in  context.Movies where x.Title == title select x).FirstOrDefault();
        }

        public void InsertMovie(Movie student)
        {
            context.Movies.Add(student);
        }

        public void DeleteMovie(int movieID)
        {
            Movie movie = context.Movies.Find(movieID);
            context.Movies.Remove(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            context.Entry(movie).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public override IEnumerable<Movie> Get(Expression<Func<Movie, bool>> filter = null, Func<IQueryable<Movie>, IOrderedQueryable<Movie>> orderBy = null, string includeProperties = "")
        {
            return context.Movies.Where(x => x.imdbRating != "N/A").OrderByDescending(x => x.imdbRating).ToList();
        }

       

        
    }
}