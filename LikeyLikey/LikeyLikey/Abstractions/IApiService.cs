﻿using LikeyLikey.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LikeyLikey.Abstractions
{
    public interface IApiService
    {
        Task<bool> RegisterAsync(string email, string password, string confirmPassword);
        Task<string> LoginAsync(string email, string password);
        Task<Movie> GetMovie();

    }
}
