using CakeForYou.Application.Authentication.Commands.Register;
using CakeForYou.Contracts.Authentication;
using CakeForYou.Application.Authentication.Common;
using CakeForYou.Application.Authentication.Queries.Login;
using Mapster;

namespace CakeForYou.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}