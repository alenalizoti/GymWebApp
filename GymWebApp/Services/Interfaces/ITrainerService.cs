using GymWebApp.Models;

namespace GymWebApp.Services.Interfaces
{
    public interface ITrainerService
    {
        Task<List<Trainer>> GetTrainersAsync();

        Task<Trainer?> GetTrainerAsync(int id);
    }
}
