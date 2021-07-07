using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetMoviesList.Services
{
    public interface IMoviesService
    {

       Task<string> GetMovieDetails(string url);
    }

}
