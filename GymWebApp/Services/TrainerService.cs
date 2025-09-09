using GymWebApp.Data;
using GymWebApp.Models;
using GymWebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymWebApp.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ApplicationDbContext _context;

        public TrainerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Trainer>> GetTrainersAsync()
        {
            return await _context.Trainers.ToListAsync();
        }

        public async Task<Trainer?> GetTrainerAsync(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            return trainer;
        }

        public async Task<IEnumerable<Trainer>> GetTrainersByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Trainers
                                 .Where(t => ids.Contains(t.trainerId))
                                 .ToListAsync();
        }
    }
}
 