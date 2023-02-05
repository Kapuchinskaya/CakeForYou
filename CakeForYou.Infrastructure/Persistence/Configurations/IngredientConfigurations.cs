using CakeForYou.Domain.IngredientEntity;
using CakeForYou.Domain.IngredientEntity.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeForYou.Infrastructure.Persistence.Configurations
{
    public class IngredientConfigurations : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            ConfigureIngredientTable(builder);
        }

        private static void ConfigureIngredientTable(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredients");

            builder.HasKey(u => u.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => IngredientId.Create(value));

            builder.Property(m => m.Name)
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(250);

            builder.Property(m => m.Measure)
                .IsRequired();
        }
    }
}