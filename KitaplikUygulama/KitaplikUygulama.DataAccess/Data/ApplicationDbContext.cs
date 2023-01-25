using KitaplikUygulama.DataAccess;
using Microsoft.EntityFrameworkCore;
using KitaplikUygulama.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace KitaplikUygulama.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
       
        public DbSet<CoverType> CoverTypes { get; set; }
      
        public DbSet<Product> Products { get; set; }

    }
}
