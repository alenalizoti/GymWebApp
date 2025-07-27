using GymWebApp.Models;

namespace GymWebApp.Data.Seeders
{
    public static class TrainingSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if(context.Trainings.Any())
            {
                Console.WriteLine("Podaci za treninge vec postoje!");
                return;
            }

            var allTrainers = context.Trainers.ToList();
            var trainings = new List<Training>
            {
                new Training
                {
                    trainingName = "HIIT trening",
                    trainingDescription = "Intenzivan kardio trening.",
                    duration = 45,
                    startAt = DateTime.UtcNow.AddDays(1).AddHours(9),
                    capacity = 15,
                    Trainers = new List<Trainer> { allTrainers[0], allTrainers[1] }
                },
                new Training
                {
                    trainingName = "Joga za početnike",
                    trainingDescription = "Blagi i opuštajući trening za početnike.",
                    duration = 60,
                    startAt = DateTime.UtcNow.AddDays(2).AddHours(10),
                    capacity = 12,
                    Trainers = new List<Trainer> { allTrainers[1] }
                },
                new Training
                {
                    trainingName = "Kruzni trening",
                    trainingDescription = "Trening koji uključuje više vežbi u krugu.",
                    duration = 50,
                    startAt = DateTime.UtcNow.AddDays(3).AddHours(17),
                    capacity = 20,
                    Trainers = new List<Trainer> { allTrainers[2], allTrainers[3] }
                },
                new Training
                {
                    trainingName = "CrossFit izazov",
                    trainingDescription = "Trening visokog intenziteta za iskusne vežbače.",
                    duration = 60,
                    startAt = DateTime.UtcNow.AddDays(4).AddHours(18),
                    capacity = 18,
                    Trainers = new List<Trainer> { allTrainers[4], allTrainers[0] }
                },
                new Training
                {
                    trainingName = "Pilates za zdravu kičmu",
                    trainingDescription = "Vežbe za jačanje leđa i posture.",
                    duration = 40,
                    startAt = DateTime.UtcNow.AddDays(5).AddHours(8),
                    capacity = 10,
                    Trainers = new List<Trainer> { allTrainers[1], allTrainers[3] }
                }
            };

            context.Trainings.AddRange(trainings);
            context.SaveChanges();
        }
    }
}
