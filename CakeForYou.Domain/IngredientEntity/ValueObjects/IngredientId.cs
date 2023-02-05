using System;
using System.Collections.Generic;
using CakeForYou.Domain.Common.Models;

namespace CakeForYou.Domain.IngredientEntity.ValueObjects
{
    public class IngredientId : ValueObject
    {
        public Guid Value { get; }

        public IngredientId(Guid value)
        {
            Value = value;
        }

        public static IngredientId CreateUnique()
        {
            return new IngredientId(Guid.NewGuid());
        }

        public static IngredientId Create(Guid id)
        {
            return new IngredientId(id);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}