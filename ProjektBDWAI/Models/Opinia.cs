using Microsoft.AspNetCore.Identity;
using ProjektBDWAI.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

public class Opinia
{
    public int Id { get; set; }

    [StringLength(1000)]
    public string? Tresc { get; set; }   // może być pusta

    [Range(1, 5, ErrorMessage = "Ocena musi być od 1 do 5")]
    public int Ocena { get; set; }

    public DateTime DataDodania { get; set; } = DateTime.Now;

    // relacja z użytkownikiem
    public string UserId { get; set; }

    public ProjektBDWAIUser User { get; set; }
}