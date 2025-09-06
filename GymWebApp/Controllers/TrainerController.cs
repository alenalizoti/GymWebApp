using GymWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymWebApp.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        public async Task<IActionResult> Index()
        {
            var trainers = await _trainerService.GetTrainersAsync();

            if(!trainers.Any())
            {
                return NotFound();
            }

            return View(trainers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var trainer = await _trainerService.GetTrainerAsync(id);
            if(trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }
    }
}
