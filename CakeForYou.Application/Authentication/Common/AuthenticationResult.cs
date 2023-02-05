using CakeForYou.Domain.UserAggregate;

namespace CakeForYou.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}