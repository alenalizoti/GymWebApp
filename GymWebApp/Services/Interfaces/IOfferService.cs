using GymWebApp.Models;
using GymWebApp.Models.ViewModel;

namespace GymWebApp.Services.Interfaces
{
    public interface IOfferService
    {
        Task<PageResult<Offer>> GetPagedOffersAsync(int pageNumber, int pageSize, string? sortOrder = null, string? filterType = null);
        Task<List<Offer>> GetOffersAsync();
    }
}
