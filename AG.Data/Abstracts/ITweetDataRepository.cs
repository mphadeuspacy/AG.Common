using AG.Data.Models;
using System.Collections.Generic;

namespace AG.Data.Abstracts
{
    public interface ITweetDataRepository
    {
        void Add(Tweet tweet);

        void Edit(Tweet tweet);

        void Remove(int? tweetId);

        List<Tweet> GetAll();

        Tweet FindById(int? tweetId);
    }
}
