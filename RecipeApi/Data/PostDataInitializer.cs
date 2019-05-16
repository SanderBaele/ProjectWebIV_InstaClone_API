using Microsoft.AspNetCore.Identity;
using RecipeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Data
{
    public class PostDataInitializer
    {
        private readonly PostContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public PostDataInitializer(PostContext dbContext , UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                User student = new User { Email = "student@hogent.be", FirstName = "Student", LastName = "Hogent" };
                _dbContext.Users.Add(student);
                User student2 = new User { Email = "student2@hogent.be", FirstName = "Student2", LastName = "Hogent2" };
                _dbContext.Users.Add(student);
                _dbContext.Users.Add(student2);



                await CreateUser(student.Email, "P@ssword1111");
                await CreateUser(student2.Email, "P@ssword1111");
                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
