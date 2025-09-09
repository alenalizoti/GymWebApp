using GymWebApp.Data;
using GymWebApp.Models;
using GymWebApp.Models.ViewModel;
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
        public async Task<Training?> GetTrainingAsync(int id)
        {
            return await _context
                .Trainings
                .Include(t => t.Trainers)
                .FirstOrDefaultAsync(tr => tr.trainingId == id);
        }
        public async Task<PageResult<Training>> GetPagedTrainingsAsync(int pageNumber, int pageSize)
        {
            var query = _context.Trainings
                .Include(t => t.Trainers)
                .AsQueryable();
           
            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PageResult<Training>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public async Task AddTrainingAsync(Training training)
        {
            await _context.Trainings.AddAsync(training);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTrainingAsync(Training training)
        {
            _context.Trainings.Update(training);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrainingAsync(int id)
        {
            var training = await _context.Trainings.FindAsync(id);
            if (training != null)
            {
                _context.Trainings.Remove(training);
                await _context.SaveChangesAsync();
            }
        }
    }
}
