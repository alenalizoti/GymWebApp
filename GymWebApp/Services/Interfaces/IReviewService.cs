using GymWebApp.Models;
using System.Security.Claims;

namespace GymWebApp.Services.Interfaces
{
    public interface IReviewService
    {
        Task AddReviewAsync(Review review);
    }
}
