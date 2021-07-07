using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetMoviesList.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly HttpClient _httpClient;
        public MoviesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetMovieDetails(string url)
        {
            Uri uri = new Uri(url);
            var responseMessage = await _httpClient.GetAsync(uri);
            return responseMessage.Content.ReadAsStringAsync().Result;
        }
    }
}
