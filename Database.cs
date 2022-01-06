using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6
{
    public class ExamDbContext: DbContext
    {
        public ExamDbContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .ToView(nameof(Categories))
                .HasKey(t => t.Id);
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual Category Category { get; set; }
        [ForeignKey("CatehoryId")]
        public int CategoryId { get; set; }
    }
}
