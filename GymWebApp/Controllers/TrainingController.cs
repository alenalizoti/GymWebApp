using GymWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymWebApp.Controllers
{
    [Authorize(Roles ="User")]
    public class TrainingController : Controller
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        public async Task<IActionResult> Index()
        {
            var trainings = await _trainingService.GetTrainingsAsync();
            return View(trainings);
        }
    }
}
