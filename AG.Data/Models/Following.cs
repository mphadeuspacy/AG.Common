using System.ComponentModel.DataAnnotations;

namespace AG.Data.Models
{
    public class Following
    {
        [Key]
        public int follwingId { get; set; }

        public int followerUserId { get; set; }

        public int followeeuserId { get; set; }

        public virtual User follower { get; set; }

        public virtual User followee { get; set; }
    }
}
