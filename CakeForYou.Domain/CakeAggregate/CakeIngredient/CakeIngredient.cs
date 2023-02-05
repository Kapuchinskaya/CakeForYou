using CakeForYou.Domain.CakeAggregate.CakeIngredient.ValueObjects;
using CakeForYou.Domain.Common.Models;
using CakeForYou.Domain.IngredientEntity;

namespace CakeForYou.Domain.CakeAggregate.CakeIngredient
{
    public class CakeIngredient : Entity<CakeIngredientId>
    {
        public double Amount { get; private set; }
        public Ingredient Ingredient { get; private set; }

        private CakeIngredient(CakeIngredientId id, double amount, Ingredient ingredient) : base(id)
        {
            Amount = amount;
            Ingredient = ingredient;
        }

        public static CakeIngredient Create(double amount, Ingredient ingredient)
        {
            return new CakeIngredient(
                CakeIngredientId.CreateUnique(),
                amount,
                ingredient);
        }

#pragma warning disable CS8618
        private CakeIngredient()
        {
        }
#pragma warning disable CS8618
    }
}