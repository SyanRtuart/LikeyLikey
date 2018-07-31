using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LikeyAPI.DAL;
using LikeyAPI.Models;
using Newtonsoft.Json;

namespace Likey.Controllers
{
    /// <summary>
    /// Moveis API
    /// </summary>
    /// 
    public class MoviesController : ApiController
    {
         private UnitOfWork unitOfWork = new UnitOfWork();


        /// <summary>
        /// Get a list of all movies.
        /// </summary>
        /// <returns>A list of movies.</returns>
        // GET: api/Movies

        public class movieList
        {
            [JsonProperty(Order = -2)]
            public int pageNumber { get; set; }
            [JsonProperty(Order = 1)]
            public IEnumerable<Movie> movies { get; set; }
            [JsonProperty(Order = -1)]
            public int recordCount { get; set; }
        }

        public movieList GetMovies(int pageNumber = 1)
        {
            movieList ml = new movieList();
            ml.pageNumber = pageNumber;
            ml.movies = unitOfWork.MovieRepository.Get().Skip(pageNumber * 100).Take(100);
            ml.recordCount = ml.movies.Count();
            return ml;
        }

        /// <summary>
        /// Get movie
        /// </summary>
        /// <param name="id">ID of Movie</param>
        /// <returns>A single moveie record</returns>
        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        /// <summary>
        /// Update a movie record.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns>The updated movie record added</returns>
        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.MovieID)
            {
                return BadRequest();
            }

            unitOfWork.MovieRepository.Update(movie);
            unitOfWork.Save();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        /// <summary>
        /// Add a new movie to the database.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>The new movie record.</returns>
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Movie existingMovie = unitOfWork.MovieRepository.GetMovieByTitle(movie.Title);
            //Movie existingMovie = unitOfWork.MovieRepository.Get((o => o.Title == movie.Title)).FirstOrDefault();
            if (existingMovie == null)
            {
                unitOfWork.MovieRepository.Insert(movie);
                unitOfWork.Save();
            }
                return CreatedAtRoute("DefaultApi", new { id = movie.MovieID }, movie);

        }

        // DELETE: api/Movies/5
        /// <summary>
        /// Delete a movie from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted movie record.</returns>
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            if (movie == null)
            {
                return NotFound();
            }

            unitOfWork.MovieRepository.Delete(id);
            unitOfWork.Save();

            return Ok(movie);
        }

        /// <summary>
        /// Checks to see if movie exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(bool))]
        private bool MovieExists(int id)
        {
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            return movie != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}