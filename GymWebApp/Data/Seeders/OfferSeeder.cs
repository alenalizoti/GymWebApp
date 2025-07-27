using GymWebApp.Models;

namespace GymWebApp.Data.Seeders
{
    public static class OfferSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Offers.Any())
            {
                Console.WriteLine("Podaci vec postoje!");
                return;
            }

            var offers = new List<Offer>
            {
                new Offer { title = "Basic Gym Access", description = "Access to gym facilities from 8am to 8pm.", is_highlighted = false },
                new Offer { title = "Premium Membership", description = "24/7 access, includes all group classes and personal trainer support.", is_highlighted = true },
                new Offer { title = "Student Plan", description = "Discounted membership for students with valid ID.", is_highlighted = false },
                new Offer { title = "Couples Plan", description = "Membership for two people with 10% discount.", is_highlighted = true },
                new Offer { title = "Morning Workout", description = "Special offer for workouts before 10am on weekdays.", is_highlighted = false },
                new Offer { title = "Weekend Warrior", description = "Weekend-only gym access at a reduced price.", is_highlighted = false },
                new Offer { title = "One Month Trial", description = "Try out our gym for one month without commitment.", is_highlighted = true },
                new Offer { title = "Family Plan", description = "Membership for up to 4 family members.", is_highlighted = true },
                new Offer { title = "Senior Discount", description = "Special rates for seniors aged 60 and above.", is_highlighted = false },
                new Offer { title = "New Year Special", description = "Start your fitness journey with our New Year offer!", is_highlighted = true }
            };

            context.Offers.AddRange(offers);
            context.SaveChanges();
        }
    }
}
