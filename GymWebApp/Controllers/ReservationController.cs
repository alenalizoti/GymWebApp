using GymWebApp.Models;
using GymWebApp.Models.ViewModel;
using GymWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymWebApp.Controllers
{
    [Authorize(Roles = "User")] 
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationController(IReservationService reservationService, UserManager<ApplicationUser> userManager)
        {
            _reservationService = reservationService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Create(int id)
        {
            var training = await _reservationService.GetTrainingAsync(id);
            if(training == null)
            {
                return NotFound();
            }

            var vm = new ReservationViewModel
            {
                TrainingId = training.trainingId,
                TrainingName = training.trainingName,
                TrainingDescription = training.trainingDescription,
                StartAt = training.startAt,
                Duration = training.duration,
                Trainers = training.Trainers.ToList()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);  
                if(userId == null) return Unauthorized();

                var reservation = new Reservation
                {
                    UserId = userId,
                    TrainingId = model.TrainingId, 
                    Status = Reservation.ReservationStatus.Pending,
                    Created_at = DateTime.UtcNow,
                };
                await _reservationService.AddReservationAsync(reservation);
                TempData["SuccessMessage"] = "Reservation successfully saved!";
                return RedirectToAction("Index", "Training");
            }
            return View(model);
        }
    }
}
