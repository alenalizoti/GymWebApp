using GymWebApp.Models;
using GymWebApp.Models.ViewModel;

namespace GymWebApp.Services.Interfaces
{
    public interface ITrainingService
    {
        Task<List<Training>> GetTrainingsAsync();
        Task<PageResult<Training>> GetPagedTrainingsAsync(int pageNumber, int pageSize);
    }
}
