using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet_core.Model;
using dotnet_core.Middlewares;

namespace dotnet_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieRentalController : ControllerBase
    {
        static List<Movie> movies = new List<Movie>() {
            new Movie() {
                movieId = 1,
                movieTitle = "Sample Movie",
                movieDescription = "A movie about sample",
                isRented = false,
                rentalDate = "01/01/1998",
                isDeleted = false
            },new Movie() {
                movieId = 2,
                movieTitle = "Sample Movie",
                movieDescription = "A movie about sample",
                isRented = false,
                rentalDate = "01/01/1998",
                isDeleted = true
            },new Movie() {
                movieId = 3,
                movieTitle = "Sample Movie",
                movieDescription = "A movie about sample",
                isRented = false,
                rentalDate = "01/01/1998",
                isDeleted = false
            },new Movie() {
                movieId = 4 ,
                movieTitle = "Sample Movie",
                movieDescription = "A movie about sample",
                isRented = false,
                rentalDate = "01/01/1998",
                isDeleted = true
            },
        };

        [HttpGet]
        public IActionResult Gets() {
            if (movies.Count == 0) {
                return NotFound("No Movies found");
            }
            return Ok(movies.Where(movieItem => movieItem.isDeleted == false).ToList());
        }

        [HttpGet("GetMovie")]
        public IActionResult Get(int id) {
            var movie = movies.Where(movieItem => movieItem.isDeleted == false).ToList().SingleOrDefault(x => x.movieId == id);
            if(movie == null) {
                return NotFound("No Movie found");
            }
            return Ok(movie);
        }


        [HttpPost("SaveMovie")]
        public IActionResult SaveMovie(Movie movie) {
            movies.Add(movie);
            if (movie == null || movie.ToString() == "") {
                return NotFound("No Post");
            }
            return Ok("Added");
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int id) {
            var movie = movies.SingleOrDefault(x => x.movieId == id);
            if (movie == null) {
                return NotFound("No Movie found");
            }
            movies.Remove(movie);
            return Ok(movie);
        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie(int id, Movie movie) {
            int i = movies.IndexOf(movies.SingleOrDefault(x => x.movieId == id));
            movies[i] = movie;
            if (movie == null || movie.ToString() == "") {
                return NotFound("No Post");
            }
            return Ok("Updated");
        }
    }
}
