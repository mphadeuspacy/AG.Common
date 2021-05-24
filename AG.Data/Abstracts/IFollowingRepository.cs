using AG.Data.Models;
using System.Collections.Generic;

namespace AG.Data.Abstracts
{
    public interface IFollowingRepository
    {
        void Add(Following following);

        void Edit(Following following);

        void Remove(int? followingId);

        List<Following> GetAll();

        Following FindById(int? followingId);
    }
}
