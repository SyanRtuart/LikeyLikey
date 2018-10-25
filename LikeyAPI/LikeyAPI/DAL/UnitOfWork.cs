using System;
using LikeyAPI.Models;

namespace LikeyAPI.DAL
{
    public class UnitOfWork : IDisposable
    {
        private LikeyConext context = new LikeyConext();
        private MovieRepository movieRepository;

        public MovieRepository MovieRepository
        {
            get
            {

                if (this.movieRepository == null)
                {
                    this.movieRepository = new MovieRepository(context);
                }
                return movieRepository;
            }
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
    }
}