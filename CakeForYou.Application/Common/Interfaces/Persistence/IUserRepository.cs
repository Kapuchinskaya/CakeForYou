using CakeForYou.Domain.UserAggregate;

namespace CakeForYou.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}