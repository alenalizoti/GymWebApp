using GymWebApp.Data;
using GymWebApp.Models;
using GymWebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymWebApp.Services
{
    public class OfferService : IOfferService
    {
        private readonly ApplicationDbContext _context;

        public OfferService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Offer>> GetSepcialOfferListAsync()
        {
            return await _context.Offers.Where(o => o.is_highlighted).ToListAsync();
        }

        public async Task<List<Offer>> GetOffersToListAsync()
        {
            return await _context.Offers.ToListAsync();
        }
    }
}
