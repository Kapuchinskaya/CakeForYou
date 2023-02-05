using CakeForYou.Domain.UserAggregate;

namespace CakeForYou.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}