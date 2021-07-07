using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GetMoviesList.Exceptions;

namespace GetMoviesList.Model
{
    public class Request
    {
        public string TodayDate { get; set; }
        public string Query { get; set; }

        public MoviesExceptions Validate()
        {
            if(Query.Length == 0 || Query.Length >50)
                return new MoviesExceptions() { ErrorMessage = "Enter valid query" };
            else if(!DateTime.Today.ToString("yyyy-MM-dd").Equals(TodayDate))
                return new MoviesExceptions() { ErrorMessage = "Enter valid date" };
            else 
                return null;
        }
    }
}
