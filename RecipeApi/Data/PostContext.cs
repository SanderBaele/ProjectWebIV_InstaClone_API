using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Models;
using System;

namespace RecipeApi.Data
{
    public class PostContext : IdentityDbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public PostContext(DbContextOptions<PostContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasKey(d => d.Id);
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne()
                .IsRequired()
                .HasForeignKey(d => d.PostId); //Shadow property

            base.OnModelCreating(modelBuilder);
        /*    modelBuilder.Entity<User>().HasKey(d => d.Id);
            modelBuilder.Entity<User>()
                .HasMany(p => p.Posts)
                .WithOne()
                .IsRequired()
                .HasForeignKey(r => r.EigenaarId); //Shadow property
                */

            modelBuilder.Entity<Comment>().HasKey(d => d.Id);


            /*  modelBuilder.Entity<Recipe>().Property(r => r.Name).IsRequired().HasMaxLength(50);
              modelBuilder.Entity<Recipe>().Property(r => r.Chef).HasMaxLength(50);
              modelBuilder.Entity<Ingredient>().Property(r => r.Name).IsRequired().HasMaxLength(50);
              modelBuilder.Entity<Ingredient>().Property(r => r.Unit).HasMaxLength(10);
            */

            //Another way to seed the database


           
        



            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, EigenaarId=1, Eigenaar ="Sander", Caption = "Een foto van mij in Parijs", Datum = new DateTime(2019, 1, 4) },
                new Post { Id = 2, EigenaarId = 1, Eigenaar = "Sander", Caption = "Een foto in de dierentuin", Datum = new DateTime(2018, 12, 6) }
  );

            modelBuilder.Entity<Comment>().HasData(
                    //Shadow property can be used for the foreign key, in combination with anaonymous objects
                    new { Id = 1,PosterNaam = "Daan", Beschrijving = "Leuke foto", Datum = new DateTime(2019,2,6),PostId = 1 },
                    new  { Id = 2, PosterNaam = "Stan", Beschrijving = "Mooie foto", Datum = new DateTime(2019, 1, 2), PostId = 1 },
                    new  { Id = 3, PosterNaam = "Bert", Beschrijving = "Leuk!", Datum = new DateTime(2018, 12, 16), PostId = 2 }
                 );
        }
      
        
    }
}