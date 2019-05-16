using Microsoft.AspNetCore.Mvc;
using RecipeApi.DTOs;
using RecipeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
       
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _customerRepository;

        public PostsController(IPostRepository context, IUserRepository customerRepository)
        {
            _postRepository = context;
            _customerRepository = customerRepository;
        }

        // GET: api/Recipes
        /// <summary>
        /// Get all recipes ordered by name
        /// </summary>
        /// <returns>array of recipes</returns>

        [HttpGet]
        public IEnumerable<Post> GetRecipes()
        {
            return _postRepository.GetAll().OrderBy(r => r.Datum);
        }

       // GET: api/Recipes/5
        /// <summary>
        /// Get the recipe with given id
        /// </summary>
        /// <param name="id">the id of the recipe</param>
        /// <returns>The recipe</returns>
        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(int id)
        {
            Post post = _postRepository.GetBy(id);
            if (post == null) return NotFound();
            return post;
        }

       // POST: api/Recipes
        /// <summary>
        /// Adds a new recipe
        /// </summary>
        /// <param name="post">the new recipe</param>
        [HttpPost]
        public ActionResult<Post> PostRecipe(PostDTO post)
        {
            Post postToCreate = new Post() { EigenaarId = post.EigenaarId, Eigenaar = post.Eigenaar, Caption = post.Caption, Afbeelding = post.Afbeelding };

            foreach (var i in post.Comments)
                postToCreate.AddComment(new Comment(i.Beschrijving, i.PosterNaam));
            _postRepository.Add(postToCreate);
            _postRepository.SaveChanges();

            return CreatedAtAction(nameof(GetPost), new { id = postToCreate.Id }, postToCreate);
        }

      // PUT: api/Recipes/5
        /// <summary>
        /// Modifies a recipe
        /// </summary>
        /// <param name="id">id of the recipe to be modified</param>
        /// <param name="recipe">the modified recipe</param>
       [HttpPut("{id}")]
        public IActionResult PutRecipe(int id, Post recipe)
        {
            /* Console.WriteLine("id = %s, post id = %s", id, recipe.Id);
             if (id != recipe.Id)
             {
                 return BadRequest();
             }*/

            Post bestaandePost = _postRepository.GetBy(id);
            bestaandePost.Comments = recipe.Comments;
            _postRepository.Update(bestaandePost);
            _postRepository.SaveChanges();
            return NoContent();
        }

      



        /*   // DELETE: api/Recipes/5
           /// <summary>
           /// Deletes a recipe
           /// </summary>
           /// <param name="id">the id of the recipe to be deleted</param>
           [HttpDelete("{id}")]
           public ActionResult<Recipe> DeleteRecipe(int id)
           {
               Recipe recipe = _recipeRepository.GetBy(id);
               if (recipe == null)
               {
                   return NotFound();
               }
               _recipeRepository.Delete(recipe);
               _recipeRepository.SaveChanges();
               return recipe;
           }

           /// <summary>
           /// Get an ingredient for a recipe
           /// </summary>
           /// <param name="id">id of the recipe</param>
           /// <param name="ingredientId">id of the ingredient</param>
           [HttpGet("{id}/ingredients/{ingredientId}")]
           public ActionResult<Ingredient> GetIngredient(int id, int ingredientId)
           {
               if (!_recipeRepository.TryGetRecipe(id, out var recipe))
               {
                   return NotFound();
               }
               Ingredient ingredient = recipe.GetIngredient(ingredientId);
               if (ingredient == null)
                   return NotFound();
               return ingredient;
           }

           /// <summary>
           /// Adds an ingredient to a recipe
           /// </summary>
           /// <param name="id">the id of the recipe</param>
           /// <param name="ingredient">the ingredient to be added</param>
           [HttpPost("{id}/ingredients")]
           public ActionResult<Ingredient> PostIngredient(int id, IngredientDTO ingredient)
           {
               if (!_recipeRepository.TryGetRecipe(id, out var recipe))
               {
                   return NotFound();
               }
               var ingredientToCreate = new Ingredient(ingredient.Name, ingredient.Amount, ingredient.Unit);
               recipe.AddIngredient(ingredientToCreate);
               _recipeRepository.SaveChanges();
               return CreatedAtAction("GetIngredient", new { id = recipe.Id, ingredientId = ingredientToCreate.Id }, ingredientToCreate);
           }*/
    }
}