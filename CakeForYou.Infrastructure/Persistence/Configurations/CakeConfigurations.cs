using CakeForYou.Domain.Cake;
using CakeForYou.Domain.Cake.ValueObjects;
using CakeForYou.Domain.CakeAggregate.CakeIngredient.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeForYou.Infrastructure.Persistence.Configurations
{
    public class CakeConfigurations : IEntityTypeConfiguration<Cake>
    {
        public void Configure(EntityTypeBuilder<Cake> builder)
        {
            ConfigureCakeTable(builder);
            ConfigureCakeIngredientTable(builder);

        }

        private static void ConfigureCakeTable(EntityTypeBuilder<Cake> builder)
        {
            builder.ToTable("Cakes");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CakeId.Create(value));

            builder.Property(m => m.Name)
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(250);
        }

        private static void ConfigureCakeIngredientTable(EntityTypeBuilder<Cake> builder)
        {
            builder.OwnsMany(m => m.CakeIngredients, sb =>
            {
                sb.ToTable("CakeIngredients");

                sb.HasKey("Id", "CakeId");

                sb.WithOwner().HasForeignKey("CakeId");

                sb.Property(s => s.Id)
                    .HasColumnName("CakeIngredientId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => CakeIngredientId.Create(value));

                sb.Property(m => m.Amount).HasDefaultValue(0);
                
                sb.HasOne(m => m.Ingredient);

                // sb.OwnsOne(s=> s.Ingredient, ib =>
                // {
                //     ib.ToTable("Ingredients");
                //
                //     ib.WithOwner().HasForeignKey("CakeIngredientId", "CakeId");
                //
                //     ib.HasKey(nameof(Ingredient.Id), "CakeIngredientId", "CakeId");
                //
                //     ib.Property(s => s.Id)
                //         .HasColumnName("IngredientId")
                //         .ValueGeneratedNever()
                //         .HasConversion(
                //             id => id.Value,
                //             value => IngredientId.Create(value));
                //
                //     ib.Property(m => m.Name)
                //         .HasMaxLength(100);
                //
                //     ib.Property(m => m.Description)
                //         .HasMaxLength(250);
                //     
                //     ib.Property(m => m.Measure)
                //         .IsRequired();
                // });
            });

            builder.Metadata.FindNavigation(nameof(Cake.CakeIngredients))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);        
        }
    }
}