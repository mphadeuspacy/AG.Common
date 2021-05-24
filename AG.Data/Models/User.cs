using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AG.Data.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        
        [Required]
        public string userName { get; set; }

        public virtual ICollection<Tweet> tweets { get; set; }

        public virtual ICollection<Following> userFollowers { get; set; }

        public virtual ICollection<Following> userFollowees { get; set; }
    }
}
