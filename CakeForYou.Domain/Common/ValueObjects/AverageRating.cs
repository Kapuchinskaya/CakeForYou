using System.Collections.Generic;
using CakeForYou.Domain.Common.Models;

namespace CakeForYou.Domain.Common.ValueObjects
{
    public class AverageRating : ValueObject
    {
        public double Values { get; private set; }
        public int NumRating { get; private set; }

        private AverageRating(double values, int numRating)
        {
            Values = values;
            NumRating = numRating;
        }

        public static AverageRating CreateNew(double values = 0, int numRating = 0)
        {
            return new AverageRating(values, numRating);
        }

        public void AddNewRating(Rating rating)
        {
            Values = ((Values * NumRating) + rating.Value) / ++NumRating;
        }

        public void RemoveRating(Rating rating)
        {
            Values = ((Values * NumRating) - rating.Value) / --NumRating;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Values;
        }
    }
}