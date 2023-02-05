using System;
using CakeForYou.Application.Common.Interfaces.Services;

namespace CakeForYou.Infrastructure.Services
{
    public class DateTimeProvider: IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}