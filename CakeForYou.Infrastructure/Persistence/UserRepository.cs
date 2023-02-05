using System.Collections.Generic;
using System.Linq;
using CakeForYou.Application.Common.Interfaces.Persistence;
using CakeForYou.Domain.UserAggregate;

namespace CakeForYou.Infrastructure.Persistence
{
    public class UserRepository: IUserRepository
    {
        private static readonly List<User> _user = new();
        public User? GetUserByEmail(string email)
        {
           return _user.SingleOrDefault(user => user.Email == email);
        }

        public void Add(User user)
        {
            _user.Add(user);
        }
    }
}