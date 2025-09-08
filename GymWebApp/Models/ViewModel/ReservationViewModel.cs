namespace GymWebApp.Models.ViewModel
{
    public class ReservationViewModel
    {
        public int TrainingId { get; set; }
        public string TrainingName { get; set; } = string.Empty;
        public string TrainingDescription { get; set; } = string.Empty;
        public DateTime StartAt { get; set; }
        public decimal Duration { get; set; }
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();
    }
}
