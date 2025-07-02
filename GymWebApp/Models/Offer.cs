using System.ComponentModel.DataAnnotations;

namespace GymWebApp.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        [Required, MinLength(3)]
        public string title { get; set; } = string.Empty;
        [Required, MinLength(10)]
        public string description { get; set; } = string.Empty;
        public bool is_highlighted { get; set; } = false;

        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime? Updated_at { get; set; }
    }
}
