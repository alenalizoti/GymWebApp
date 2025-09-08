using GymWebApp.Data;
using GymWebApp.Models;
using GymWebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymWebApp.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;
        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Training?> GetTrainingAsync(int id)
        {
            var training = await _context
                .Trainings
                .Include(t => t.Trainers)
                .FirstOrDefaultAsync(t => t.trainingId == id);

            return training;
        }
        public async Task AddReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
