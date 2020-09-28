using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core.Model
{
    public class Movie
    {
        public int movieId { get; set; }
        public string movieTitle { get; set; }
        public string movieDescription { get; set; }
        public bool isRented { get; set; }
        public string rentalDate { get; set; }
        public bool isDeleted { get; set; }
    }
}
