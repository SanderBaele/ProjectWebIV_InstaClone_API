using Microsoft.EntityFrameworkCore;
using RecipeApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApi.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
       private readonly PostContext _context;
        private readonly DbSet<Post> _posts;

        public PostRepository(PostContext dbContext)
        {
            _context = dbContext;


          _posts = dbContext.Posts;
        }

        public IEnumerable<Post> GetAll()
        {
            return _posts.Include(r => r.Comments).ToList();
        }

        public Post GetBy(int id)
        {
            return _posts.Include(r => r.Comments).SingleOrDefault(r => r.Id == id);
        }

        public bool TryGetPost(int id, out Post post)
        {
            post = _context.Posts.Include(t => t.Comments).FirstOrDefault(t => t.Id == id);
            return post != null;
        }

        public void Add(Post recipe)
        {
            _posts.Add(recipe);
        }

        public void Update(Post recipe)
        {
            _context.Update(recipe);
        }

        public void Delete(Post recipe)
        {
            _posts.Remove(recipe);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
