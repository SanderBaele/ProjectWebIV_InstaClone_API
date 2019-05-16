﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Models
{
    public interface IPostRepository
    {
        Post GetBy(int id);
        bool TryGetPost(int id, out Post post);
        IEnumerable<Post> GetAll();
        void Add(Post post);
        void Delete(Post post);
        void Update(Post post);
        void SaveChanges();
    }
}