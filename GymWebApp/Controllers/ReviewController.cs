using GymWebApp.Models;
using GymWebApp.Models.ViewModel;
using GymWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewController(IReviewService reviewService, ITrainerService trainerService,UserManager<ApplicationUser> userManager)
        {
            _reviewService = reviewService;
            _trainerService = trainerService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Create()
        {
            var trainers = await _trainerService.GetTrainersAsync();
            if (!trainers.Any())
            {
                return NotFound();
            }
            var model = new ReviewViewModel
            {
                Trainers = trainers.Select(t => new SelectListItem
                {
                    Value = t.trainerId.ToString(),
                    Text = t.firstName
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                if (userId == null) return Unauthorized();

                var review = new Review
                {
                    TrainerId = model.TrainerId,
                    Rate = model.Rate,
                    Description = model.Description,
                    UserId = userId
                };

                await _reviewService.AddReviewAsync(review);
                return RedirectToAction("Index", "Home");
            }

            var trainers = await _trainerService.GetTrainersAsync();
            model.Trainers = trainers.Select(t => new SelectListItem
            {
                Value = t.trainerId.ToString(),
                Text = t.firstName
            }).ToList();

            return View(model);
        }
    }
}
