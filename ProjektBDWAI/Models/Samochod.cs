using System.ComponentModel.DataAnnotations;

namespace ProjektBDWAI.Models
{
    public class Samochod
    {
        public int Id { get; set; }

        [Required]
        public string Marka { get; set; }

        [Required]
        public string Model { get; set; }

        public int Rok { get; set; }

        [Range(0, 10000)]
        public decimal CenaZaDzien { get; set; }

        public bool Dostepny { get; set; }

        public ICollection<Rezerwacja> Rezerwacje { get; set; }
    }
}
