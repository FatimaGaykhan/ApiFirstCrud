 using System;
using Api_intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_intro.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Category> Categories { get; set; }

        public DbSet<Book>  Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                 new Category
                 {
                     Id = 1,
                     Name="UX UI",
                     CreatedDate = DateTime.Now
                 },
                  new Category
                  {
                      Id = 2,
                      Name="Back-End",
                      CreatedDate = DateTime.Now
                  },
                  new Category
                  {
                      Id = 3,
                      Name = "Front-End",
                      CreatedDate = DateTime.Now
                  }
                );

            modelBuilder.Entity<Book>().HasData(
                 new Book
                 {
                     Id = 1,
                     Name = "Pride and Prejudice",
                     CreatedDate = DateTime.Now
                 },
                  new Book
                  {
                      Id = 2,
                      Name = "The Summer I Turned Pretty",
                      CreatedDate = DateTime.Now
                  },
                  new Book
                  {
                      Id = 3,
                      Name = "Romeo and Juliet",
                      CreatedDate = DateTime.Now
                  }
                );

            base.OnModelCreating(modelBuilder); 
        }

    }
}

