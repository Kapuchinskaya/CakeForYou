using System.Collections.Generic;
using CakeForYou.Domain.Cake.ValueObjects;
using CakeForYou.Domain.CakeAggregate.CakeIngredient;
using CakeForYou.Domain.Common.Models;

namespace CakeForYou.Domain.Cake
{
    public class Cake : Entity<CakeId>
    {
        private readonly List<CakeIngredient> _cakeIngredients = new();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyList<CakeIngredient> CakeIngredients => _cakeIngredients.AsReadOnly();

        private Cake(CakeId id, string name, string description,
            List<CakeIngredient> cakeIngredients) : base(id)
        {
            _cakeIngredients = cakeIngredients;
            Name = name;
            Description = description;
        }

        public static Cake Create(string name, string description, List<CakeIngredient> cakeIngredients)
        {
            return new Cake(
                CakeId.CreateUnique(),
                name,
                description,
                cakeIngredients
            );
        }

#pragma warning disable CS8618
        private Cake()
        {
        }
#pragma warning disable CS8618
    }
}