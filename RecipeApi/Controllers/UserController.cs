using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.DTOs;
using RecipeApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeApi.Controllers
{

    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private IPostRepository _postRepository;

        // GET: api/<controller>

        public UserController(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }


        [HttpGet]
        public ActionResult<User> GetUser(string email)
        {

            User u = _userRepository.GetBy(email);
            if (u == null) return NotFound();
            return u;



        
    }
        [HttpGet("{id}")]
        public IEnumerable<Post> GetPosts(int id)
        {
           return _postRepository.GetAll().Where(l => l.EigenaarId == id);
          
        }
     

    }
}
