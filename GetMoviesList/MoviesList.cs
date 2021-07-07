using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using GetMoviesList.Services;
using GetMoviesList.Model;
using System.Linq;
using System.Collections.Generic;

namespace GetMoviesList
{
    public class MoviesList
    {
        private readonly IMoviesService _moviesService;
        public MoviesList(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [FunctionName("GetMoviesList")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Request data = JsonConvert.DeserializeObject<Request>(requestBody);
            if (data.Validate() != null)
                return new BadRequestObjectResult(data.Validate());

            var movies = await _moviesService.GetMovieDetails("https://api.themoviedb.org/3/list/7097389?api_key=51ed0958e22db09811303e357ee72425");
            Response response = JsonConvert.DeserializeObject<Response>(movies);

            var filteredMovies = response.Items.Where(m => m.Title.Contains(data.Query));

            var movieDetails = new List<MovieDetails>();

            foreach(Item item in filteredMovies)
            {
                string creditsUrl = $"https://api.themoviedb.org/3/movie/{item.Id}/credits?api_key=51ed0958e22db09811303e357ee72425";
                var creditsResponse = await _moviesService.GetMovieDetails(creditsUrl);
                Credits credits = JsonConvert.DeserializeObject<Credits>(creditsResponse);

                var casts = credits.Cast.Where(c => c.known_for_department == "Acting").OrderBy(d => d.Order);
                var movie = new Item() { Id = item.Id, Title = item.Title };
                movieDetails.Add(new MovieDetails() { 
                    Movie = new Item() { 
                            Id = item.Id
                            , Title = item.Title }
                    , Credits = casts
                });
            }

            return new OkObjectResult(movieDetails);
        }
    }
}
