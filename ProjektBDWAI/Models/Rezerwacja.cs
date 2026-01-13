using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjektBDWAI.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum StatusRezerwacji
    {
        Oczekujaca,
        Zaplacona,
        Anulowana
    }

    public class Rezerwacja
    {
        public int Id { get; set; }

        [Required]
        public DateTime DataUtworzenia { get; set; } = DateTime.Now;

        public int SamochodId { get; set; }
        public Samochod Samochod { get; set; }

        public string UserId { get; set; }

        public StatusRezerwacji Status { get; set; }

        [Range(1, 365)]
        public int Dni { get; set; } = 1;
    }
}
