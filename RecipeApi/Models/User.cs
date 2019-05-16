using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Models
{

    public class User
    {
        public int Id { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

       

        public string Email { get; set; }

        public ICollection<Post> Posts { get; set; }



        public User()
        {
            Posts = new List<Post>();
        }
      /*  public User(string Naam, string Wachtwoord, string Email): this()
        {
            this.Email = Email;
            this.Naam = Naam;
            this.Wachtwoord = Wachtwoord;
            
        }*/
    }
}

    
