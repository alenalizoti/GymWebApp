using System.ComponentModel.DataAnnotations;

namespace GymWebApp.Models.ViewModel
{
    public class CreateTrainingViewModel
    {
        [Required, MinLength(3), MaxLength(50)]
        public string TrainingName { get; set; } = string.Empty;

        [Required, MinLength(10)]
        public string TrainingDescription { get; set; } = string.Empty;

        [Required]
        [Range(0.5, 24, ErrorMessage = "Duration must be between 0.5 and 24 hours.")]
        public decimal Duration { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(1, 1000, ErrorMessage = "Capacity must be at least 1.")]
        public int Capacity { get; set; }

      
        public IEnumerable<Trainer> AvailableTrainers { get; set; } = new List<Trainer>();

        
        public List<int> SelectedTrainerIds { get; set; } = new List<int>();
    }
}
