using GymWebApp.Data;
using GymWebApp.Models;
using GymWebApp.Models.ViewModel;
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



        public async Task<PageResult<Offer>> GetPagedOffersAsync(int pageNumber, int pageSize, string? sortOrder = null, string? filterType = null)
        {
            var query = _context.Offers.AsQueryable();
            
            if(filterType == "Special")
                query = query.Where(o => o.is_highlighted);
            else if(filterType == "Standard")
                query = query.Where(o => !o.is_highlighted);


            query = sortOrder switch
            {
                "title_desc" => query.OrderByDescending(o => o.title),
                "title_asc" => query.OrderBy(o => o.title),
                _ => query.OrderBy(o => o.OfferId) 
            };

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageResult<Offer>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public async Task<List<Trainer>> GetTrainersAsync()
        {
            return await _context.Trainers.ToListAsync();
        }

        public async Task<List<Offer>> GetOffersAsync()
        {
            return await _context.Offers.ToListAsync();
        }
        public async Task CreateOfferAsync(Offer offer)
        {
            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOfferAsync(Offer offer)
        {
            var existingOffer = await _context.Offers.FirstOrDefaultAsync(o => o.OfferId == offer.OfferId);
            if (existingOffer == null) throw new Exception("Offer not found");

            existingOffer.title = offer.title;
            existingOffer.description = offer.description;
            existingOffer.is_highlighted = offer.is_highlighted;
            existingOffer.Updated_at = offer.Updated_at;

            _context.Offers.Update(existingOffer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOfferAsync(int id)
        {
            var offer = await _context.Offers.FindAsync(id);
            if (offer == null) throw new Exception("Offer not found");

            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();
        }

    }
}
