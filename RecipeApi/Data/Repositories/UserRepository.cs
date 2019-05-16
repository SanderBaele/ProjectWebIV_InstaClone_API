using Microsoft.EntityFrameworkCore;
using RecipeApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PostContext _context;
        private readonly DbSet<User> _customers;

        public UserRepository(PostContext dbContext)
        {
            _context = dbContext;
            _customers = dbContext.Users;
        }

        public User GetBy(string email)
        {
            return _customers.Include(r => r.Posts).SingleOrDefault(c => c.Email == email);
        }
        public List<User> GetAll()
        {
            return _customers.ToList();
        }
        public void Add(User customer)
        {
            _customers.Add(customer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
