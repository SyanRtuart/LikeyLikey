using LikeyLikey.Abstractions;
using LikeyLikey.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public async Task<string> LoginAsync(string email, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", email),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://likey20180525084949.azurewebsites.net/token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var jwt = await response.Content.ReadAsStringAsync();

            var jwtDynamic = JsonConvert.DeserializeObject<Token>(jwt);

            return jwtDynamic.AccessToken;



        }

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
