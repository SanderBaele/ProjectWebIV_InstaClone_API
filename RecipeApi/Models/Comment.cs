using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Models
{
    public class Comment
    {
        #region Properties
        public int Id { get; set; }

        public int PostId { get; set; }

        public string PosterNaam { get; set; }

        public string Beschrijving { get; set; }

        public DateTime Datum { get; set; }

       
        #endregion

        #region Constructors
        public Comment(string Beschrijving, string PosterNaam ) : this()
        {
            this.Beschrijving = Beschrijving;
            this.PosterNaam = PosterNaam;
        }

        public Comment()
        {
            this.Datum = DateTime.Now;

        }
        #endregion
    }
}
