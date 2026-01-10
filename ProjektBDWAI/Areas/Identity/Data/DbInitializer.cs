using ProjektBDWAI.Data;
using ProjektBDWAI.Models;

public static class DbInitializer
{
    public static void Seed(ProjektBDWAIContext context)
    {
        if (!context.Samochody.Any())
        {
            context.Samochody.AddRange(
                new Samochod
                {
                    Marka = "Toyota",
                    Model = "Corolla",
                    Rok = 2020,
                    CenaZaDzien = 120,
                    Dostepny = true
                },
                new Samochod
                {
                    Marka = "BMW",
                    Model = "X5",
                    Rok = 2022,
                    CenaZaDzien = 300,
                    Dostepny = true
                }
            );
            context.SaveChanges();
        }
    }
}