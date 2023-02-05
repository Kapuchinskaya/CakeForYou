namespace CakeForYou.Domain.IngredientEntity
{
    using Common.Enums;
    using Common.Models;
    using ValueObjects;

    public class Ingredient : Entity<IngredientId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Measures Measure { get; private set; }

        private Ingredient(IngredientId id, string name, string description, Measures measure) : base(id)
        {
            Name = name;
            Description = description;
            Measure = measure;
        }

        public static Ingredient Create(string name, string description, Measures measure)
        {
            return new Ingredient(
                IngredientId.CreateUnique(),
                name,
                description,
                measure);
        }

#pragma warning disable CS8618
        private Ingredient()
        {
        }
#pragma warning disable CS8618
    }
}