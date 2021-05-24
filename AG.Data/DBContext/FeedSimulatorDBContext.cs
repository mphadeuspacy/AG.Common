using AG.Data.Models;
using System.Data.Entity;

namespace AG.Data.DBContext
{
    public class FeedSimulatorDBContext : DbContext
    {
        public FeedSimulatorDBContext() : base("UserTweetDB")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Following> Followings { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Following>()
                .HasRequired(r => r.follower)
                .WithMany(m => m.userFollowees)
                .HasForeignKey(f => f.followerUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Following>()
               .HasRequired(r => r.followee)
                .WithMany(m => m.userFollowers)
                .HasForeignKey(m => m.followeeuserId)
                .WillCascadeOnDelete(false);
        }
    }
}
