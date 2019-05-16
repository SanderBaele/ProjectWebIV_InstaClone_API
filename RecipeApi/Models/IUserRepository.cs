using System.Collections.Generic;

namespace RecipeApi.Models
{
    public interface IUserRepository
    {
        User GetBy(string email);
        void Add(User user);
        void SaveChanges();
        List<User> GetAll();
    }
}

