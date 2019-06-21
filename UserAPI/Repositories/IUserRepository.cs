using System.Collections.Generic;
using UserAPI.Models;

namespace UserAPI.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);

        User Find(string id);

        IEnumerable<User> FindAll();

        void Update(User user);

        User Delete(string id);
    }
}
