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
    }
}
