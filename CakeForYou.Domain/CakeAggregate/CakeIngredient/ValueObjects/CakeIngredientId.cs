using System;
using System.Collections.Generic;
using CakeForYou.Domain.Common.Models;

namespace CakeForYou.Domain.CakeAggregate.CakeIngredient.ValueObjects
{
    public class CakeIngredientId : ValueObject
    {
        public Guid Value { get; }

        public CakeIngredientId(Guid value)
        {
            Value = value;
        }

        public static CakeIngredientId CreateUnique()
        {
            return new CakeIngredientId(Guid.NewGuid());
        }

        public static CakeIngredientId Create(Guid id)
        {
            return new CakeIngredientId(id);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}