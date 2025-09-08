namespace GymWebApp.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public required int TrainingId { get; set; }
        public Training Training { get; set; }
        public enum ReservationStatus
        {
            Pending,    // 0
            Approved,   // 1
            Rejected    // 2
        }

        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
        public required string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime? Updated_at { get; set; }

    }
}
