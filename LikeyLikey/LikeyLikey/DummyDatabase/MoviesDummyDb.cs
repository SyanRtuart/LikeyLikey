using LikeyLikey.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LikeyLikey.DummyDatabase
{
    public class MoviesDummyDb
    {
        public List<Movie> GetListOfMovies ()
        {
            return new  List<Movie>()
            {
                new Movie{ Title="Shawshank", Actors="1", Director="John" },
                new Movie{ Title="Godfather", Actors="1", Director="John" },
                new Movie{ Title="Pulp Fiction", Actors="1", Director="John" },
                new Movie{ Title="Angry Men", Actors="1", Director="John" },
                new Movie{ Title="Inception", Actors="1", Director="John" },
                new Movie{ Title="Forest Gump", Actors="1", Director="John" },
                new Movie{ Title="FightClub", Actors="1", Director="John" },
                new Movie{ Title="The Mist", Actors="1", Director="John" },
                new Movie{ Title="Spaceballs", Actors="1", Director="John" },
                new Movie{ Title="Good Will Hunting", Actors="1", Director="John" },

            };


        }
    }
}
