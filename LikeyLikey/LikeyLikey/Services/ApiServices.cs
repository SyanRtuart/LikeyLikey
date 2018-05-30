using LikeyLikey.Abstractions;
using LikeyLikey.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LikeyLikey.Services
{
    class ApiService : IApiService
    {
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var user = new User
            {
                Email = email,
                Password = password,
                ConfirmPassword = password,
                Username = email
            };

            var json = JsonConvert.SerializeObject(user);

            var content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://likey20180525084949.azurewebsites.net/api/account/register", content);

            return response.IsSuccessStatusCode;

        }
    }
}
