using System.Threading;
using System.Threading.Tasks;
using CakeForYou.Application.Authentication.Common;
using CakeForYou.Application.Common.Interfaces.Authentication;
using CakeForYou.Application.Common.Interfaces.Persistence;
using CakeForYou.Domain.Common.Errors;
using CakeForYou.Domain.UserAggregate;
using MediatR;
using ErrorOr;

namespace CakeForYou.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var (email, password) = request;
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return await Task.FromResult(Errors.Authentication.InvalidCredentials);
            }

            if (user.Password != password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return await Task.FromResult(new AuthenticationResult(user, token));
        }
    }
}