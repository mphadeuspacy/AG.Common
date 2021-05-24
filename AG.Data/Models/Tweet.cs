using System.ComponentModel.DataAnnotations;

namespace AG.Data.Models
{
    public class Tweet
    {
        [Key]
        public int tweetId { get; set; }

        [Required]
        [MaxLength(140, ErrorMessage = "You have exceede 140 characters.")]
        public string message { get; set; }
        
        public int userId { get; set; }

        public virtual User user { get; set; }
    }
}
