using System;
using System.Collections.Generic;

namespace RecipeApi.Models
{
    public class Post
    {
        #region Properties
        public int Id { get; set; }

        public int EigenaarId { get; set; }

        public string Eigenaar { get; set; }

        public string Caption { get; set; }

        public string Afbeelding { get; set; }

        public DateTime Datum { get; set; }
       
        public ICollection<Comment> Comments { get;  set; }
      

        public Post()
        {
            Comments = new List<Comment>();
            Datum = DateTime.Now;
        }

        public Post(int EigenaarId, string Caption, string Afbeelding) : this()
        {
            this.EigenaarId = EigenaarId;
            this.Caption = Caption;
            this.Afbeelding = Afbeelding;
        }

        #endregion

        #region Constructors

        #endregion
        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
    }
    }

   
}