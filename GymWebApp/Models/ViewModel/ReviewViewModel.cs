using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymWebApp.Models.ViewModel
{
    public class ReviewViewModel
    {
        public int TrainerId { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; } = string.Empty;

        public IEnumerable<SelectListItem> Trainers { get; set; } = new List<SelectListItem>();
    }
}
