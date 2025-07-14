using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "Simyacı", Author = "Paulo Coelho", Price = 49.99m, PageCount = 184 },
                new Book { Id = 2, Name = "Akıl ve Tutku", Author = "Jane Austen", Price = 59.99m, PageCount = 345 },
                new Book { Id = 3, Name = "1984", Author = "George Orwell", Price = 69.99m, PageCount = 328 },
                new Book { Id = 4, Name = "Clean Code", Author = "Robert C. Martin", Price = 99.99m, PageCount = 464 },
                new Book { Id = 5, Name = "C# ile Programlama", Author = "Ali Yılmaz", Price = 79.99m, PageCount = 512 }
            
            
                );


        }
    }
}
