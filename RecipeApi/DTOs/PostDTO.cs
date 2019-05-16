using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeApi.DTOs
{
    public class PostDTO
    {
        public int EigenaarId { get; set; }
        [Required]
        public string Eigenaar { get; set; }

        public string Caption { get; set; }

        public string Afbeelding { get; set; }

        public IList<CommentDTO> Comments { get; set; }
    }
}
