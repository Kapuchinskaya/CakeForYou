using ErrorOr;

namespace CakeForYou.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicationEmail => Error.Conflict(
                code: "User.DuplicationEmail",
                description: "Email is already in use.");
        }
    }
}