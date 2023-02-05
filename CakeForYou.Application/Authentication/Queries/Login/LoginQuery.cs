using CakeForYou.Application.Authentication.Common;
using MediatR;
using ErrorOr;

namespace CakeForYou.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}