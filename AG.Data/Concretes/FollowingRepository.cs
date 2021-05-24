using AG.Data.Abstracts;
using AG.Data.DBContext;
using AG.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AG.Data.Concretes
{
    public class FollowingRepository : IFollowingRepository
    {
        private FeedSimulatorDBContext feedSimulatorDBContext;

        public FollowingRepository()
        {
            feedSimulatorDBContext = new FeedSimulatorDBContext();
        }

        public void Add(Following following)
        {
            feedSimulatorDBContext.Followings.Add(following);
            save();
        }

        public void Edit(Following following)
        {
            feedSimulatorDBContext.Entry(following).State = EntityState.Modified;
            save();
        }

        public Following FindById(int? followingId)
        {
            return feedSimulatorDBContext.Followings.Find(followingId);
        }

        public List<Following> GetAll()
        {
            return feedSimulatorDBContext.Followings.ToList();
        }

        public void Remove(int? followingId)
        {
            Following following = feedSimulatorDBContext.Followings.Find(followingId);
            feedSimulatorDBContext.Followings.Remove(following);
            save();
        }

        private void save()
        {
            feedSimulatorDBContext.SaveChanges();
        }
    }
}
