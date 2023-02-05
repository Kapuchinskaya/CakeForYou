using System.Collections.Generic;
using CakeForYou.Domain.Common.Models;

namespace CakeForYou.Domain.Common.ValueObjects
{
    public class Rating : ValueObject
    {
        public double Value { get; private set; }

        private Rating(double value)
        {
            Value = value;
        }

        public static Rating CreateNew(double value = 0)
        {
            return new Rating(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}