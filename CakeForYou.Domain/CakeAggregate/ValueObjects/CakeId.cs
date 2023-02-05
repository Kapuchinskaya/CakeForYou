namespace CakeForYou.Domain.Cake.ValueObjects
{
    using System;
    using System.Collections.Generic;
    using Common.Models;
    
    public class CakeId: ValueObject
    {
        public Guid Value { get; }

        public CakeId(Guid value)
        {
            Value = value;
        }

        public static CakeId CreateUnique()
        {
            return new CakeId(Guid.NewGuid());
        }
        
        public static CakeId Create(Guid id)
        {
            return new CakeId(id);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}