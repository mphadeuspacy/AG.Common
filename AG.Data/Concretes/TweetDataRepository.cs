using AG.Data.Abstracts;
using AG.Data.DBContext;
using AG.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AG.Data.Concretes
{
    public class TweetDataRepository : ITweetDataRepository
    {
        private FeedSimulatorDBContext feedSimulatorDBContext;

        public TweetDataRepository()
        {
            feedSimulatorDBContext = new FeedSimulatorDBContext();
        }
        public void Add(Tweet tweet)
        {
            feedSimulatorDBContext.Tweets.Add(tweet);
            save();
        }

        public void Edit(Tweet tweet)
        {
            feedSimulatorDBContext.Entry(tweet).State = EntityState.Modified;
            save();
        }

        public Tweet FindById(int? tweetId)
        {
            return feedSimulatorDBContext.Tweets.Find(tweetId);
        }

        public List<Tweet> GetAll()
        {
            return feedSimulatorDBContext.Tweets.ToList();
        }

        public void Remove(int? tweetId)
        {
            Tweet tweet = feedSimulatorDBContext.Tweets.Find(tweetId);
            feedSimulatorDBContext.Tweets.Remove(tweet);
            save();
        }

        public void save()
        {
            feedSimulatorDBContext.SaveChanges();
        }
    }
}
