namespace GymWebApp.Models.ViewModel
{
    public class ActivitiesViewModel
    {
        public List<Review> Reviews { get; set; } = new();
        public List<Reservation> Reservations { get; set; } = new();
    }
}
