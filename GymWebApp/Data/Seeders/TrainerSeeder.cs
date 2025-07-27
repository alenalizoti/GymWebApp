using GymWebApp.Models;

namespace GymWebApp.Data.Seeders
{
    public static class TrainerSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if(context.Trainers.Any())
            {
                Console.WriteLine("Podaci vec o trenerima vec postoje!");
                return;
            }

            var trainers = new List<Trainer>
            {
                 new Trainer
                {
                    firstName = "Marko",
                    lastName = "Petrović",
                    image_url = "/images/trainers/marko.jpg",
                    description = "Iskusni personalni trener specijalizovan za snagu i kondiciju.",
                    Created_at = DateTime.UtcNow
                },
                new Trainer
                {
                    firstName = "Jovana",
                    lastName = "Milić",
                    image_url = "/images/trainers/jovana.jpg",
                    description = "Stručnjak za pilates, jogu i rehabilitaciju.",
                    Created_at = DateTime.UtcNow
                },
                new Trainer
                {
                    firstName = "Nikola",
                    lastName = "Stanković",
                    image_url = "/images/trainers/nikola.jpg",
                    description = "Licencirani trener sa 10 godina iskustva u funkcionalnom treningu.",
                    Created_at = DateTime.UtcNow
                },
                new Trainer
                {
                    firstName = "Ana",
                    lastName = "Radović",
                    image_url = "/images/trainers/ana.jpg",
                    description = "Specijalizovana za treninge snage i oblikovanja tela za žene.",
                    Created_at = DateTime.UtcNow
                },
                new Trainer
                {
                    firstName = "Ivan",
                    lastName = "Janković",
                    image_url = "/images/trainers/ivan.jpg",
                    description = "Bivši profesionalni sportista, vodi HIIT i kardio treninge.",
                    Created_at = DateTime.UtcNow
                }
            };

            context.Trainers.AddRange(trainers);
            context.SaveChanges();
        }
    }
}
