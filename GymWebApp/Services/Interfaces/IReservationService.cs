using GymWebApp.Models;

namespace GymWebApp.Services.Interfaces
{
    public interface IReservationService
    {
        Task AddReservationAsync(Reservation reservation);
        Task<Training> GetTrainingAsync(int id);
    }
}
