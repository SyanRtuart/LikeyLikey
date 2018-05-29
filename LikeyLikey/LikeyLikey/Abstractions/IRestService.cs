using LikeyLikey.Models;
using LikeyLikey.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LikeyLikey.Abstractions
{
    public interface IRestService
    {
        //Task<Movie> RefreshDataAsync();

        MovieViewModel GetMovie();
        void GetMovieAsync();


        //Task SaveTodoItemAsync(TodoItem item, bool isNewItem);

        //Task DeleteTodoItemAsync(string id);
    }
}
