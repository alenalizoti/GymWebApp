using System.ComponentModel.DataAnnotations;

namespace GymWebApp.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public required string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public required int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        [Range(1, 5)]
        public int Rate { get; set; }
        [Required, MinLength(5)]
        public string Description { get; set; } = string.Empty;
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime? Updated_at { get; set; }
    }
}
