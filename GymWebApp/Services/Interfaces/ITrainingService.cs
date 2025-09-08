using GymWebApp.Models;

namespace GymWebApp.Services.Interfaces
{
    public interface ITrainingService
    {
        Task<List<Training>> GetTrainingsAsync();
    }
}
