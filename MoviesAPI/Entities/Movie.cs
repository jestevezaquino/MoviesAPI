using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public string Cost { get; set; }
    }
}
