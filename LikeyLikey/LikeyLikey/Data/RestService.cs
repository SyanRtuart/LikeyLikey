
using LikeyLikey.Abstractions;
using LikeyLikey.ViewModels;
using System;
using Newtonsoft.Json;
using LightCaseClient;

namespace LikeyLikey.Data
{
    public class RestService : IRestService
    {
        private string _restUrl = "http://www.omdbapi.com/?i=tt0111161&apikey=7dc7fa6d";


        public RestService()
        {
            //var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            //_client = new HttpClient();
            //_client.MaxResponseContentBufferSize = 256000;
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public MovieViewModel GetMovie()
        {
            //var rnd = new Random();
            //var restUrl = "http://www.omdbapi.com/?i=tt" + rnd.Next(0000001, 5000001) + "&apikey=7dc7fa6d";

            var movie = new MovieViewModel();
            try
            {
                movie = GenericProxies.RestGet<MovieViewModel>(_restUrl);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

            return movie;
        }

        public void  GetMovieAsync()
        {
            //var rnd = new Random();
            //var restUrl = "http://www.omdbapi.com/?i=tt" + rnd.Next(0000001, 5000001) + "&apikey=7dc7fa6d";

            var movie = new MovieViewModel();
            
            GenericProxies.RestGetAsync<MovieViewModel>(_restUrl,
                (ex, evaluatedMovie ) => 
                    {
                        if (ex != null)
                            Console.WriteLine("Failed GetMovieAsync " + ex.Message);
                        else
                            Console.WriteLine("SUCCESS GetMovieAsync " + ex.Message);
                        //add to list ^^^^^^
                    });
                                    
        }
        
    }
}
