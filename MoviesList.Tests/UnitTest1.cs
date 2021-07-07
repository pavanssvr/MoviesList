using System;
using Xunit;
using GetMoviesList;
using Moq;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;

namespace MoviesList.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var moviesService = new Mock<GetMoviesList.Services.IMoviesService>();
            var logger = new Mock<ILogger>();


            var result = new GetMoviesList.MoviesList(moviesService.Object);

            var context = new DefaultHttpContext();
            //var request = context.Request;
            //request.Body.
            var moviesList = await result.Run(HttpRequestSetup(""), logger.Object);


        }

        public HttpRequest HttpRequestSetup(string body)
        {
            var reqMock = new Mock<HttpRequest>();

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(body);
            writer.Flush();
            stream.Position = 0;
            reqMock.Setup(req => req.Body).Returns(stream);
            return reqMock.Object;
        }
    }
}
