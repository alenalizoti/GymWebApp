using GymWebApp.Data;
using GymWebApp.Models;
using GymWebApp.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymWebApp.Controllers
{
    [Authorize(Roles = "User")]
    public class ActivityController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActivityController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            if(userId == null) return Unauthorized();

            var reviews = await _context.Reviews
                .Include(r => r.Trainer)
                .Where(r => r.UserId == userId)
                .ToListAsync();

            var reservations = await _context.Reservations
                .Include(r => r.Training)
                .Where(r => r.UserId == userId)
                .ToListAsync();

            var model = new ActivitiesViewModel
            {
                Reviews = reviews,
                Reservations = reservations
            };

            return View(model);
        }
    }
}
