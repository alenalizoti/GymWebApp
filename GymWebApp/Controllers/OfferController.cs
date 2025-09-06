using GymWebApp.Data;
using GymWebApp.Models.ViewModel;
using GymWebApp.Services;
using GymWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymWebApp.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }


        public async Task<IActionResult> Index(int pageNumber = 1, string? sortOrder = null, string? filterType = null)
        {
            int pageSize = 8; 

            var pagedOffers = await _offerService.GetPagedOffersAsync(pageNumber, pageSize, sortOrder, filterType);

            var viewModel = new OfferFilterViewModel
            {
                PagedOffers = pagedOffers,
                SortOrder = sortOrder,
                FilterType = filterType
            };

            return View("AllOffers", viewModel);
        }


    }
}
