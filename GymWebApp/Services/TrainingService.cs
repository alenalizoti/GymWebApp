using GymWebApp.Data;
using GymWebApp.Models;
using GymWebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymWebApp.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ApplicationDbContext _context;

        public TrainingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Training>> GetTrainingsAsync()
        {
            return await _context
                .Trainings
                .Include(t => t.Trainers)
                .ToListAsync();
        }

    }
}
