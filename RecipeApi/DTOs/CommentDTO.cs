using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.DTOs
{
    public class CommentDTO
    {
        [Required]
        public string PosterNaam { get; set; }

        public string Beschrijving { get; set; }

      //  public DateTime Datum { get; set; }
    }
}
