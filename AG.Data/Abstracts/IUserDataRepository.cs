using AG.Data.Models;
using System.Collections.Generic;

namespace AG.Data.Abstracts
{
    public interface IUserDataRepository
    {
        void Add(User user);

        void Edit(User user);

        void Remove(int? userId);

        List<User> GetAll();

        User FindById(int? userId);
    }
}
