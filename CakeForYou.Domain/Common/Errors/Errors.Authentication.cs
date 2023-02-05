using ErrorOr;

namespace CakeForYou.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "User.InvalidCredentials",
                description: "Invalid credentials.");
        }
    }
}