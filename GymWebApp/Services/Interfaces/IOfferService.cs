using GymWebApp.Models;

namespace GymWebApp.Services.Interfaces
{
    public interface IOfferService
    {
        Task<List<Offer>> GetSepcialOfferListAsync();
        Task<List<Offer>> GetOffersToListAsync();
    }
}
