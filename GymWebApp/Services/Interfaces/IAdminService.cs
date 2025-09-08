using GymWebApp.Models;
using GymWebApp.Models.ViewModel;

namespace GymWebApp.Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<ReservationsPerDay>> Dashboard();
    }
}
