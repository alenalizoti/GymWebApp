using GymWebApp.Data;
using GymWebApp.Models;
using GymWebApp.Services.Interfaces;

namespace GymWebApp.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddReviewAsync(Review review, string userId)
        {
            review.UserId = userId;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }
    }
}
