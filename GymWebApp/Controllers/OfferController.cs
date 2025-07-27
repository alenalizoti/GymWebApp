using GymWebApp.Data;
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


        public async Task<IActionResult> Index()
        {
            var offers = await _offerService.GetSepcialOfferListAsync();
            if(offers.Any())
            {
                return View(offers);
            }
            return NotFound();
        }

        public async Task<IActionResult> AllOffers()
        {
            var offers = await _offerService.GetOffersToListAsync();
            if(offers.Any() )
            {
                return View(offers);
            }
            return NotFound();
        }
    }
}
