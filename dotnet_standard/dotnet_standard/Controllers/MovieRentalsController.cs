using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using dotnet_standard.Models;

namespace dotnet_standard.Controllers
{
    public class MovieRentalsController : ApiController
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

        // GET: api/MovieRentals

        public IEnumerable<Movie> Get() {
            return movies.Where(movieItem => movieItem.isDeleted == false).ToList();
        }

        // GET: api/MovieRentals/5
        public Movie Get(int id)
        {
            return movies.Where(movieItem => movieItem.isDeleted == false).ToList()[id];
        }

        [BasicAuthentication]
        // POST: api/MovieRentals
        public string Post([FromBody]Movie movie)
        {
            try {
                movies.Add(movie);
                return "Added";
            }
            catch (Exception e) {
                return "Error:" + e.Message;
                throw;
            }
        }

        [BasicAuthentication]
        // PUT: api/MovieRentals/5
        public string Put(int id, [FromBody]Movie movie)
        {
            try {
                movies[id] = movie; 
                return "Updated";
            }
            catch (Exception e) {
                return "Error:" + e.Message;
                throw;
            }
        }

        // DELETE: api/MovieRentals/5
        public string Delete(int id)
        {
            try {
                movies.RemoveAt(id);
                return "Deleted";
            }
            catch (Exception e) {
                return "Error:" + e.Message;
                throw;
            }
        }
    }
}
