using MoviesAPI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MoviesAPI.Models
{
    public class MovieInputDTO : IValidatableObject
    {
        [Required]
        //[UpperFirstLetter]
        public string Title { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public string Cost { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var firstLetter = Title[0].ToString();
            if(firstLetter != firstLetter.ToUpper())
                yield return new ValidationResult("The first letter has to be in upper case...", new string[] { "Title"});

            if (!Cost.StartsWith("USD$"))
                yield return new ValidationResult("The currency has to start with USD$...", new string[] { "Cost" });
        }
    }
}
