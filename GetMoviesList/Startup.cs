using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using GetMoviesList.Services;

[assembly: FunctionsStartup(typeof(GetMoviesList.Startup))]
namespace GetMoviesList
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IMoviesService, MoviesService>();
            //throw new NotImplementedException();
        }
    }
}
