using AG.Data.Abstracts;
using AG.Data.DBContext;
using AG.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AG.Data.Concretes
{
    public class UserDataRepository : IUserDataRepository
    {
        private FeedSimulatorDBContext feedSimulatorDBContext;

        public UserDataRepository()
        {
            feedSimulatorDBContext = new FeedSimulatorDBContext();
        }

        public void Add(User user)
        {
            feedSimulatorDBContext.Users.Add(user);
            save();
        }

        public void Edit(User user)
        {
            feedSimulatorDBContext.Entry(user).State = EntityState.Modified;
            save();
        }

        public User FindById(int? userId)
        {
            return feedSimulatorDBContext.Users.Find(userId);
        }

        public List<User> GetAll()
        {
            return feedSimulatorDBContext.Users.ToList();
        }

        public void Remove(int? userId)
        {
            User user = feedSimulatorDBContext.Users.Find(userId);
            feedSimulatorDBContext.Users.Remove(user);
            save();
        }

        private void save()
        {
            feedSimulatorDBContext.SaveChanges();
        }
    }
}
