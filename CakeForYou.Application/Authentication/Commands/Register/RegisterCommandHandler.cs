using System.Threading;
using System.Threading.Tasks;
using CakeForYou.Application.Authentication.Common;
using CakeForYou.Application.Common.Interfaces.Authentication;
using CakeForYou.Application.Common.Interfaces.Persistence;
using CakeForYou.Domain.Common.Errors;
using CakeForYou.Domain.UserAggregate;
using MediatR;
using ErrorOr;

namespace CakeForYou.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,
            CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return await Task.FromResult(Errors.User.DuplicationEmail);
            }

            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);
            var result = new AuthenticationResult(user, token);

            return await Task.FromResult(result);
        }
    }
}