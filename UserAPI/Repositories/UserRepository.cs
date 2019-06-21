using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UserAPI.Models;

namespace UserAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>();

        public void Add(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            _users[user.Id] = user;
        }

        public User Find(string id)
        {
            User user;
            _users.TryGetValue(id, out user);
            return user;
        }

        public IEnumerable<User> FindAll()
        {
            return _users.Values;
        }

        public void Update(User user)
        {
            _users[user.Id] = user;
        }

        public User Delete(string id)
        {
            User user;
            _users.TryRemove(id, out user);
            return user;
        }
    }
}
