using GymWebApp.Models.ViewModel;
using GymWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IOfferService _offerService;
        private readonly ITrainingService _trainingService;

        public AdminController(IAdminService adminService, IOfferService offerService, ITrainingService trainingService)
        {
            _adminService = adminService;
            _offerService = offerService;
            _trainingService = trainingService;
        }

        public async Task<IActionResult> Dashboard()
        {
            var reservationsPerDay = await _adminService.Dashboard();
            if(!reservationsPerDay.Any())
            {
                return NotFound();
            }
            return View(reservationsPerDay);
        }

        public async Task<IActionResult> Offers(int pageNumber = 1)
        {
            int pageSize = 5;
            var pagedOffers = await _offerService.GetPagedOffersAsync(pageNumber, pageSize);

            return View(pagedOffers);
        }

        public async Task<IActionResult> Trainings(int pageNumber = 1)
        {
            int pageSize = 3;
            var pagedTrainings = await _trainingService.GetPagedTrainingsAsync(pageNumber, pageSize);
            return View(pagedTrainings);
        }

    }
}
