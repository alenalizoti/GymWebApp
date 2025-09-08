using GymWebApp.Data;
using GymWebApp.Models;
using GymWebApp.Models.ViewModel;
using GymWebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymWebApp.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReservationsPerDay>> Dashboard()
        {
            return await _context.Reservations
            .GroupBy(r => r.Created_at.Date)
            .Select(g => new ReservationsPerDay
            {
                Date = g.Key.ToString("yyyy-MM-dd"),
                Count = g.Count()
            })
            .ToListAsync();
        }
    }
}
