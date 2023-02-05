using CakeForYou.Application.Authentication.Common;
using MediatR;
using ErrorOr;

namespace CakeForYou.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}