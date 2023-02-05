using CakeForYou.Domain.Cake;
using CakeForYou.Domain.IngredientEntity;
using Microsoft.EntityFrameworkCore;

namespace CakeForYou.Infrastructure.Persistence
{
    public class CfyDbContext : DbContext
    {
        public CfyDbContext(DbContextOptions<CfyDbContext> options) : base(options)
        {
        }

        public DbSet<Cake> Cakes { get; set; } = null!;
        
        public DbSet<Ingredient> Ingredients { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CfyDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}