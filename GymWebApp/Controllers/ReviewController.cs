using GymWebApp.Models;
using GymWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GymWebApp.Controllers
{
    [Authorize(Roles = "User")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ITrainerService _trainerService;


        public ReviewController(IReviewService reviewService, ITrainerService trainerService)
        {
            _reviewService = reviewService;
            _trainerService = trainerService;
        }
        public async Task<IActionResult> Create()
        {
            var trainers = await _trainerService.GetTrainersAsync();
            if (!trainers.Any())
            {
                return NotFound();
            }
            ViewBag.Trainers = trainers;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Review review)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return Unauthorized();
                }

                await _reviewService.AddReviewAsync(review, userId);

                return RedirectToAction("Index", "Home");
            }

            var trainers = await _trainerService.GetTrainersAsync();
            ViewBag.Trainers = new SelectList(trainers, "TrainerId", "FirstName");
            return View(review);
        }
    }
}
