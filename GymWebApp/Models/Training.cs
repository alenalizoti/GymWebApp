using System.ComponentModel.DataAnnotations;

namespace GymWebApp.Models
{
    public class Training
    {
        public int trainingId { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string trainingName { get; set; } = string.Empty;
        [Required, MinLength(10)]
        public string trainingDescription { get; set; } = string.Empty;
        [Required]
        public decimal duration { get; set; }
        [Required]
        public DateTime startAt { get; set; }
        [Required]
        public int capacity { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
        public virtual ICollection<Reservation> Reservations{ get; set; } = new List<Reservation>();
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime? Updated_at { get; set; }
    }
}
