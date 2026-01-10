using System.ComponentModel.DataAnnotations;

namespace ProjektBDWAI.Models
{
    public class Platnosc
    {
        public int Id { get; set; }

        [Range(0, 100000)]
        public decimal Kwota { get; set; }

        public DateTime DataPlatnosci { get; set; }

        public int RezerwacjaId { get; set; }
        public Rezerwacja Rezerwacja { get; set; }
    }
}
