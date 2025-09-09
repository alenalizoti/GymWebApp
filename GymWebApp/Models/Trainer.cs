using System.ComponentModel.DataAnnotations;

namespace GymWebApp.Models
{
    public class Trainer
    {
        public int trainerId { get; set; }
        [Required, MinLength(3), MaxLength(30)]
        public string firstName { get; set; } = string.Empty;
        [Required, MinLength(3), MaxLength(30)]
        public string lastName { get; set; } = string.Empty;
        public string FullName => firstName + " " + lastName;
        [Required]
        public string image_url { get; set; } = string.Empty;
        [Required, MinLength(10)]
        public string description {  get; set; } = string.Empty;

        public virtual ICollection<Training> Trainings { get; set; } = new List<Training>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime? Updated_at { get; set; }
    }
}
