using GymWebApp.Models;

namespace GymWebApp.Services.Interfaces
{
    public interface IReservationService
    {
        Task AddReservationAsync(Reservation reservation);
        Task<Reservation?> GetReservationAsync(int id);

        Task<List<Reservation>> GetReservationsAsync();
        Task<Reservation> UpdateReservationAsync(Reservation reservation);
        Task<Training> GetTrainingAsync(int id);
    }
}
