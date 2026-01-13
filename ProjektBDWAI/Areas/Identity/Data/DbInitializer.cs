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
                },
                new Samochod
                {
                    Marka = "Volkswagen",
                    Model = "Tiroc",
                    Rok = 2021,
                    CenaZaDzien = 250,
                    Dostepny = true
                },
                new Samochod
                {
                    Marka = "Honda",
                    Model = "Civic",
                    Rok = 2018,
                    CenaZaDzien = 150,
                    Dostepny = true
                },
                new Samochod
                {
                    Marka = "Volkswagen",
                    Model = "Golf",
                    Rok = 2024,
                    CenaZaDzien = 160,
                    Dostepny = true
                },
                new Samochod
                {
                    Marka = "Porsche",
                    Model = "Macan",
                    Rok = 2024,
                    CenaZaDzien = 500,
                    Dostepny = true
                }
            );
            context.SaveChanges();
        }
    }
}