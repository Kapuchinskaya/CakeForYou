using System.Collections.Generic;

namespace CakeForYou.Domain.Common.Models
{
    public class Price: ValueObject
    {
        public decimal Amount { private set; get; }
        public string Currency { private set; get; }

        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}