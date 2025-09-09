using GymWebApp.Models;
using GymWebApp.Models.ViewModel;
using GymWebApp.Services;
using GymWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IOfferService _offerService;
        private readonly ITrainingService _trainingService;
        private readonly ITrainerService _trainerService;


        public AdminController(IAdminService adminService, IOfferService offerService, ITrainingService trainingService, ITrainerService trainerService)
        {
            _adminService = adminService;
            _offerService = offerService;
            _trainingService = trainingService;
            _trainerService = trainerService;
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

        [HttpPost]
        public async Task<IActionResult> CreateOffer([FromBody] Offer offer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            offer.Created_at = DateTime.UtcNow;
            await _offerService.CreateOfferAsync(offer);

            return Json(new { success = true, message = "Offer created successfully", offer });
        }

        [HttpPost]
        public async Task<IActionResult> EditOffer([FromBody] Offer offer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            offer.Updated_at = DateTime.UtcNow;
            await _offerService.UpdateOfferAsync(offer);

            return Json(new { success = true, message = "Offer updated successfully", offer });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            await _offerService.DeleteOfferAsync(id);
            return Json(new { success = true, message = "Offer deleted successfully" });
        }


        public async Task<IActionResult> Trainings(int pageNumber = 1)
        {
            int pageSize = 3;
            var pagedTrainings = await _trainingService.GetPagedTrainingsAsync(pageNumber, pageSize);
            return View(pagedTrainings);
        }

        [HttpGet]
        public async Task<IActionResult> EditTraining(int id)
        {
            var training = await _trainingService.GetTrainingAsync(id);
            if(training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTraining(Training model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var training = await _trainingService.GetTrainingAsync(model.trainingId);
            if (training == null)
            {
                return NotFound();
            }
            try
            {
                training.trainingName = model.trainingName;
                training.trainingDescription = model.trainingDescription;
                training.duration = model.duration;
                training.startAt = model.startAt;
                training.capacity = model.capacity;
                training.Updated_at = DateTime.UtcNow;

                await _trainingService.UpdateTrainingAsync(training);
                return RedirectToAction("Trainings","Admin");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the training.");
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateTraining()
        {
            var trainers = await _trainerService.GetTrainersAsync();
            if(!trainers.Any())
            {
                return NotFound();
            }
            var model = new CreateTrainingViewModel
            {
                AvailableTrainers = trainers
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTraining(CreateTrainingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableTrainers = await _trainerService.GetTrainersAsync();
                return View(model);
            }
            var training = new Training
            {
                trainingName = model.TrainingName,
                trainingDescription = model.TrainingDescription,
                duration = model.Duration,
                startAt = model.StartAt,
                capacity = model.Capacity,
                Created_at = DateTime.UtcNow
            };
            if (model.SelectedTrainerIds != null && model.SelectedTrainerIds.Any())
            {
                var selectedTrainers = await _trainerService.GetTrainersByIdsAsync(model.SelectedTrainerIds);
                foreach (var trainer in selectedTrainers)
                {
                    training.Trainers.Add(trainer);
                }
            }
            try
            {
                await _trainingService.AddTrainingAsync(training);
                return RedirectToAction("Trainings", "Admin");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the training.");
                model.AvailableTrainers = await _trainerService.GetTrainersAsync();
                return View(model);
            }
        }

        public async Task<IActionResult> DeleteTraining(int id)
        {
            var training = await _trainingService.GetTrainingAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            try
            {
                await _trainingService.DeleteTrainingAsync(id);
                return RedirectToAction("Trainings", "Admin");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting the training." });
            }
        }

    }
}
