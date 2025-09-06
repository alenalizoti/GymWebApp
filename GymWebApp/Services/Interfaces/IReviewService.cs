using GymWebApp.Models;

namespace GymWebApp.Services.Interfaces
{
    public interface IReviewService
    {
        Task AddReviewAsync(Review review, string userId);
    }
}
