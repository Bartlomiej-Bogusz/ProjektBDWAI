using Microsoft.AspNetCore.Identity;
using ProjektBDWAI.Areas.Identity.Data;
using ProjektBDWAI.Models;

public class AdminDashboardViewModel
{
    public List<ProjektBDWAIUser> Uzytkownicy { get; set; }
    public List<Samochod> Samochody { get; set; }
    public List<Rezerwacja> Rezerwacje { get; set; }
    public List<Platnosc> Platnosci { get; set; }
}