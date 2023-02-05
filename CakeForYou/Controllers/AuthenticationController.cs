using System.Threading.Tasks;
using CakeForYou.Application.Authentication.Commands.Register;
using CakeForYou.Application.Authentication.Queries.Login;
using CakeForYou.Contracts.Authentication;
using CakeForYou.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace CakeForYou.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    //[ErrorHandlingFilter]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            var authResult = await _mediator.Send(command);

            return authResult.Match(
                result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                Problem);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }

            return authResult.Match(
                result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                Problem);
        }
    }
}