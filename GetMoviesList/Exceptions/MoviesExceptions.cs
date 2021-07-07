using System;
using System.Collections.Generic;
using System.Text;

namespace GetMoviesList.Exceptions
{
    public class MoviesExceptions : Exception
    {
        public string ErrorMessage { get; set; }
    }
}
